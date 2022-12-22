using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlcaldiaAraucaPortalWeb.Controllers.Afil
{
    [Authorize(Roles = nameof(UserType.Administrador))]

    public class SocialNetworksController : Controller
    {
        private readonly ISocialNetworkHelper _socialNetworkHelper;
        private readonly IStateHelper _stateHelper;

        public SocialNetworksController(IStateHelper stateHelper, ISocialNetworkHelper socialNetworkHelper)
        {
            _stateHelper = stateHelper;
            _socialNetworkHelper = socialNetworkHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _socialNetworkHelper.ListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SocialNetwork model = await _socialNetworkHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            SocialNetwork model = new SocialNetwork()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialNetworkId,SocialNetworkName,StateId")] SocialNetwork model)
        {
            if (ModelState.IsValid)
            {
                Response response = await _socialNetworkHelper.AddUpdateAsync(model);

                if(response.Succeeded)
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

            SocialNetwork model = await _socialNetworkHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialNetworkId,SocialNetworkName,StateId")] SocialNetwork model)
        {
            if (id != model.SocialNetworkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Response response = await _socialNetworkHelper.AddUpdateAsync(model);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SocialNetwork model = await _socialNetworkHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Response response = await _socialNetworkHelper.DeleteAsync(id);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty,response.Message);

            SocialNetwork model = await _socialNetworkHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
