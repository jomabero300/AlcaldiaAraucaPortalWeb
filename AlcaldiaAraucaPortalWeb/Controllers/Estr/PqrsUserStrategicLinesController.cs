using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Controllers.Estr
{
    public class PqrsUserStrategicLinesController : Controller
    {
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLineHelper;
        private readonly IPqrsUserStrategicLineHelper _pqrsUserStrategicLineHelper;
        private readonly IStateHelper _stateHelper;
        private readonly IUserHelper _userHelper;

        public PqrsUserStrategicLinesController(IPqrsUserStrategicLineHelper pqrsUserStrategicLineHelper, IUserHelper userHelper, IPqrsStrategicLineHelper pqrsStrategicLineHelper, IStateHelper stateHelper)
        {
            _pqrsUserStrategicLineHelper = pqrsUserStrategicLineHelper;
            _userHelper = userHelper;
            _pqrsStrategicLineHelper = pqrsStrategicLineHelper;
            _stateHelper = stateHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pqrsUserStrategicLineHelper.ListAsync());
        }

        // GET: PqrsUserStrategicLines/Create
        public async Task<IActionResult> Create()
        {

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument");
            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName");

            int stateId = await _stateHelper.StateIdAsync("G", "Activo");

            PqrsUserStrategicLine line = new PqrsUserStrategicLine { StateId = stateId };

            return View(line);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PqrsUserStrategicLineId,UserId,PqrsStrategicLineId,StateId")] PqrsUserStrategicLine model)
        {
            if (ModelState.IsValid)
            {
                Response response = await _pqrsUserStrategicLineHelper.AddUpdateAsync(model);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            string[] lv = { "Activo", "Inactivo" };

            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", model.StateId);

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument", model.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsStrategicLineHelper.PqrsStrategicLineComboAsync(), "PqrsStrategicLineId", "PqrsStrategicLineName", model.PqrsStrategicLineId);

            return View(model);
        }

        // GET: PqrsUserStrategicLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PqrsUserStrategicLine pqrsUserStrategicLine = await _pqrsUserStrategicLineHelper.ByIdAsync((int)id);

            if (pqrsUserStrategicLine == null)
            {
                return NotFound();
            }

            string[] lv = { "Activo", "Inactivo" };
            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", pqrsUserStrategicLine.StateId);

            ViewData["UserId"] = new SelectList(await _userHelper.UsersComboAsync(), "Id", "FullNameWithDocument", pqrsUserStrategicLine.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsUserStrategicLineHelper.PqrsStrategicLineAsync(pqrsUserStrategicLine.UserId), "PqrsStrategicLineId", "PqrsStrategicLineName", pqrsUserStrategicLine.PqrsStrategicLineId);


            return View(pqrsUserStrategicLine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PqrsUserStrategicLineId,UserId,PqrsStrategicLineId,StateId")] PqrsUserStrategicLine model)
        {
            if (id != model.PqrsUserStrategicLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Response response = await _pqrsUserStrategicLineHelper.AddUpdateAsync(model);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            string[] lv = { "Activo", "Inactivo" };

            ViewData["StateId"] = new SelectList(await _stateHelper.StateAsync("G", lv), "StateId", "StateName", model.StateId);

            ViewData["UserId"] = new SelectList(await _userHelper.ListAsync(), "Id", "FullName", model.UserId);

            ViewData["PqrsStrategicLineId"] = new SelectList(await _pqrsUserStrategicLineHelper.PqrsStrategicLineAsync(model.UserId), "PqrsStrategicLineId", "PqrsStrategicLineName", model.PqrsStrategicLineId);

            return View(model);
        }

        //GET: PqrsUserStrategicLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PqrsUserStrategicLine pqrsUserStrategicLine = await _pqrsUserStrategicLineHelper.ByIdAsync((int)id);

            if (pqrsUserStrategicLine == null)
            {
                return NotFound();
            }

            return View(pqrsUserStrategicLine);
        }

        // POST: PqrsUserStrategicLines/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Response response = await _pqrsUserStrategicLineHelper.DeleteAsync(id);

            //if(response.Succeeded)
            //{
            //    return Json(new { status = true });
            //}

            //return Json(new { status = false, message=response.Message });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> LineaAtrategicSearch(string userId)
        {
            var lista = await _pqrsUserStrategicLineHelper.PqrsStrategicLineBIdAsync(userId);

            return Json(lista);
        }
    }
}
