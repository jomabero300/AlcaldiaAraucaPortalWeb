using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;
using static iTextSharp.text.pdf.AcroFields;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class AffiliateHelper : IAffiliateHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageHelper _imageHelper;

        public AffiliateHelper(ApplicationDbContext context, IImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }

        public async Task<Response> AddUpdateAsync(Affiliate model)
        {
            if (model.AffiliateId == 0)
            {
                _context.Affiliates.Add(model);
            }
            else
            {
                _context.Affiliates.Update(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("IX_") ? "El registro ya existe" : ex.Message;
            }

            return response;
        }

        public async Task<Affiliate> AffiliateByIdAsync(int id)
        {
            Affiliate model = await _context.Affiliates
                                      .Include(a => a.ApplicationUser)
                                      .Include(a => a.GroupCommunities).ThenInclude(a => a.GroupCommunity)
                                      .Include(a => a.GroupProductives).ThenInclude(a => a.GroupProductive)
                                      .Include(a => a.Professions).ThenInclude(a => a.Profession)
                                      .Include(a => a.SocialNetworks).ThenInclude(a => a.SocialNetwork)
                                      .FirstOrDefaultAsync(a => a.AffiliateId == id);

            return model;
        }

        public async Task<List<Affiliate>> AffiliateListAsync(string id)
        {
            List<Affiliate> model = await _context.Affiliates
                                                  .Include(a => a.ApplicationUser)
                                                  .Where(a=>a.UserId==id)
                                                  .ToListAsync();

            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            string folder = "Image\\Afiliate\\Image";

           var response = new Response() { Succeeded = true };

            Affiliate model = await _context.Affiliates
                                      .Include(a=>a.GroupProductives)
                                      .Include(a=>a.GroupCommunities)
                                      .Include(a=>a.Professions)
                                      .Include(a=>a.SocialNetworks)
                                      .Where(a => a.AffiliateId == id).FirstOrDefaultAsync();
            try
            {
                _context.Affiliates.Remove(model);

                await _context.SaveChangesAsync();

                _imageHelper.DeleteImageAsync(model.ImagePath, folder).Wait();

                foreach (var item in model.Professions)
                {
                    if(!string.IsNullOrEmpty(item.ImagePath))
                    {
                        _imageHelper.DeleteImageAsync(item.ImagePath, folder).Wait();
                    }
                    if(!string.IsNullOrEmpty(item.DocumentoPath))
                    {
                        _imageHelper.DeleteImageAsync(item.DocumentoPath, "Image\\Afiliate\\Document").Wait();
                    }

                }
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la categoría porque tiene registros relacionados" : ex.Message;
            }

            return response;
        }
    }
}
