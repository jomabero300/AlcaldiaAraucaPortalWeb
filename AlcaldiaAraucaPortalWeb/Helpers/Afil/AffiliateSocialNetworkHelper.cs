using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class AffiliateSocialNetworkHelper : IAffiliateSocialNetworkHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateSocialNetworkHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(AffiliateSocialNetwork model)
        {
            if (model.AffiliateId == 0)
            {
                _context.AffiliateSocialNetworks.Add(model);
            }
            else
            {
                _context.AffiliateSocialNetworks.Update(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe una red social con el mismo nombre para este usuario.!!!";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }

                response.Succeeded = false;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            Response response = new Response() { Succeeded = true };

            AffiliateSocialNetwork model = await _context.AffiliateSocialNetworks.Where(a => a.AffiliateSocialNetworkId == id).FirstOrDefaultAsync();

            try
            {
                _context.AffiliateSocialNetworks.Remove(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar el registro, tiene registros relacionados" : ex.Message;
            }

            return response;
        }

        public async Task<List<StatisticsViewModel>> StatisticsAsync(int id)
        {
            List<StatisticsViewModel> model = id == 0 ?
                            await _context.AffiliateSocialNetworks
                                            .Include(a => a.SocialNetwork)
                                            .GroupBy(a => new { a.SocialNetworkId, a.SocialNetwork.SocialNetworkName })
                                            .OrderBy(a => a.Key.SocialNetworkName)
                                            .Select(a => new StatisticsViewModel {Id= a.Key.SocialNetworkId,Name=a.Key.SocialNetworkName, Total = a.Count() })
                                            .ToListAsync() :
                             await _context.AffiliateSocialNetworks
                                            .Include(a => a.SocialNetwork)
                                            .Where(a => a.SocialNetworkId == id)
                                            .GroupBy(a => new { a.SocialNetworkId, a.SocialNetwork.SocialNetworkName })
                                            .OrderBy(a => a.Key.SocialNetworkName)
                                            .Select(a => new StatisticsViewModel { Id = a.Key.SocialNetworkId, Name = a.Key.SocialNetworkName, Total = a.Count() })
                                            .ToListAsync();

            return model.OrderBy(n=>n.Name).ToList();
        }
    }
}
