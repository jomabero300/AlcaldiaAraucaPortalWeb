using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IGenderHelper
    {
        Task<Response> AddUpdateAsync(Gender model);
        Task<Gender> ByIdAsync(int id);
        Task<Gender> ByIdNameAsync(string name);
        Task<List<Gender>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<Gender>> ListAsync();
    }
}
