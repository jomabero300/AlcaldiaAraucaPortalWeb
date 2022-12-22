using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IDocumentTypeHelper
    {
        Task<Response> AddUpdateAsync(DocumentType model);
        Task<DocumentType> ByIdAsync(int id);
        Task<DocumentType> ByIdNameAsync(string name);
        Task<List<DocumentType>> ComboAsync();
        Task<Response> DeleteAsync(int id);
        Task<List<DocumentType>> ListAsync();
    }
}
