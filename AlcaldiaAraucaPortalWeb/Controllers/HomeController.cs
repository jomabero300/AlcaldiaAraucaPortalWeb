using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace AlcaldiaAraucaPortalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageHelper _imageHelper;

        public HomeController(ILogger<HomeController> logger, IImageHelper imageHelper)
        {
            _logger = logger;
            _imageHelper = imageHelper;
        }

        public IActionResult Index()
        {
            //publicSend();

            List<CarouselModelView> cont = _imageHelper.ImageDirectory("Image", "Imagen0*");
            List<ContentModelView> content = new List<ContentModelView>()
            {
                new ContentModelView(){
                    url="1",
                    img="~/Image/Menu/Menu1.png",
                    title="Desarrollo Social Incluyente",
                    text="Para garantizar las condiciones de igualdad de oportunidades e inclusión social para todos."
                },
                new ContentModelView(){
                    url="2",
                    img="~/Image/Menu/Menu2.png",
                    title="Crecimiento Económico",
                    text="Obteniendo el incremento de la economía de los habitantes del municipio."
                },
                new ContentModelView(){
                    url="3",
                    img="~/Image/Menu/Menu3.png",
                    title="Arauca Verde, Ordenada y Sostenible",
                    text="Por un territorio resiliente hacia al goce de ambiente sano y sostenible."
                },
                new ContentModelView(){
                    url="4",
                    img="~/Image/Menu/Menu4.png",
                    title="Infraestructura Social y Productiva",
                    text="Accionar en proyectos de infraestructura social para generar oportunidades."
                },
                new ContentModelView(){
                    url="5",
                    img="~/Image/Menu/Menu5.png",
                    title="Buen Gobierno",
                    text="Enfocado a las indispensables áreas de Gobierno Territorial, Información Estadística, TICs y Vivienda"
                },
                new ContentModelView(){
                    url="6",
                    img="~/Image/Menu/Menu6.png",
                    title="Seguridad, Convivencia y Justicia.",
                    text="Por un territorio donde sus habitantes mantengan relaciones de convivencia."
                },
                new ContentModelView(){
                    url="7",
                    img="~/Image/Menu/Menu7.png",
                    title="Gestión de Conocimiento",
                    text="La gestión del conocimiento y la innovación implican administrar el conocimiento tácito"
                },
                //new ContentModelView(){
                //    url="8",
                //    img="~/Image/Menu/Menu8.png",
                //    title="P.Q.R.S.",
                //    text="Peticiones, Quejas, Reclamos, Sugerencias, Denuncias, Felicitaciones, Propuestas y un completo submódulo de Propuestas Detalladas"
                //},
                new ContentModelView(){
                    url="9",
                    img="~/Image/Menu/Menu9.png",
                    title="Ingresar / Registrarse.",
                    text="Para que el ciudadano se registre en el portal web y participe de publicar su información personal, de su negocio o actividad productiva"
                },

            };

            CarouselModelViewList model = new CarouselModelViewList()
            {
                contents = content.Select(c => new ContentModelView()
                {
                    img = c.img,
                    text = c.text,
                    title = c.title,
                    url = c.url
                }).ToList(),
                carousels = cont.Select(c => new CarouselModelView() { ImageName = c.ImageName }).ToList()

            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Menu(string id)
        {
            var model = new List<Models.Gene.ContentModelView>();

            if (id == "1")
            {
                ViewBag.Mensaje = "Desarrollo Social Incluyente";
                ViewBag.SubMensaje = "Tiene como objetivo garantizar las condiciones de Igualdad de oportunidades e inclusión social para que los niños, niñas, adolescentes, jóvenes, hombres, mujeres, LGBTI, indígenas, negros, afrodescendientes, raizales, palenqueros, personas con discapacidad, personas mayores, víctimas y toda la población en general, puedan acceder a los servicios de salud, educación, cultura, deporte, recreación y actividad física; a través de procesos de participación, priorización de recursos y una buena gestión de gobierno, donde todos los araucanos gocen de mejor calidad de vida.";
                ViewBag.Image = "~/Image/Menu/Menu01.jpg";
                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Cultura",
                    text = "Espacios para la formación ciudadana, la recuperación de los principios y practicas auténticas de un territorio étnico-cultural, así como la transformación en sus comportamientos con un enfoque hacia una mejor cultura ciudadana"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Deporte",
                    text = "Para el incremento de la participación de la comunidad en los programas de deporte, recreación, aprovechamiento del tiempo libre y actividad física como principio de las buenas practicas ciudadanas, los procesos de formación de las diferentes disciplinas como herramienta para una ciudadanía competitiva, así como la construcción, adecuación y mejoramiento de equipamientos deportivos y recreativos integrales como alternativa de sano esparcimiento."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Educación",
                    text = "Educación inclusiva y de calidad, desde la primera infancia hasta los procesos educativos finales, donde la comunidad pueda fortalecer sus competencias y capacidades humanas para construir capital social productivo."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "4",
                    img = "~/Image/Menu/Menu" + id + "4.png",
                    title = "Inclusión Social",
                    text = "La desigualdad social en el municipio de Arauca constituye uno de los factores que limitan el desarrollo de la población, la potenciación de sus capacidades, de su conocimiento y de realización humana, aumentando la exclusión social de las personas y de los grupos poblacionales, generando dependencia económica, política y una distribución inequitativa de los recursos, implicando menos probabilidades de crecimiento de la población y del territorio."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "5",
                    img = "~/Image/Menu/Menu" + id + "5.png",
                    title = "Salud y protección social",
                    text = "Para garantizar el cumplimiento de la responsabilidad estatal y promover la participación ciudadana en la protección de la salud como un derecho esencial, individual, colectivo y comunitario logrado en función de las condiciones de bienestar y calidad de vida de la población del municipio de Arauca"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "6",
                    img = "~/Image/Menu/Menu" + id + "6.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan el Desarrollo Social Incluyente en el municipio de Arauca"
                });
            }
            else if (id == "2")
            {
                ViewBag.Mensaje = "Crecimiento Económico";
                ViewBag.SubMensaje = "Para obtener el incremento de la economía de los habitantes del municipio reflejado en el aumento de las inversiones, la producción de servicios y bienes y de la economía en general.";
                ViewBag.Image = "~/Image/Menu/Menu02.jpg";
                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Agricultura y Desarrollo Rural",
                    text = "Enfocado al fortalecimiento e innovación de las actividades económicas y productivas"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Ciencia, Tecnología e Innovación",
                    text = "Fortaleciendo un modelo más competitivo basado en la transferencia y uso del conocimiento"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Trabajo",
                    text = "El empleo productivo y el trabajo digno como fuente de prosperidad y como soporte de un desarrollo sostenible enfocado en la disminución de la informalidad."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "4",
                    img = "~/Image/Menu/Menu" + id + "4.png",
                    title = "Comercio, Industria y Turismo",
                    text = "Apoyo a la actividad empresarial productora de bienes, servicios y tecnología, así como la gestión turística de esta región del país"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "5",
                    img = "~/Image/Menu/Menu" + id + "5.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan el Crecimiento Económico en el municipio de Arauca."
                });
            }
            else if (id == "3")
            {
                ViewBag.Mensaje = "Arauca Verde, Ordenada y Sostenible";
                ViewBag.SubMensaje = "Orientando acciones integrales en el territorio para la conservación, protección y restauración del medio ambiente, con formación en cultura ambiental ciudadana, prevención y atención del riesgo, intervención, control y vigilancia de los recursos naturales en coordinación con las entidades ambientales competentes, con el fin de reducir la vulnerabilidad ante el cambio climático, logrando un territorio resiliente encaminado al goce de un ambiente sano y sostenible.";
                ViewBag.Image = "~/Image/Menu/Menu03.jpg";
                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Ambiente y Desarrollo Sostenible",
                    text = "Promueve la conservación, recuperación y control de recursos naturales del municipio de Arauca. Con Ordenamiento Ambiental Territorial, conservación de la biodiversidad y sus servicios ecosistémicos, gestión de la información y el conocimiento ambiental y con gestión del cambio climático para un desarrollo bajo en carbono y resiliente al clima."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Gobierno Territorial y Atención de Desastres",
                    text = "Fomenta las acciones para mitigar la exposición al riesgo de desastres generados por los fenómenos naturales y antrópicos no intencionados, logrando un municipio resiliente al clima."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan un territorio verde, ordenado y sostenible en el municipio de Arauca."
                });

            }
            else if (id == "4")
            {
                ViewBag.Mensaje = "Infraestructura Social y Productiva";
                ViewBag.SubMensaje = "Accionando en proyectos de infraestructura social para generar oportunidades económicas por medio del fomento del desarrollo de capacidades productivas y de inversión en los ámbitos rurales y urbanos del municipio.";
                ViewBag.Image = "~/Image/Menu/Menu04.jpg";
                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Transporte",
                    text = "Mejorando el sistema de movilidad de la ciudad a través de la planificación, estructuración coherente y priorización de proyectos de inversión para la recuperación de la malla vial urbana y rural, así lograr reducir distancias, ser competitiva a través del transporte de los productos del campo y dinamizar el desarrollo económico local. Proporcionar a la ciudadanía una movilidad accesible, segura y confortable que aporte al mejoramiento de la calidad de vida y pueda garantizar una ciudad sostenible a largo plazo"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Minas y energía",
                    text = "A través de la intervención de proyectos estratégicos en el territorio, se mejoran las condiciones de habitabilidad de la comunidad mediante el acceso a los servicios públicos no domiciliarios como garantía de vida."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Vivienda",
                    text = "Beneficiando a la comunidad a partir de la recuperación de espacios suficientes y la generación de nuevos entornos sociales en el territorio, un complemento a las dinámicas de interacción que son necesarias para la salud, el bienestar mental y físico. Reconocer las formas particulares de habitar de la comunidad, identificar los territorios vulnerables e implementar estrategias que apunten como solución a las necesidades humanas individuales que aqueja la población y mejorar condiciones de vida de las diversas poblaciones a través del goce efectivo de los servicios básicos y de calidad."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "4",
                    img = "~/Image/Menu/Menu" + id + "4.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan una inflaestructura social y productiva en el municipio de Arauca."
                });
            }
            else if (id == "5")
            {
                ViewBag.Mensaje = "Buen Gobierno";
                ViewBag.SubMensaje = "Como debe hacerse en toda Colombia. Esta vez, enfocado a imperiosas áreas como Gobierno Territorial, Información Estadística, Vivienda y Tecnologías de la Información y las Comunicaciones.";
                ViewBag.Image = "~/Image/Menu/Menu05.jpg";

                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Gobierno territorial",
                    text = "Este sector aborda los temas relacionados con el fortalecimiento institucional, aumento del recaudo y tributación y mejora de la planeación territorial del municipio de Arauca"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Información Estadística",
                    text = "Este sector está orientado a la producción de información estadística, incluyendo la implementación y el desarrollo de metodologías de carácter social, políticas, demográficas y culturales, con el fin de dar las líneas de acción para realizar las diferentes operaciones estadísticas de la entidad."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Tecnologías de la Información y las Comunicaciones",
                    text = "En este sector se encuentra la información relacionada con los servicios en materia de tecnologías de la información y las comunicaciones en el municipio, que conllevan al desarrollo, y uso intensivo de las mismas."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "4",
                    img = "~/Image/Menu/Menu" + id + "4.png",
                    title = "Vivienda",
                    text = "En este sector se analizará los temas de ordenamiento territorial y desarrollo urbano, en beneficio de toda la comunidad."
                });

                model.Add(new ContentModelView()
                {
                    url = id + "5",
                    img = "~/Image/Menu/Menu" + id + "5.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan el buen gobierno en el municipio de Arauca."
                });

            }
            else if (id == "6")
            {
                ViewBag.Mensaje = "Seguridad, Convivencia y Justicia.";
                ViewBag.SubMensaje = "Busca ofrecer un territorio donde sus habitantes mantengan relaciones de convivencia e integración armoniosas, garantizando el uso y goce de los deberes y derechos, bajo los principios de respeto, autoridad, participación ciudadana y cumpliendo la normatividad, donde la sociedad, las autoridades e instituciones, forjamos un tejido social incluyente.";
                ViewBag.Image = "~/Image/Menu/Menu06.jpg";
                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Gobierno Territorial",
                    text = "Este sector se fundamenta en la articulación de las instituciones públicas que actúan en el municipio, los grupos de interés y las relaciones que se generan entre el Estado y la Sociedad Civil. El sector incluye el fortalecimiento comunitario, la justicia y la seguridad ciudadana (urbana y rural), el fortalecimiento de las relaciones fronterizas, el respeto por los derechos humanos, la paz y la reconciliación."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Inclusion social",
                    text = "Aumentando el control y desarrollo fronterizo, cultural, económico y social del municipio de Arauca."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "De la Justicia y del Derecho",
                    text = "La población del municipio de Arauca no ha sabido dirimir sus conflictos de manera adecuada, prefiriendo tomar por mano propia la resolución de estos, lo que por un lado indica el desconocimiento del Código Nacional de Seguridad y Convivencia Ciudadana, así como en los altos índices de violencia que se han convertido en una problemática social y de salud pública y como tal debe ser objeto de análisis desde el punto de vista social, gubernamental, económico, intersectorial; de modo que se analicen comportamientos y actitudes de riesgo que sean intervenidos y atendidos, implementando estrategias que propendan por la solución de esta problemática desde la óptica del individuo, la familia y la sociedad"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "4",
                    img = "~/Image/Menu/Menu" + id + "4.png",
                    title = "Vivienda",
                    text = "Se analizan los temas de ordenamiento territorial y desarrollo urbano, en beneficio de toda la comunidad."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "5",
                    img = "~/Image/Menu/Menu" + id + "5.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan la seguridad, convivencia y justicia en el municipio de Arauca."
                });
            }
            else if (id == "7")
            {
                ViewBag.Mensaje = "Gestión del Conocimineto.";
                ViewBag.SubMensaje = "La gestión del conocimiento y la innovación implican administrar el conocimiento tácito: lo que tenemos en cada servidor publico y en el colectivo araucano y explícito: lo que se encuentra en documentos y bases de datos y, en la comunidad sobre el saber araucano.";
                ViewBag.Image = "~/Image/Menu/Menu07.jpg";

                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Gestión del Conocimiento",
                    text = "..."
                });
                //model.Add(new ContentModelView()
                //{
                //    url = id + "2",
                //    img = "~/Image/Menu/Menu" + id + "2.png",
                //    title = "Normatividad",
                //    text = "..."
                //});

            }
            else if (id == "8")
            {
                ViewBag.Mensaje = "P.Q.R.S.";
                ViewBag.SubMensaje = "Módulo para registro y consulta de Peticiones, Quejas, Reclamos, Sugerencias, Denuncias, Felicitaciones, Propuestas y un completo submódulo de Propuestas Detalladas para que toda la comunidad araucana esté más cerca de la administración municipal y acompañe su gestión.";
                ViewBag.Image = "~/Image/Menu/Menu08.jpg";

                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "P.Q.R.S.",
                    text = "..."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Propuesta Detallada",
                    text = "Un módulo para que el ciudadano registre, con detalle, que incluye actividades, tiempos y costos las diferentes propuestas para la administración municipal."
                });
                model.Add(new ContentModelView()
                {
                    url = id + "3",
                    img = "~/Image/Menu/Menu" + id + "3.png",
                    title = "Normatividad",
                    text = "Las leyes y normas que regulan P.Q.R.S en el Portal Web del municipio de Arauca."
                });
            }
            else if (id == "9")
            {
                ViewBag.Mensaje = "Ingreso / Registrarse";
                ViewBag.SubMensaje = "Para que el ciudadano se registre en el portal web y participe de publicar su información personal, de su negocio o actividad productiva, social o cultural, entre otras y sea encontrado por otro ciudadano que requiera de sus servicios o productos, y que también participe de las actividades del Portal como P.Q.R.S. y demás del sitio.";
                ViewBag.Image = "~/Image/Menu/Menu09.png";

                model.Add(new ContentModelView()
                {
                    url = id + "1",
                    img = "~/Image/Menu/Menu" + id + "1.png",
                    title = "Registrarse",
                    text = "Para incluirse en el portal web y participar de sus opciones en el municipio de Arauca"
                });
                model.Add(new ContentModelView()
                {
                    url = id + "2",
                    img = "~/Image/Menu/Menu" + id + "2.png",
                    title = "Ingresar",
                    text = "Luego de registrase en el Portal, sencillamente se ingresa con el usuario, que corresponde al correo electrónico registrado y la contraseña seleccionada"
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult MenuConfirmed(string id)
        {
            string ctr = string.Empty;

            if (id == "11")
            {
                ctr = "Cultura";
            }
            else if (id == "12")
            {
                ctr = "Deporte";
            }
            else if (id == "13")
            {
                ctr = "Educacion";
            }
            else if (id == "14")
            {
                ctr = "InclusionSocial";
            }
            else if (id == "15")
            {
                ctr = "SaludyProteccion";
            }
            else if (id == "16")
            {
                ctr = "DesarrolloSocialNormatividad";
            }
            else if (id == "21")
            {
                ctr = "AgriculturaDesarrolloRural";
            }
            else if (id == "22")
            {
                ctr = "CienciaTecnologiaInnovacion";
            }
            else if (id == "23")
            {
                ctr = "Trabajo";
            }
            else if (id == "24")
            {
                ctr = "ComercionIndustriaTurismo";
            }
            else if (id == "25")
            {
                ctr = "CrecimientoEconomicoNormatividad";
            }
            else if (id == "31")
            {
                ctr = "AmbienteyDesarrolloSostenible";
            }
            else if (id == "32")
            {
                ctr = "AtencionDesastre";
            }
            else if (id == "33")
            {
                ctr = "AraucaVedeOrdenadaSostenibleNormatividad";
            }
            else if (id == "41")
            {
                ctr = "Transporte";
            }
            else if (id == "42")
            {
                ctr = "MinasyEnergia";
            }
            else if (id == "43")
            {
                ctr = "ViviendaInfra";
            }
            else if (id == "44")
            {
                ctr = "InfraestructuraSocialProductivaNormatividad";
            }
            else if (id == "51")
            {
                ctr = "BuenGobiernoTerritorial";
            }
            else if (id == "52")
            {
                ctr = "InformacionEstadistica";
            }
            else if (id == "53")
            {
                ctr = "Tecnologia";
            }
            else if (id == "54")
            {
                ctr = "ViviendaBuen";
            }
            else if (id == "55")
            {
                ctr = "BuenGobiernoNormatividad";
            }
            else if (id == "61")
            {
                ctr = "GobiernoTerritorial";
            }
            else if (id == "62")
            {
                ctr = "InclusionSocial2";
            }
            else if (id == "63")
            {
                ctr = "JusticiaDerecho";
            }
            else if (id == "64")
            {
                ctr = "ViviendaSeguridad";
            }
            else if (id == "65")
            {
                ctr = "BuenGobiernoNormatividad";
            }
            else if (id == "71")
            {
                ctr = "GestionConocimiento";
            }
            else if (id == "72")
            {
                ctr = "GestionConocimientoNormatividad";
            }
            else if (id == "81")
            {
                ctr = "Pqrs";
            }
            else if (id == "82")
            {
                ctr = "PropuestaDetallada";
            }
            else if (id == "83")
            {
                ctr = "PqrsNormatividad";
            }
            else if (id == "91")
            {
                ctr = "Registrarse";
            }
            else if (id == "92")
            {
                ctr = "Ingresar";
            }
            else if (id == "93")
            {
                ctr = "ForgoPassword";
            }

            return RedirectToAction(ctr, "LineStrategic");
        }

        public IActionResult MapaSitio()
        {
            return View();
        }


        public IActionResult NotAuthorized()
        {
            return View();
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> manuales()
        {
            string ltFile = "ManualDeUsuario.pdf";
            if(User.Identity.IsAuthenticated)
            {
                if(User.IsInRole("Administrador"))
                {
                    ltFile = "ManualDelAdministrador.pdf";
                }
                else if(User.IsInRole("Publicador") || User.IsInRole("Prensa"))
                {
                    ltFile = "ManualDelPublicador.pdf";
                }
            }
            
            MemoryStream memory = await DownloadSinghFile(ltFile, "wwwroot\\support");

            return File(memory, "application/pdf");
        }
        private async Task<MemoryStream> DownloadSinghFile(string fileName, string uploadPath)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, fileName);
            MemoryStream memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
            }

            memory.Position = 0;
            return memory;

        }
    }
}