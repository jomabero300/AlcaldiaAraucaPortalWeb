using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateSocialNetworkHelper
    {
        Task<List<StatisticsViewModel>> StatisticsAsync(int id);
        Task<Response> AddUpdateAsync(AffiliateSocialNetwork model);
        Task<Response> DeleteAsync(int id);
    }
}
