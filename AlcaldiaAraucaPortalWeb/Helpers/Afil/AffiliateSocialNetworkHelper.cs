using AlcaldiaAraucaPortalWeb.Data;
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
