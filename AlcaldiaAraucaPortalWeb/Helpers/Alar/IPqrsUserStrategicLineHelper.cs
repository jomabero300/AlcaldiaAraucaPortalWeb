using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public interface IPqrsUserStrategicLineHelper
    {
        Task<Response> AddUpdateAsync(PqrsUserStrategicLine model);
        Task<PqrsUserStrategicLine> ByIdAsync(int id);
        Task<Response> DeleteAsync(int id);
        Task<PqrsStrategicLine> PqrsStrategicLineEmaildAsync(string email);
        Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(string id);
        Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(int strategiaLineaId);
        Task<List<PqrsStrategicLine>> PqrsStrategicLineAsync(string userId);


        Task<List<PqrsUserStrategicLine>> ListAsync();
    }
}
