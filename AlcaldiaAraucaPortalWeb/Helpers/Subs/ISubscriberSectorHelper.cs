using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public interface ISubscriberSectorHelper
    {
        Task<List<SubscriberSector>> BySectorIdAsync(int pqrsStrategicLineSectorId);
        Task<List<SubscriberSector>> BySubSectorAsync();
        Task<Response> AddUpdateAsync(List<SubscriberSector> model);
    }
}
