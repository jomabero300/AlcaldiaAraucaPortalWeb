using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile proFile, string folder);
        Task<string> UploadImageMenulAsync(IFormFile proFile, string folder);
        Task<string> UploadFileAsync(IFormFile proFile, string folder);
        Task<string> DeleteImageAsync(string file, string folder);
        string DeleteImageAsync(string file);
        List<CarouselModelView> ImageDirectory(string foldr, string search);
    }
}
