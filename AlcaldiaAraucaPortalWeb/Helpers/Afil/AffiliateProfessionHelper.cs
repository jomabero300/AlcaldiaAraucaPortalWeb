using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class AffiliateProfessionHelper : IAffiliateProfessionHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public AffiliateProfessionHelper(ApplicationDbContext context, IImageHelper imageHelper, IConfiguration configuration, IWebHostEnvironment env)
        {
            _context = context;
            _imageHelper = imageHelper;
            _configuration = configuration;
            _env = env;
        }

        public async Task<Response> AddUpdateAsync(AffiliateProfessionViewModels model)
        {
            Response response = new Response() { Succeeded = true };
            string documentePath = string.Empty;
            string imagePath=string.Empty;

            try
            {
                if(model.DocumentoPath != null)
                {
                    documentePath = await _imageHelper.UploadFileAsync(model.DocumentoPath, "Image/Afiliate/Document");
                }
                if(model.ImagePath != null)
                {
                    imagePath = await _imageHelper.UploadImageAsync(model.ImagePath, "Image/Afiliate/Image");
                }

                AffiliateProfession modelProf=new AffiliateProfession()
                {
                    AffiliateProfessionId = model.AffiliateProfessionId,
                    AffiliateId=model.AffiliateId,
                    ProfessionId=model.ProfessionId,
                    Concept=model.Concept,
                    DocumentoPath= documentePath,
                    ImagePath= imagePath
                };

                if (model.AffiliateProfessionId == 0)
                {
                    _context.AffiliateProfessions.Add(modelProf);
                }
                else
                {
                    _context.AffiliateProfessions.Update(modelProf);
                }


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("IX_") ? "El registro ya existe" : ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int Id)
        {
            Response response = new Response() { Succeeded = true };

            AffiliateProfession model = await _context.AffiliateProfessions.FindAsync(Id);

            string documentPath = model.DocumentoPath;

            string imagePath = model.ImagePath;

            try
            {
                _context.AffiliateProfessions.Remove(model);
                await _context.SaveChangesAsync();
                await _imageHelper.DeleteImageAsync(documentPath, "Afiliate/Document");
                await _imageHelper.DeleteImageAsync(imagePath, "Afiliate/Image");

            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la profesion, porque tiene registros relacionados" : ex.Message;
            }

            return response;
        }

        public string FileMove(string sourceFileName, string destFileName)
        {
            var Folder = destFileName.Replace("\\", "/");

            var pathFolder = _configuration["MyFolders:AfiliateTemp"];

            var url = _configuration["MyDomain:Url"];

            int star = sourceFileName.LastIndexOf("/") + 1;

            var file = sourceFileName.Substring(star, sourceFileName.Length - star);

            sourceFileName = Path.Combine(_env.WebRootPath, pathFolder, file);

            destFileName = destFileName.Replace('/', '\\');

            destFileName = Path.Combine(_env.WebRootPath, destFileName, file);

            System.IO.File.Move(sourceFileName, destFileName);

            return $"{url}{Folder}/{file}";
        }

        public async Task<List<StatisticsViewModel>> StatisticsAsync(int id)
        {
            List<StatisticsViewModel> model = id != 0 ?
                            await _context.AffiliateProfessions
                                          .Include(a => a.Profession)
                                          .Where(a => a.ProfessionId == id)
                                          .GroupBy(a => new { a.ProfessionId, a.Profession.ProfessionName })
                                          .Select(a => new StatisticsViewModel { Id = a.Key.ProfessionId, Name = a.Key.ProfessionName, Total = a.Count() })
                                          .OrderBy(a => a.Name)
                                          .ToListAsync() :
                             await _context.AffiliateProfessions
                                          .Include(a => a.Profession)
                                          .GroupBy(a => new { a.ProfessionId, a.Profession.ProfessionName })
                                          .Select(a => new StatisticsViewModel { Id = a.Key.ProfessionId, Name = a.Key.ProfessionName, Total = a.Count() })
                                          .OrderBy(a => a.Name)
                                          .ToListAsync();
            return model;
        }
    }
}
