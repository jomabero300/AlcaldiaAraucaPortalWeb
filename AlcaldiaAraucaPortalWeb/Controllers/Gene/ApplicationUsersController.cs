using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Controllers.Gene
{
    public class ApplicationUsersController : Controller
    {
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;
        private readonly IUserHelper _userHelper;

        public ApplicationUsersController(ICommuneTownshipHelper communeTownship, INeighborhoodSidewalkHelper neighborhoodSidewalk, IUserHelper userHelper)
        {
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
            _userHelper = userHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userHelper.GetRoleUserAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleUserModelView model = await _userHelper.GetRoleUserAsync(id);

            return View(model);
        }
        [Authorize(Roles = nameof(UserType.Administrador))]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleUserModelView model = await _userHelper.GetRoleUserAsync(id);

            ViewData["RoleId"] = new SelectList(await _userHelper.GetRoleAsync(), "Id", "Name", model.RoleId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,FullName,RoleId")] RoleUserModelView model)
        {
            if (id != model.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Response response=await _userHelper.RemoveRoleUserAsync(model.UserId,model.RoleId);
                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["RoleId"] = new SelectList(await _userHelper.GetRoleAsync(), "Id", "Name", model.RoleId);

            return View(model);
        }
        [Authorize(Roles = nameof(UserType.Administrador))]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleUserModelView model = await _userHelper.GetRoleUserAsync(id);

            return View(model);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Response response = await _userHelper.DeleteUserAsync(id);
            if(response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            RoleUserModelView model = await _userHelper.GetRoleUserAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CommuneTownshipSearch(int ZoneId)
        {
            List<CommuneTownship> lista = await _communeTownship.ComboAsync(ZoneId);

            return Json(lista);
        }

        [HttpPost]
        public async Task<IActionResult> NeighborhoodSidewalkSearch(int CommuneTownshipId)
        {
            List<NeighborhoodSidewalk> lista = await _neighborhoodSidewalk.ComboAsync(CommuneTownshipId);

            return Json(lista);
        }
    }
}
