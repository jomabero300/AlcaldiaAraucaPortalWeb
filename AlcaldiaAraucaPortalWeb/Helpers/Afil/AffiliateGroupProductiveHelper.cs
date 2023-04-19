using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class AffiliateGroupProductiveHelper : IAffiliateGroupProductiveHelper
    {
        private readonly ApplicationDbContext _context;

        public AffiliateGroupProductiveHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(AffiliateGroupProductive model)
        {
            if (model.AffiliateGroupProductiveId == 0)
            {
                _context.AffiliateGroupProductives.Add(model);
            }
            else
            {
                _context.AffiliateGroupProductives.Update(model);
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
                    response.Message = $"Ya existe este registro.!!!";
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

        public async Task<Response> DeleteAsync(int groupProductiveId)
        {
            Response response = new Response() { Succeeded = true };

            AffiliateGroupProductive model = await _context.AffiliateGroupProductives.FindAsync(groupProductiveId);

            try
            {
                _context.AffiliateGroupProductives.Remove(model);
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
                                 await _context.AffiliateGroupProductives
                                              .Include(g => g.GroupProductive)
                                              .GroupBy(g => new { g.GroupProductiveId, g.GroupProductive.GroupProductiveName })
                                              .Select(g => new StatisticsViewModel { Id = g.Key.GroupProductiveId, Name = g.Key.GroupProductiveName, Total = g.Count() })
                                              .ToListAsync() :
                                 await _context.AffiliateGroupProductives
                                              .Include(g => g.GroupProductive)
                                              .Where(g => g.GroupProductiveId == id)
                                              .GroupBy(g => new { g.GroupProductiveId, g.GroupProductive.GroupProductiveName })
                                              .Select(g => new StatisticsViewModel { Id = g.Key.GroupProductiveId, Name = g.Key.GroupProductiveName, Total = g.Count() })
                                              .ToListAsync();

            return model.OrderBy(g => g.Name).ToList();
        }

    }
}
