using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    [Authorize(Roles = nameof(UserType.Administrador))]

    public class GendersController : Controller
    {
        private readonly IGenderHelper _genderHelper;

        public GendersController(IGenderHelper genderHelper)
        {
            _genderHelper = genderHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _genderHelper.ListAsync());
        }
        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender model = await _genderHelper.ByIdAsync((int)id);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderId,GenderName")] Gender model)
        {
            if (ModelState.IsValid)
            {
                Response response = await _genderHelper.AddUpdateAsync(model);

                ModelState.AddModelError(string.Empty, response.Message);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender model = await _genderHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderId,GenderName")] Gender model)
        {
            if (id != model.GenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Response response = await _genderHelper.AddUpdateAsync(model);

                ModelState.AddModelError(string.Empty, response.Message);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gender model = await _genderHelper.ByIdAsync((int)id);

            return View(model);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Response response = await _genderHelper.DeleteAsync(id);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, response.Message);

            return RedirectToAction(nameof(Index));
        }

    }
}
