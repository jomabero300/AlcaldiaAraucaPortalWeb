using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IProfessionHelper
    {
        Task<Response> AddUpdateAsync(Profession model);
        Task<Profession> ByIdAsync(int id);
        Task<List<Profession>> ByIdAffiliateAsync(int id);
        Task<List<Profession>> ComboAsync();
        Task<List<Profession>> ComboAsync(string[] GroupProfession,bool lbEsta);
        Task<Response> DeleteAsync(int id);
        Task<List<Profession>> ListAsync();
    }
}
