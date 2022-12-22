using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{

    public interface IPqrsStrategicLineSectorHelper
    {
        Task<List<PqrsStrategicLineSector>> ComboAsync(int pqrsStrategicLineId);
        Task<List<PqrsStrategicLineSector>> ComboAsync(string email);
        Task<PqrsStrategicLineSector> ByNameAsync(string pqrsStrategicLineSectorName, int PqrsStrategicLineId);
        Task<PqrsStrategicLineSector> ByIdAsync(int pqrsStrategicLineSectorId);
        PqrsStrategicLineSector ById(int pqrsStrategicLineSectorId);
        Task<List<PqrsStrategicLineSector>> ListAsync();
    }
}
