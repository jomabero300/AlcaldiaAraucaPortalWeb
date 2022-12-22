using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Helpers.Pdf;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Controllers.Repo
{
    public class ReportsController : Controller
    {
        private readonly IPdfDocumentHelper _pdfDocumentHelper;
        private readonly IProfessionHelper _professionHelper;
        private readonly IGroupProductiveHelper _groupProductiveHelper;
        private readonly IGroupCommunityHelper _groupCommunityHelper;
        private readonly ISocialNetworkHelper _networkHelper;
        private readonly IUserHelper _userHelper;

        public ReportsController(
            IProfessionHelper professionHelper,
            IPdfDocumentHelper pdfDocumentHelper,
            IGroupProductiveHelper groupProductiveHelper,
            IGroupCommunityHelper groupCommunityHelper,
            ISocialNetworkHelper networkHelper,
            IUserHelper userHelper)
        {
            _professionHelper = professionHelper;
            _pdfDocumentHelper = pdfDocumentHelper;
            _groupProductiveHelper = groupProductiveHelper;
            _groupCommunityHelper = groupCommunityHelper;
            _networkHelper = networkHelper;
            _userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> AffiliateProfessions()
        {
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(null, false), "ProfessionId", "ProfessionName");

            return View();
        }

        [HttpPost, ActionName("AffiliateProfessions")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateProfessionGenerate(StatisticsViewModel model)
        {
            MemoryStream ms = await _pdfDocumentHelper.StatisticsAsync(model.Id, "Profesión");

            return File(ms.ToArray(), "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> AffiliateGrupoProductivo()
        {
            ViewData["GroupProductiveId"] = new SelectList(await _groupProductiveHelper.ComboAsync(null, false), "GroupProductiveId", "GroupProductiveName");

            return View();
        }

        [HttpPost, ActionName("AffiliateGrupoProductivo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateGrupoProductivoGenerate(StatisticsViewModel model)
        {
            MemoryStream ms = await _pdfDocumentHelper.StatisticsAsync(model.Id, "Grupo productivo");

            return File(ms.ToArray(), "application/pdf");

        }

        [HttpGet]
        public async Task<IActionResult> AffiliateGrupoComunitario()
        {
            ViewData["GroupCommunityId"] = new SelectList(await _groupCommunityHelper.ComboAsync(null, false), "GroupCommunityId", "GroupCommunityName");

            return View();
        }

        [HttpPost, ActionName("AffiliateGrupoComunitario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateGrupoComunitarioGenerate(StatisticsViewModel model)
        {
            MemoryStream ms = await _pdfDocumentHelper.StatisticsAsync(model.Id, "Grupo comunitario");

            return File(ms.ToArray(), "application/pdf");

        }
        [HttpGet]
        public async Task<IActionResult> AffiliateSocialNetwork()
        {
            ViewData["SocialNetworkId"] = new SelectList(await _networkHelper.ComboAsync(null, false), "SocialNetworkId", "SocialNetworkName");

            return View();
        }
        [HttpPost, ActionName("AffiliateSocialNetwork")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AffiliateSocialNetworkRdlcGenerate(StatisticsViewModel model)
        {
            MemoryStream ms = await _pdfDocumentHelper.StatisticsAsync(model.Id, "Red social");

            return File(ms.ToArray(), "application/pdf");
        }

        [HttpGet]
        public async Task<IActionResult> UserRdlc()
        {
            ViewData["Id"] = new SelectList(await _userHelper.ComboRolesAsync(), "Id", "Name");

            return View();
        }

        [HttpPost, ActionName("UserRdlc")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRdlcGenerate(StatisticsViewModel model)
        {
            MemoryStream ms = await _pdfDocumentHelper.StatisticsAsync(model.Id, "Usiarios registrados", model.idOp);

            return File(ms.ToArray(), "application/pdf");
        }
    }
}
