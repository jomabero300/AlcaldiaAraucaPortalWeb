using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface INeighborhoodSidewalkHelper
    {
        Task<List<NeighborhoodSidewalk>> ComboAsync(int CommuneTownshipId);
        Task<NeighborhoodSidewalk> ByIdNameAsync(string name);
        Task<NeighborhoodSidewalk> ByIdAsync(int id);
    }
}
