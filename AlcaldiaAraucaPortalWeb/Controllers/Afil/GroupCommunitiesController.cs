using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Controllers.Afil
{
    [Authorize(Roles = nameof(UserType.Administrador))]
    public class GroupCommunitiesController : Controller
    {
        private readonly IGroupCommunityHelper _groupCommnuty;
        private readonly IStateHelper _stateHelper;

        public GroupCommunitiesController(IStateHelper stateHelper, IGroupCommunityHelper groupCommnuty)
        {
            _stateHelper = stateHelper;
            _groupCommnuty = groupCommnuty;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _groupCommnuty.ListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _groupCommnuty.ByIdAsync((int)id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new GroupCommunity()
            {
                StateId = await _stateHelper.StateIdAsync("G", "Activo")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupCommunityId,GroupCommunityName,StateId")] GroupCommunity model)
        {
            if (ModelState.IsValid)
            {
                var response = await _groupCommnuty.AddUpdateAsync(model);

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

            var model = await _groupCommnuty.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            ViewData["StateId"] = new SelectList(await _stateHelper.StateComboAsync("G"), "StateId", "StateName", model.StateId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupCommunityId,GroupCommunityName,StateId")] GroupCommunity model)
        {
            if (id != model.GroupCommunityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var responde = await _groupCommnuty.AddUpdateAsync(model);

                if (responde.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, responde.Message);
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

            var model = await _groupCommnuty.ByIdAsync((int)id);

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
            var response = await _groupCommnuty.DeleteAsync(id);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = await _groupCommnuty.ByIdAsync(id);

            ModelState.AddModelError(string.Empty, response.Message);

            return View(model);
        }
    }
}
