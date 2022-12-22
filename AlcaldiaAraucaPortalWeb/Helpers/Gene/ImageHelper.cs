using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public ImageHelper(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        public async Task<string> DeleteImageAsync(string file, string folder)
        {
            int start = file.LastIndexOf("/") + 1;

            var file2 = file.Substring(start, file.Length - start);

            file2 = Path.Combine(_env.WebRootPath, folder, file2);

            if (System.IO.File.Exists(file2))
            {
                FileInfo fi = new FileInfo(file2);

                if (fi != null)
                {
                    System.IO.File.Delete(file2);
                    fi.Delete();
                }
            }

            return await Task.FromResult("Ok");
        }

        public string DeleteImageAsync(string file)
        {
            string file2 = Path.Combine(_env.WebRootPath, "Image", file);

            if (System.IO.File.Exists(file2))
            {
                FileInfo fi = new FileInfo(file2);

                if (fi != null)
                {
                    System.IO.File.Delete(file2);
                    fi.Delete();
                }
            }

            return "Ok";
        }

        public List<CarouselModelView> ImageDirectory(string foldr, string search)
        {
            List<CarouselModelView> model = new List<CarouselModelView>();

            string path = Path.Combine(_env.WebRootPath, foldr);

            DirectoryInfo di = new DirectoryInfo(path);

            foreach (var item in di.GetFiles(search))
            {
                model.Add(new CarouselModelView { ImageName = item.Name });
            }

            return model;
        }

        public async Task<string> UploadFileAsync(IFormFile proFile, string folder)
        {
            var filePath = String.Empty;
            var FileName = string.Empty;
            var url = _configuration["MyDomain:Url"];
            if (proFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, folder);
                folder = folder.Replace('\\', '/');

                FileName = Guid.NewGuid().ToString() + ".pdf";

                filePath = Path.Combine(uploadsFolder, FileName);

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await proFile.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    filePath = ex.Message;
                }
            }

            return $"{url}{folder}/{FileName}";
        }

        public async Task<string> UploadImageAsync(IFormFile proFile, string folder)
        {
            string fileName = await UploadImage(proFile, folder);

            return fileName;
        }

        public async Task<string> UploadImageMenulAsync(IFormFile proFile, string folder)
        {
            string fileName = "Imagen01";

            List<CarouselModelView> file = ImageDirectory(folder, "Imagen0*");
            
            if (file.Count() > 0)
            {
                fileName = file.Last().ImageName;
                int start = fileName.LastIndexOf(".") - 2;
                var file2 = fileName.Substring(start, 2);
                start = int.Parse(file2) + 1;
                file2 = start.ToString("00");
                fileName = $"Imagen{file2}.png";
            }

            string FileName = await UploadImage(proFile, folder, fileName);

            return FileName;
        }

        private async Task<string> UploadImage(IFormFile ProFile, string Folder, string fileName = "")
        {
            string FileName = string.Empty;
            string url = _configuration["MyDomain:Url"];

            string[] exten = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tiff" };

            if (ProFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, Folder);
                Folder = Folder.Replace('\\', '/');

                string FileExt = Path.GetExtension(ProFile.FileName);
                int respue = Array.IndexOf(exten, FileExt);

                if (respue > -1)
                {
                    FileExt = ".png";
                }
                else
                {
                    FileExt = ".pdf";
                }

                FileName = fileName.Trim() == "" ? (Guid.NewGuid().ToString() + FileExt) : fileName.Trim();

                string filePath = Path.Combine(uploadsFolder, FileName);

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ProFile.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    filePath = ex.Message;
                }
            }

            return $"{url}{Folder}/{FileName}";
        }

    }
}
