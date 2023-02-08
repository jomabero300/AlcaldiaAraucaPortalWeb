using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace AlcaldiaAraucaPortalWeb.Controllers.Afil
{
    [Authorize(Roles = nameof(UserType.Administrador))]

    public class ProfessionsController : Controller
    {
        private readonly IStateHelper _stateHelper;
        private readonly IProfessionHelper _professionHelper;

        public ProfessionsController(IProfessionHelper professionHelper, IStateHelper stateHelper)
        {
            _professionHelper = professionHelper;
            _stateHelper = stateHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _professionHelper.ListAsync());
            //return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        public async Task<IActionResult> Create()
        {
            var model = new Profession()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfessionId,ProfessionName,StateId")] Profession model)
        {
            if (ModelState.IsValid)
            {
                var response = await _professionHelper.AddUpdateAsync(model);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", profession.StateId);

            return View(profession);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfessionId,ProfessionName,StateId")] Profession model)
        {
            if (id != model.ProfessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _professionHelper.AddUpdateAsync(model);
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

            var profession = await _professionHelper.ByIdAsync((int)id);

            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respose = await _professionHelper.DeleteAsync((int)id);
            if (respose.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, respose.Message);
            var model = await _professionHelper.ByIdAsync((int)id);
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> ListProfesiona()
        {

            //Representa el numero de veces que se ha realizado una petición
            int PetitionCant = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");

            //Cantidad de registro va ha devolver
            int RowsCant = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");

            //cuantos registros va ha omitir
            int OmitCant = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            string SearchText = Request.Form["search[value]"].FirstOrDefault() ?? "";

            AffiliateProfessionViewModelsProcFilter professions = await _professionHelper.ListAsync(RowsCant, OmitCant, SearchText);
             
            return Json(new { 
                draw = PetitionCant,
                recordsTotal= RowsCant,
                recordsFiltered= professions.RowsFilterTotal,
                data = professions.Professions });

        }
    }
}
