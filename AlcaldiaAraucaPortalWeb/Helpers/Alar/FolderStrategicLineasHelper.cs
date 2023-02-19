using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public class FolderStrategicLineasHelper : IFolderStrategicLineasHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IPqrsUserStrategicLineHelper _userStrategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineSectorHelper;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public FolderStrategicLineasHelper(ApplicationDbContext context,
            IPqrsUserStrategicLineHelper userStrategicLineHelper,
            IPqrsStrategicLineSectorHelper strategicLineSectorHelper,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _context = context;
            _userStrategicLineHelper = userStrategicLineHelper;
            _strategicLineSectorHelper = strategicLineSectorHelper;
            _configuration = configuration;
            _env = env;
        }

        public string FileMove(string sourceFileName, string destFileName)
        {
            var Folder = destFileName.Replace("\\", "/");

            var pathFolder = _configuration["MyFolders:Content"];

            var url = _configuration["MyDomain:Url"];

            int star = sourceFileName.LastIndexOf("/") + 1;

            var file = sourceFileName.Substring(star, sourceFileName.Length - star);

            sourceFileName = Path.Combine(_env.WebRootPath, pathFolder, file);

            destFileName = destFileName.Replace('/', '\\');

            destFileName = Path.Combine(_env.WebRootPath, destFileName, file);

            System.IO.File.Move(sourceFileName, destFileName);

            return $"{url}{Folder}/{file}";
        }

        public async Task<string> FolderPathAsync(int pqrsStrategicLineSectorId, string userName)
        {
            //string lineName = await lpineNameAsync(userName);

            string lineName1 = await _context.PqrsStrategicLineSectors
                                    .Include(x => x.PqrsStrategicLine)
                                    .Where(p => p.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId)
                                    .Select(x=>x.PqrsStrategicLine.PqrsStrategicLineName)
                                    .FirstOrDefaultAsync();

            var nomSector = await _strategicLineSectorHelper.ByIdAsync(pqrsStrategicLineSectorId);

            string folderPath = FolderPath(lineName1, nomSector.PqrsStrategicLineSectorName);

            return folderPath;
        }

        public string FolderPath(string lineName, string SectorName)
        {
            string folderPath = "Image\\Menu\\";

            if (lineName == "Arauca verde, ordenada y sostenible")
            {
                folderPath = folderPath + "Arauca\\";
                if (SectorName == "Ambiente desarrollo sostenible")
                {
                    folderPath = folderPath + "Ambiente";
                }
                else if (SectorName == "Gobierno territorial - Atención a desastres")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }

            }
            else if (lineName == "Buen gobierno")
            {
                folderPath = folderPath + "BuenGobierno\\";
                if (SectorName == "Gobierno territorial")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Información estadisiticas")
                {
                    folderPath = folderPath + "Informacion";
                }
                else if (SectorName == "Tecnologioas de la información y las comunicaciones")
                {
                    folderPath = folderPath + "Tecnologia";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Crecimiento económico")
            {
                folderPath = folderPath + "Crecimiento\\";
                if (SectorName == "Agricultura y desarrollo rural")
                {
                    folderPath = folderPath + "Agricultura";
                }
                else if (SectorName == "Ciencia, tecnología e innovación")
                {
                    folderPath = folderPath + "Ciencia";
                }
                else if (SectorName == "Comercio, industria y turismo")
                {
                    folderPath = folderPath + "Comercio";
                }
                else if (SectorName == "Trabajo")
                {
                    folderPath = folderPath + "Trabajo";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Desarrollo social incluyente")
            {
                folderPath = folderPath + "Desarrollo\\";

                if (SectorName == "Cultura")
                {
                    folderPath = folderPath + "Cultura";
                }
                else if (SectorName == "Deporte")
                {
                    folderPath = folderPath + "Deporte";
                }
                else if (SectorName == "Educación")
                {
                    folderPath = folderPath + "Educacion";
                }
                else if (SectorName == "Inclusión social")
                {
                    folderPath = folderPath + "Inclusion";
                }
                else if (SectorName == "Salud y protección")
                {
                    folderPath = folderPath + "Salud";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Gestión del conocimiento")
            {
                folderPath = folderPath + "Gestion";
            }
            else if (lineName == "Infraestructura social y productiva")
            {
                folderPath = folderPath + "Infraestructura\\";

                if (SectorName == "Minas y energía")
                {
                    folderPath = folderPath + "Mina";
                }
                else if (SectorName == "Transporte")
                {
                    folderPath = folderPath + "Transporte";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }
            else if (lineName == "Seguridad convivencia y justicia")
            {
                folderPath = folderPath + "Seguridad\\";

                if (SectorName == "Gobierno territorial")
                {
                    folderPath = folderPath + "Gobierno";
                }
                else if (SectorName == "Inclusion social")
                {
                    folderPath = folderPath + "Inclusion";
                }
                else if (SectorName == "Justicia y derecho")
                {
                    folderPath = folderPath + "Justicia";
                }
                else if (SectorName == "Vivienda")
                {
                    folderPath = folderPath + "Vivienda";
                }
                else if (SectorName == "Normatividad")
                {
                    folderPath = folderPath + "Normatividad";
                }
            }

            return folderPath;
        }

        public async Task<string> FolderPathAsync(int LineaId, int SectorId)
        {
            var strategiaLinea = await _userStrategicLineHelper.PqrsStrategicLineBIdAsync(LineaId);

            var nomSector = await _strategicLineSectorHelper.ByIdAsync(SectorId);

            string folderPath = FolderPath(strategiaLinea.PqrsStrategicLineName, nomSector.PqrsStrategicLineSectorName);

            return folderPath;
        }

        public async Task<string> lpineNameAsync(string userName)
        {
            PqrsStrategicLine strategiaLineaId = await _userStrategicLineHelper.PqrsStrategicLineEmaildAsync(userName);

            return strategiaLineaId.PqrsStrategicLineName;
        }
    }
}
