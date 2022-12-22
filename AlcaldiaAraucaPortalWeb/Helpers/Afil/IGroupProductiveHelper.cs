using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IGroupProductiveHelper
    {
        Task<Response> AddUpdateAsync(GroupProductive model);
        Task<GroupProductive> ByIdAsync(int id);
        Task<List<GroupProductive>> ByIdAffiliateAsync(int id);
        Task<List<GroupProductive>> ComboAsync();
        Task<List<GroupProductive>> ComboAsync(string[] GroupProductives, bool lbEsta);
        Task<Response> DeleteAsync(int id);
        Task<List<GroupProductive>> ListAsync();
    }
}
