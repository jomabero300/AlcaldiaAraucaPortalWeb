namespace AlcaldiaAraucaPortalWeb.Helpers.Pdf
{
    public interface IPdfDocumentHelper
    {
        Task<MemoryStream> StatisticsAsync(int id,string title,string idOp="");
    }
}
