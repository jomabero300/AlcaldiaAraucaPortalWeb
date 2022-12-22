using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateGroupCommunityHelper
    {
        Task<Response> AddUpdateAsync(AffiliateGroupCommunity model);
        Task<Response> DeleteAsync(int AffiliateGroupCommunityId);
        Task<List<StatisticsViewModel>> StatisticsAsync(int id);
    }
}
