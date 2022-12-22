using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateProfessionHelper
    {
        Task<Response> AddUpdateAsync(AffiliateProfessionViewModels model);
        Task<Response> DeleteAsync(int Id);
        Task<List<StatisticsViewModel>> StatisticsAsync(int id);
        string FileMove(string sourceFileName, string destFileName);
    }
}
