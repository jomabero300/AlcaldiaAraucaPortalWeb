using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helpers.Cont;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Mvc;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class SearchsController : Controller
    {
        private readonly IContentHelper _contentHelper;

        public SearchsController(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearcheViewModel model)
        {
            return RedirectToAction(nameof(Search), new { filter = model.Search.ToUpper() });
        }

        public async Task<IActionResult> Search(string filter)
        {
            List<FilterViewModel> model = await _contentHelper.ListTitleAsync(filter);

            return View(model);
        }
    }
}
