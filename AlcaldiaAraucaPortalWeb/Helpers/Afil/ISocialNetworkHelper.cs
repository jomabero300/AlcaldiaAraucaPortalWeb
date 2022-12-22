using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface ISocialNetworkHelper
    {
        Task<Response> AddUpdateAsync(SocialNetwork model);
        Task<SocialNetwork> ByIdAsync(int id);
        Task<SocialNetwork> ByIdNameAsync(string name);
        Task<List<SocialNetwork>> ComboAsync();
        Task<List<SocialNetwork>> ComboAsync(int affiliatId);
        Task<List<SocialNetwork>> ComboAsync(string[] socialNetworkName,bool lbEsta);


        Task<Response> DeleteAsync(int id);
        Task<List<SocialNetwork>> ListAsync();
    }
}
