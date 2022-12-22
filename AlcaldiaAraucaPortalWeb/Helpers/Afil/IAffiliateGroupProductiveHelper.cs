using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateGroupProductiveHelper
    {
        Task<Response> AddUpdateAsync(AffiliateGroupProductive model);
        Task<Response> DeleteAsync(int groupProductiveId);
        Task<List<StatisticsViewModel>> StatisticsAsync(int id);
    }
}
