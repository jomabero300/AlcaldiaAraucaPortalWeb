using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface ICommuneTownshipHelper
    {
        Task<CommuneTownship> ByIdAsync(int id);

        Task<List<CommuneTownship>> ComboAsync(int zoneId);
    }
}
