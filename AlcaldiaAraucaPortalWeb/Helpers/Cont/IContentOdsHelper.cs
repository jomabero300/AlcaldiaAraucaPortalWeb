using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;

namespace AlcaldiaAraucaPortalWeb.Helpers.Cont
{
    public interface IContentOdsHelper
    {
        Task<List<ContentOds>> ByIdAsync(int SectorId);
    }
}
