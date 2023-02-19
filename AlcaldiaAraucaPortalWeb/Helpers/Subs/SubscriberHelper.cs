using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public class SubscriberHelper : ISubscriberHelper
    {
        private readonly ApplicationDbContext _context;

        public SubscriberHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Subscriber model)
        {
            if (model.SubscriberId == 0)
            {
                _context.Subscribers.Add(model);
            }
            else
            {
                _context.Subscribers.Update(model);
            }

            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.InnerException.Message.Contains("IX_") ? "El registro ya existe" : ex.Message;
            }

            return response;
        }

        public async Task<bool> ByEmailAsync(string email)
        {
            Subscriber model = await _context.Subscribers.Where(x => x.email == email).FirstOrDefaultAsync();

            if (model != null)
            {
                return false;
            }

            return true;
        }

        public async Task<Subscriber> ByIdAsync(int id)
        {
            return await _context.Subscribers.Where(x => x.SubscriberId == id).FirstOrDefaultAsync();
        }

        public async Task<Response> ConfirmEmailAsync(Subscriber subscriber, string token)
        {
            subscriber.EmailConfirmed = true;

            _context.Subscribers.Update(subscriber);

            await _context.SaveChangesAsync();

            return new Response() { Succeeded = true };
        }

        public async Task<List<string>> emailsSubscribeAsync(int id)
        {
            int sectorId = await _context.Contents
                                       .Where(c => c.ContentId == id)
                                       .Select(c => c.PqrsStrategicLineSectorId)
                                       .FirstOrDefaultAsync();

            List<string> emails = await (from s in _context.Subscribers
                                        join ss in _context.SubscriberSectors on s.SubscriberId equals ss.SubscriberId
                                        where ss.PqrsStrategicLineSectorId == sectorId  && 
                                              ss.State.StateName== "Activo" &&
                                              s.State.StateName== "Activo"
                                        select s.email).ToListAsync();
            return emails;

        }

        public async Task<List<string>> SectorMenuUrl(int id)
        {
            string url = string.Empty;
            List<string> list = new List<string>();

            var xx = await _context.Contents
                                 .Where(c => c.ContentId == id)
                                 .Select(c => new { c.PqrsStrategicLineSector.PqrsStrategicLineSectorName, c.PqrsStrategicLineSector.PqrsStrategicLine.PqrsStrategicLineName })
                                 .FirstOrDefaultAsync();
            
            if (xx.PqrsStrategicLineName == "Desarrollo social incluyente")
            {
                if (xx.PqrsStrategicLineSectorName == "Cultura")
                {
                    url = "Cultura";

                }
                else if (xx.PqrsStrategicLineSectorName == "Deporte")
                {
                    url = "Deporte";
                }
                else if (xx.PqrsStrategicLineSectorName == "Educación")
                {
                    url = "Educacion";

                }
                else if (xx.PqrsStrategicLineSectorName == "Inclusión social")
                {

                    url = "InclusionSocial";
                }
                else if (xx.PqrsStrategicLineSectorName == "Salud y protección")
                {

                    url = "SaludyProteccion";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {

                    url = "DesarrolloSocialNormatividad";
                }

            }
            else if (xx.PqrsStrategicLineName == "Crecimiento económico")
            {
                if (xx.PqrsStrategicLineSectorName == "Comercio, industria y turismo")
                {
                    url = "ComercionIndustriaTurismo";

                }
                else if (xx.PqrsStrategicLineSectorName == "Trabajo")
                {
                    url = "Trabajo";
                }
                else if (xx.PqrsStrategicLineSectorName == "Ciencia, tecnología e innovación")
                {
                    url = "CienciaTecnologiaInnovacion";
                }
                else if (xx.PqrsStrategicLineSectorName == "Agricultura y desarrollo rural")
                {
                    url = "AgriculturaDesarrolloRural";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {
                    url = "CrecimientoEconomicoNormatividad";
                }
            }
            else if (xx.PqrsStrategicLineName == "Arauca verde, ordenada y sostenible")
            {
                if (xx.PqrsStrategicLineSectorName == "Gobierno territorial - Atención a desastres")
                {
                    url = "AtencionDesastre";

                }
                else if (xx.PqrsStrategicLineSectorName == "Ambiente desarrollo sostenible")
                {
                    url = "AmbienteyDesarrolloSostenible";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {
                    url = "AraucaVedeOrdenadaSostenibleNormatividad";
                }

            }
            else if (xx.PqrsStrategicLineName == "Infraestructura social y productiva")
            {
                if (xx.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "ViviendaInfra";

                }
                else if (xx.PqrsStrategicLineSectorName == "Minas y energía")
                {
                    url = "MinasyEnergia";
                }
                else if (xx.PqrsStrategicLineSectorName == "Transporte")
                {
                    url = "Transporte";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {
                    url = "InfraestructuraSocialProductivaNormatividad";
                }
            }
            else if (xx.PqrsStrategicLineName == "Buen gobierno")
            {
                if (xx.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "ViviendaBuen";
                }
                else if (xx.PqrsStrategicLineSectorName == "Tecnologioas de la información y las comunicaciones")
                {
                    url = "Tecnologia";
                }
                else if (xx.PqrsStrategicLineSectorName == "Gobierno territorial")
                {
                    url = "BuenGobiernoTerritorial";
                }
                else if (xx.PqrsStrategicLineSectorName == "Información estadisiticas")
                {
                    url = "InformacionEstadistica";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {
                    url = "BuenGobiernoNormatividad";
                }
            }
            else if (xx.PqrsStrategicLineName == "Seguridad convivencia y justicia")
            {
                if (xx.PqrsStrategicLineSectorName == "Vivienda")
                {
                    url = "ViviendaSeguridad";
                }
                else if (xx.PqrsStrategicLineSectorName == "Gobierno territorial")
                {
                    url = "GobiernoTerritorial";
                }
                else if (xx.PqrsStrategicLineSectorName == "Inclusion social")
                {
                    url = "InclusionSocial2";
                }
                else if (xx.PqrsStrategicLineSectorName == "Justicia y derecho")
                {
                    url = "JusticiaDerecho";
                }
                else if (xx.PqrsStrategicLineSectorName == "Normatividad")
                {
                    url = "SeguridadConvivenciaJusticiaNormatividad";
                }
            }
            else if (xx.PqrsStrategicLineName == "Gestión del conocimiento")
            {
                if (xx.PqrsStrategicLineSectorName == "Gestión del conocimiento")
                {
                    url = "GestionConocimiento";
                }
            }

            list.Insert(0,$"{xx.PqrsStrategicLineName} - {xx.PqrsStrategicLineSectorName}" );

            list.Insert(1, url);

            return list;
        }
    }
}
