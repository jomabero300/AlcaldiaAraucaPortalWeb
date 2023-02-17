using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IGroupCommunityHelper
    {
        Task<Response> AddUpdateAsync(GroupCommunity model);
        Task<GroupCommunity> ByIdAsync(int id);
        Task<List<GroupCommunity>> ByIdAffiliateAsync(int id);
        Task<List<GroupCommunity>> ComboAsync();
        Task<List<GroupCommunity>> ComboAsync(string[] GroupCommunity,bool lbEsta);
        Task<List<GroupCommunityViewModel>> StatisticsReportAsync(GroupCommunityViewModel model);
        Task<Response> DeleteAsync(int id);
        Task<List<GroupCommunity>> ListAsync();
        Task<AffiliateGroupCommunityViewModelsFilter> ListAsync(int RowsCant, int OmitCant, string SearchText = "");
    }
}
