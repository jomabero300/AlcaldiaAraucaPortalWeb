using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class AffiliateGroupCommunityHelper : IAffiliateGroupCommunityHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateGroupCommunityHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(AffiliateGroupCommunity model)
        {
            if (model.AffiliateGroupCommunityId == 0)
            {
                _context.AffiliateGroupCommunities.Add(model);
            }
            else
            {
                _context.AffiliateGroupCommunities.Update(model);
            }
            Response response = new Response() { Succeeded = true };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe una registro con el mismo nombre.!!!";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }

                response.Succeeded = false;
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;

                response.Succeeded = false;
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int AffiliateGroupCommunityId)
        {
            Response response = new Response() { Succeeded = true };

            AffiliateGroupCommunity model = await _context.AffiliateGroupCommunities.FindAsync(AffiliateGroupCommunityId);

            try
            {
                _context.AffiliateGroupCommunities.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "No se puede borrar este registro, porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<StatisticsViewModel>> StatisticsAsync(int id)
        {
            List<StatisticsViewModel> model = id == 0 ?
                                 await _context.AffiliateGroupCommunities
                                              .Include(g => g.GroupCommunity)
                                              .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                              .Select(g => new StatisticsViewModel { Id = g.Key.GroupCommunityId, Name = g.Key.GroupCommunityName, Total = g.Count() })
                                              .ToListAsync() :
                                 await _context.AffiliateGroupCommunities
                                              .Include(g => g.GroupCommunity)
                                              .Where(g => g.GroupCommunityId == id)
                                              .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                              .Select(g => new StatisticsViewModel { Id = g.Key.GroupCommunityId, Name = g.Key.GroupCommunityName, Total = g.Count() })
                                              .ToListAsync();

            return model.OrderBy(g => g.Name).ToList();
        }
    }
}
