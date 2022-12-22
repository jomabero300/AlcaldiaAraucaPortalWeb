using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public interface IPqrsStrategicLineHelper
    {
        Task<List<PqrsStrategicLine>> PqrsStrategicLineUserComboAsync();
        Task<List<PqrsStrategicLine>> PqrsStrategicLineComboAsync();
        Task<List<PqrsStrategicLine>> PqrsStrategicLineComboPrenAsync();
        Task<PqrsStrategicLine> ByNameAsync(string name);
    }
}
