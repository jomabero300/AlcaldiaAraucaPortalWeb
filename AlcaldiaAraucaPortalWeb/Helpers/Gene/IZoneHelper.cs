using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IZoneHelper
    {
        Task<List<Zone>> ComboAsync();
    }
}
