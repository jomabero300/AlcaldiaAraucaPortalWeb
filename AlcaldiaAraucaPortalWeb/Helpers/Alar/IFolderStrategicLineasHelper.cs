namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public interface IFolderStrategicLineasHelper
    {
        Task<string> FolderPathAsync(int pqrsStrategicLineSectorId, string userName);
        string FolderPath(string lineName, string SectorName);
        Task<string> FolderPathAsync(int LineaId, int SectorId);
        Task<string> lpineNameAsync(string userName);
        string FileMove(string sourceFileName, string destFileName);
    }
}
