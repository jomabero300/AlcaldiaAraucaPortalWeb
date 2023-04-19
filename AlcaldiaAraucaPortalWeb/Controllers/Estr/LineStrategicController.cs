using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Cont;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace AlcaldiaAraucaPortalWeb.Controllers.Estr
{
    public class LineStrategicController : Controller
    {
        private readonly IPqrsStrategicLineHelper _pqrsStrategicLine;
        private readonly IPqrsStrategicLineSectorHelper _lineSectorHelper;
        private readonly IContentOdsHelper _contentOdsHelper;
        private readonly IContentHelper _contentHelper;
        private readonly IAffiliateHelper _affiliateHelper;

        public LineStrategicController(
            IPqrsStrategicLineHelper pqrsStrategicLine,
            IPqrsStrategicLineSectorHelper lineSectorHelper,
            IContentOdsHelper contentOdsHelper,
            IContentHelper contentHelper,
            IAffiliateHelper affiliateHelper)
        {
            _pqrsStrategicLine = pqrsStrategicLine;
            _lineSectorHelper = lineSectorHelper;
            _contentOdsHelper = contentOdsHelper;
            _contentHelper = contentHelper;
            _affiliateHelper = affiliateHelper;
        }


        #region Desarrollo social

        public IActionResult Cultura()
        {
            string StrategicLine = "Desarrollo social incluyente";

            return RedirectToAction("GeneView", new { lTipo = "Cultura", tituloHead = $"{StrategicLine} - Cultura", LineaStrategica = StrategicLine });

        }
        public IActionResult Deporte()
        {
            string StrategicLine = "Desarrollo social incluyente";

            return RedirectToAction("GeneView", new { lTipo = "Deporte", tituloHead = $"{StrategicLine} - Deporte", LineaStrategica = StrategicLine });
        }
        public IActionResult Educacion()
        {
            string StrategicLine = "Desarrollo social incluyente";

            return RedirectToAction("GeneView", new { lTipo = "Educación", tituloHead = $"{StrategicLine} - Educación", LineaStrategica = StrategicLine });
        }
        public IActionResult InclusionSocial()
        {
            string StrategicLine = "Desarrollo social incluyente";

            return RedirectToAction("GeneView", new { lTipo = "Inclusión social", tituloHead= $"{StrategicLine} - Inclusión social", LineaStrategica = StrategicLine });
        }
        public IActionResult SaludyProteccion()
        {
            string StrategicLine = "Desarrollo social incluyente";

            return RedirectToAction("GeneView", new { lTipo = "Salud y protección", tituloHead = $"{StrategicLine} - Salud y protección social", LineaStrategica = StrategicLine });
        }
        public IActionResult DesarrolloSocialNormatividad()
        {
            string StrategicLine = "Desarrollo social incluyente";
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });

            //return RedirectToAction("GeneViewHorizontal", new { lTipo = "Normatividad", tituloHead= $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }
        #endregion

        #region Crecimiento economico
        public IActionResult AgriculturaDesarrolloRural()
        {
            string StrategicLine = "Crecimiento económico";

            return RedirectToAction("GeneView", new { lTipo = "Agricultura y desarrollo rural", tituloHead = $"{StrategicLine} - Agricultura y Desarrollo Rural", LineaStrategica =StrategicLine });
        }
        public IActionResult CienciaTecnologiaInnovacion()
        {
            string StrategicLine = "Crecimiento económico";

            return RedirectToAction("GeneView", new { lTipo = "Ciencia, tecnología e innovación", tituloHead = $"{StrategicLine} - Ciencia y Tecnología Innovación", LineaStrategica = StrategicLine });
        }
        public IActionResult Trabajo()
        {
            string StrategicLine = "Crecimiento económico";

            return RedirectToAction("GeneView", new { lTipo = "Trabajo", tituloHead = $"{StrategicLine} - Trabajo", LineaStrategica = StrategicLine });
        }
        public IActionResult ComercionIndustriaTurismo()
        {
            string StrategicLine = "Crecimiento económico";

            return RedirectToAction("GeneView", new { lTipo = "Comercio, industria y turismo", tituloHead = $"{StrategicLine} - Comercio Industria y Turismo", LineaStrategica = StrategicLine });
        }
        public IActionResult CrecimientoEconomicoNormatividad()
        {
            string StrategicLine = "Crecimiento económico";

            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }

        #endregion

        #region Arauca Verde, Ordenaday Sostenible
        public IActionResult AmbienteyDesarrolloSostenible()
        {
            string StrategicLine = "Arauca verde, ordenada y sostenible";

            return RedirectToAction("GeneView", new { lTipo = "Ambiente desarrollo sostenible", tituloHead = $"{StrategicLine} - Ambiente y desarrollo sostenible", LineaStrategica = StrategicLine });
        }
        public IActionResult AtencionDesastre()
        {
            string StrategicLine = "Arauca verde, ordenada y sostenible";

            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial - Atención a desastres", tituloHead = $"{StrategicLine} - Gobierno territorial - Atención a desastres", LineaStrategica = StrategicLine });
        }
        public IActionResult AraucaVedeOrdenadaSostenibleNormatividad()
        {
            string StrategicLine = "Arauca verde, ordenada y sostenible";

            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }
        #endregion

        #region Infraestrutura Social y Productiva
        public IActionResult Transporte()
        {

            string StrategicLine = "Infraestructura social y productiva";

            return RedirectToAction("GeneView", new { lTipo = "Transporte", tituloHead = $"{StrategicLine} - Transporte", LineaStrategica=StrategicLine });
        }
        public IActionResult MinasyEnergia()
        {
            string StrategicLine = "Infraestructura social y productiva";

            return RedirectToAction("GeneView", new { lTipo = "Minas y energía", tituloHead = $"{StrategicLine} - Minas y energía", LineaStrategica = StrategicLine });
        }
        public IActionResult ViviendaInfra()
        {
            string StrategicLine = "Infraestructura social y productiva";

            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = $"{StrategicLine} - Vivienda", LineaStrategica = StrategicLine });
        }
        public IActionResult InfraestructuraSocialProductivaNormatividad()
        {
            string StrategicLine = "Infraestructura social y productiva";
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }
        #endregion

        #region Buen gobierno
        public IActionResult InformacionEstadistica()
        {
            string StrategicLine ="Buen gobierno";

            return RedirectToAction("GeneView", new { lTipo = "Información estadisiticas", tituloHead = $"{StrategicLine} - Información estadisiticas", LineaStrategica = StrategicLine });
        }
        public IActionResult BuenGobiernoTerritorial()
        {
            string StrategicLine = "Buen gobierno";
            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial", tituloHead = $"{StrategicLine} - Gobierno territorial", LineaStrategica = StrategicLine });
        }
        public IActionResult Tecnologia()
        {
            string StrategicLine = "Buen gobierno";
            return RedirectToAction("GeneView", new { lTipo = "Tecnologioas de la información y las comunicaciones", tituloHead = $"{StrategicLine} - Tecnologioas de la información y las comunicaciones", LineaStrategica = StrategicLine });
        }
        public IActionResult ViviendaBuen()
        {
            string StrategicLine = "Buen gobierno";
            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = $"{StrategicLine} - Vivienda", LineaStrategica = StrategicLine });
        }
        public IActionResult BuenGobiernoNormatividad()
        {
            string StrategicLine = "Buen gobierno";
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }
        #endregion

         #region Seguridad, Convivencia y Justicia
        public IActionResult JusticiaDerecho()
        {
            string StrategicLine ="Seguridad convivencia y justicia";

            return RedirectToAction("GeneView", new { lTipo = "Justicia y derecho", tituloHead = $"{StrategicLine} - Justicia y derecho", LineaStrategica=StrategicLine });
        }
        public IActionResult InclusionSocial2()
        {
            string StrategicLine = "Seguridad convivencia y justicia";
            return RedirectToAction("GeneView", new { lTipo = "Inclusion social", tituloHead = $"{StrategicLine} - Inclusion social", LineaStrategica = StrategicLine });
        }
        public IActionResult GobiernoTerritorial()
        {
            string StrategicLine = "Seguridad convivencia y justicia";
            return RedirectToAction("GeneView", new { lTipo = "Gobierno territorial", tituloHead = $"{StrategicLine} - Gobierno territorial", LineaStrategica = StrategicLine });
        }
        public IActionResult ViviendaSeguridad()
        {
            string StrategicLine = "Seguridad convivencia y justicia";
            return RedirectToAction("GeneView", new { lTipo = "Vivienda", tituloHead = $"{StrategicLine} - Vivienda", LineaStrategica = StrategicLine });
        }
        public IActionResult SeguridadConvivenciaJusticiaNormatividad()
        {
            string StrategicLine = "Seguridad convivencia y justicia";
            return RedirectToAction("GeneView", new { lTipo = "Normatividad", tituloHead = $"{StrategicLine} - Normatividad", LineaStrategica = StrategicLine });
        }
        #endregion

        #region Gestion del conocimiento
        public async Task< IActionResult> GestionConocimiento()
        {
            List<ContentModelView> model = new List<ContentModelView>();

            int codigo = await StrategicLine("Gestión del conocimiento");

            var sectorId = await _lineSectorHelper.ByNameAsync("Gestión del conocimiento", codigo);

            if (sectorId != null)
            {
                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);
                model = Contenido.Select(x => new ContentModelView { title = x.ContentTitle, text = x.ContentText, img = x.ContentUrlImg, url = x.ContentId.ToString() }).ToList();
            }

            return View(model);
        }
        public IActionResult GestionConocimientoNormatividad()
        {
            return RedirectToAction("GeneView1", new { lTipo = "11", tituloHead = "Normatividad", subTituloHead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" });
        }
        #endregion

        #region P.Q.R.S
        public IActionResult Pqrs()
        {
            return RedirectToAction("Index", "Pqrs");
        }
        public IActionResult PropuestaDetallada()
        {
            return RedirectToAction("Index", "PqrsProjects");
        }
        public IActionResult PqrsNormatividad()
        {
            return RedirectToAction("GeneView1", new { lTipo = "11", tituloHead = "Normatividad", subTituloHead = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" });
        }
        #endregion

        #region Ingresar / Registrarse
        public IActionResult Ingresar()
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }
        public IActionResult Registrarse()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }
        public IActionResult ForgoPassword()
        {
            return RedirectToPage("/Account/ForgotPassword", new { area = "Identity" });
        }

        #endregion

        public async Task<IActionResult> GeneViewHorizontal(string lTipo, string tituloHead, int PqrsStrategicLineId, string OdsText, string OdsImag, string ODSUrl)
        {
            ContentGeneViewModels model = new ContentGeneViewModels();
            ViewBag.TituloHead2 = tituloHead;
            var sectorId = await _lineSectorHelper.ByNameAsync(lTipo, PqrsStrategicLineId);
            if (sectorId != null)
            {
                var ods = await _contentOdsHelper.ByIdAsync(sectorId.PqrsStrategicLineSectorId);
                if (ods != null)
                {
                    model.ContentOds = ods.Select(o => new ContentOds()
                    {
                        ContentOdsText = o.ContentOdsText,
                        ContentOdsImg = o.ContentOdsImg,
                        ContentOdsUrl = o.ContentOdsUrl
                    }).ToList();
                    //foreach (var item in ods)
                    //{
                    //    model.ContentOds.Add(new ContentOds { ContentOdsText = item.ContentOdsText, ContentOdsImg = item.ContentOdsImg, ContentOdsUrl = item.ContentOdsUrl });
                    //}
                }
                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);

                if (Contenido != null)
                {
                    int lnCont = 0;

                    foreach (var item in Contenido)
                    {
                        if (lnCont == 0)
                        {
                            ViewBag.TituloHead = item.ContentTitle.ToUpper();
                            ViewBag.SubTituloHead = getLinks(item.ContentText);
                            ViewBag.RulImagen = item.ContentUrlImg;
                            ViewBag.Url = item.ContentId;
                        }
                        else
                        {
                            model.Contents.Add(new ContentModelView() { title = item.ContentTitle.ToUpper(), text = item.ContentText, img = item.ContentUrlImg, url = item.ContentId.ToString() });
                        }
                        lnCont++;
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> GeneView(string lTipo, string tituloHead, string subTituloHead, string LineaStrategica)
        {
            var model = new ContentGeneViewModels();

            ViewBag.TituloHead = tituloHead;

            ViewBag.SubTituloHead = subTituloHead;

            int PqrsStrategicLineId = await StrategicLine(LineaStrategica);

            var sectorId = await _lineSectorHelper.ByNameAsync(lTipo, PqrsStrategicLineId);

            if (sectorId != null)
            {
                var ods = await _contentOdsHelper.ByIdAsync(sectorId.PqrsStrategicLineSectorId);
                if (ods != null)
                {
                    foreach (var item in ods)
                    {
                        model.ContentOds.Add(new ContentOds { ContentOdsText = item.ContentOdsText, ContentOdsImg = item.ContentOdsImg, ContentOdsUrl = item.ContentOdsUrl });
                    }
                }

                var Contenido = await _contentHelper.ListAsync(sectorId.PqrsStrategicLineSectorId);

                foreach (var item in Contenido)
                {
                    model.Contents.Add(new ContentModelView() { title = item.ContentTitle.ToUpper(), text = item.ContentText, img = item.ContentUrlImg, url = item.ContentId.ToString() });
                }
            }

            return View(model);
        }

        public async Task<IActionResult> GeneViewHorizontalDetails(int id)
        {
            List<ContentDetail> model = await _contentHelper.ListDetailsAsync(id);

            //string xx =await _lineSectorHelper.ByLineaSector(id);
            ViewBag.TituloHead =await _lineSectorHelper.ByLineaSector(id);

            return View(model);
        }

        public async Task<IActionResult> PerfilDetail(int id)
        {
            Affiliate model =await _affiliateHelper.AffiliateByIdAsync(id);
            model.TypeUserId = model.TypeUserId == "P" ? "Persona" : "Empresa";
            return View(model);
        }

        private dynamic getLinks(string text)
        {
            String pattern;
            pattern = @"(http:\/\/([\w.]+\/?)\S*)";
            Regex re = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            text = re.Replace(text, "<a href=\"$1\" target=\"_blank\">$1</a>");
            return text;
        }

        private async Task<int> StrategicLine(string name)
        {
            var model = await _pqrsStrategicLine.ByNameAsync(name);

            return model.PqrsStrategicLineId;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
