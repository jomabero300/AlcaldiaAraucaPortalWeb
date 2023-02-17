using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AlcaldiaAraucaPortalWeb.Controllers.Afil
{
    [Authorize(Roles = nameof(UserType.Administrador))]
    public class GroupProductivesController : Controller
    {
        private readonly IGroupProductiveHelper _groupProductive;
        private readonly IStateHelper _stateHelper;

        public GroupProductivesController(IStateHelper stateHelper, IGroupProductiveHelper groupProductive)
        {
            _stateHelper = stateHelper;
            _groupProductive = groupProductive;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _groupProductive.ListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            return View(groupProductive);
        }

        public async Task<IActionResult> Create()
        {
            var model = new GroupProductive()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupProductiveId,GroupProductiveName,StateId")] GroupProductive model)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _groupProductive.AddUpdateAsync(model);

                if (reponse.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, reponse.Message);
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", groupProductive.StateId);

            return View(groupProductive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupProductiveId,GroupProductiveName,StateId")] GroupProductive model)
        {
            if (id != model.GroupProductiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _groupProductive.AddUpdateAsync(model);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupProductive = await _groupProductive.ByIdAsync((int)id);

            if (groupProductive == null)
            {
                return NotFound();
            }

            return View(groupProductive);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _groupProductive.DeleteAsync(id);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, response.Message);

            return View(response);
        }

        public async Task<JsonResult> ListGene()
        {

            //Representa el numero de veces que se ha realizado una petición
            int PetitionCant = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");

            //Cantidad de registro va ha devolver
            int RowsCant = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");

            //cuantos registros va ha omitir
            int OmitCant = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            string SearchText = Request.Form["search[value]"].FirstOrDefault() ?? "";

            AffiliateGroupProductiveViewModelsFilter model = await _groupProductive.ListAsync(RowsCant, OmitCant, SearchText);

            return Json(new
            {
                draw = PetitionCant,
                recordsTotal = RowsCant,
                recordsFiltered = model.RowsFilterTotal,
                data = model.GroupProductives
            });
        }
    }
}
