using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;

namespace AlcaldiaAraucaPortalWeb.Helpers.Cont
{
    public interface IContentHelper
    {
        Task<Response> AddAsync(ContentModelsViewCont model);
        Task<Response> UpdateAsync(ContentEditViewModel model);
        Task<Response> AddEditDetailAsync(ContentDetail model);

        Task<List<Content>> ListAsync(int SectorId);
        Task<List<FilterViewModel>> ListTitleAsync(string title);
        Task<List<ContentDetail>> ListDetailsAsync(int contentId);
        Task<List<Content>> ListUserAsync(string email);
        Task<List<Content>> ListReporterAsync();


        Task<ContentDetail> DetailsIdAsync(int ContentDetailsId);
        Task<Content> ByIdAsync(int contentId);
        Task<List<string>> ByImageAsync(int contentId);
        Task<Content> ByUserIdAsync(string email, int contentId);
        Task<Response> DeleteDetailsAsync(int id);
        Task<Response> DeleteAsync(int id);
        Task<Response> InactiveAsync(int id);
        Task<Response> ActiveAsync(int id);
    }
}
