using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateSocialNetworkHelper
    {
        Task<List<StatisticsViewModel>> StatisticsAsync(int id);
    }
}
