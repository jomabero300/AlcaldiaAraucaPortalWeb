using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public interface IAffiliateHelper
    {
        Task<List<Affiliate>> AffiliateListAsync();
        Task<Affiliate> AffiliateByIdAsync(int id);
        Task<Response> AddUpdateAsync(Affiliate model);
        Task<Response> DeleteAsync(int id);
    }
}
