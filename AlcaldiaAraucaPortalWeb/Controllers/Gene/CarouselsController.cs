using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Mvc;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class CarouselsController : Controller
    {
        private const string _searchFile = "Imagen0*";
        private readonly IImageHelper _imageHelper;

        public CarouselsController(IImageHelper imageHelper)
        {
            _imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            List<CarouselModelView> model = _imageHelper.ImageDirectory("Image", _searchFile);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarouselImage model)
        {
            if (ModelState.IsValid)
            {
                string response = await _imageHelper.UploadImageMenulAsync(model.Image, "Image");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            CarouselModelView model = new CarouselModelView() { ImageName = id };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(CarouselModelView model)
        {
            if (model.ImageName.Trim() != "")
            {
                string response = _imageHelper.DeleteImageAsync(model.ImageName);
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
