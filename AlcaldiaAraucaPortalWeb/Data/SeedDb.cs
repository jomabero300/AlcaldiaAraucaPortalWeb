using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IDocumentTypeHelper _documentTypeHelper;
        private readonly IGenderHelper _genderHelper;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalkHelper;
        private readonly IStateHelper _stateHelper;


        public SeedDb(ApplicationDbContext context, IUserHelper userHelper, IDocumentTypeHelper documentTypeHelper, IGenderHelper genderHelper, INeighborhoodSidewalkHelper neighborhoodSidewalkHelper, IStateHelper stateHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _documentTypeHelper = documentTypeHelper;
            _genderHelper = genderHelper;
            _neighborhoodSidewalkHelper = neighborhoodSidewalkHelper;
            _stateHelper = stateHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckDepartmentAsync();
            await CheckStateAsync();
            await CheckZoneAsync();
            await CheckDocumentTypeIdAsync();
            await CheckGenderAsync();
            await CheckCommuneTownshipAsync();
            await CheckNeighborhoodSidewalkIdAsync();
            await CheckRolesAsync();
            //await CheckRegisAsync();
            //await CheckUserAsync("0000", "Administrador", "Arauca activa", "admin@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Administrador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("1010", "José Manuel", "Bello Romero", "jomabero300@gmail.com", "3133670740", "Calle 14 No 14 - 63", UserType.Administrador, DateTime.Parse("25/10/1972"), "Mbel123.");
            //await CheckUserAsync("1010", "leonardol", "Pulido", "leonardopulidom@gmail.com", "3134907527", "Carrera 42 No 14a - 03", UserType.Administrador, DateTime.Parse("25/10/1965"), "User123.");
            //await CheckUserAsync("0001", "User", "Linea 1", "userlinea1@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0002", "User", "Linea 2", "userlinea2@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0003", "User", "Linea 3", "userlinea3@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0004", "User", "Linea 4", "userlinea4@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0005", "User", "Linea 5", "userlinea5@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0006", "User", "Linea 6", "userlinea6@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckUserAsync("0007", "User", "Linea 7", "userlinea7@gmail.com", "3130000000", "Calle 20 carrera 24", UserType.Publicador, DateTime.Parse("01/01/1912"), "User123.");
            //await CheckLineAsync();

        }

        private async Task CheckRegisAsync()
        {

            if(_context.Contents.Count()<79)
            {
                /*
                57723453-477d-4236-a867-73c1db32f1c0 - Desarrollo
                c2228ca7-cde8-4bbf-9b49-0ccc5ea1572f - Crecimiento
                6d236100-0f4a-4405-ad89-7d6d10992a3a - Arauca
                2ad99c1c-7e35-4340-b365-226390f42ba9 - Infraestructura
                baa77bf0-db2a-4e32-b59a-6c4c664a1539 - Buen gobierno
                a95777db-2025-4bb3-ac2c-4af4d1a66f77 - Seguridad
                 */
                //ApplicationUser publiDesarrollo =await _context.Users.Where(x => x.Id == "57723453-477d-4236-a867-73c1db32f1c0").FirstOrDefaultAsync();
                await _context.Contents.AddRangeAsync(
                    new Entities.Cont.Content 
                    { 
                        UserId= "57723453-477d-4236-a867-73c1db32f1c0",
                        ContentDate=DateTime.Parse(""),
                        ContentTitle="",
                        ContentText="",
                        ContentUrlImg="",StateId=3,
                        ContentDetails = new List<Entities.Cont.ContentDetail> {
                            new Entities.Cont.ContentDetail
                            {
                             ContentDate=DateTime.Parse(""),
                             ContentTitle="",
                             ContentText="",
                             ContentUrlImg= "",
                             StateId=3
                            }
                        }
                    });
            }
        }

        private async Task CheckLineAsync()
        {
            if (!_context.PqrsStrategicLines.Any())
            {
                _context.PqrsStrategicLines.AddRange(
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Gestión del conocimiento" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Seguridad convivencia y justicia" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Buen gobierno" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Infraestructura social y productiva" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Arauca verde, ordenada y sostenible" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Crecimiento económico" },
                    new PqrsStrategicLine() { PqrsStrategicLineName = "Desarrollo social incluyente" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckUserConfirm(string email)
        {
            ApplicationUser user = await _userHelper.GetUserAsync(email);

            if (user != null)
            {
                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }
        }

        private async Task CheckStateAsync()
        {
            if(!_context.States.Any())
            {
                State model = new State()
                {
                    StateType = "G",
                    StateName = "Suspendido",
                    StateB = true
                };

                await _stateHelper.AddUpdateAsync(model);
                State model2 = new State()
                {

                    StateName = "Inactivo",
                    StateType = "G",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model2);

                State model3 = new State()
                {

                    StateName = "Activo",
                    StateType = "G",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model3);

                State model4 = new State()
                {
                    StateName = "Eliminado",
                    StateType = "G",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model4);

                State model5 = new State()
                {
                    StateName = "Abierto",
                    StateType = "P",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model5);

                State model6 = new State()
                {
                    StateName = "En Trámite",
                    StateType = "P",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model6);

                State model7 = new State()
                {
                    StateName = "Cerrado",
                    StateType = "P",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model7);

                State model8 = new State()
                {
                    StateName = "Previo",
                    StateType = "G",
                    StateB = true,
                };
                await _stateHelper.AddUpdateAsync(model8);
            }

        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType, DateTime birdDarte, string passwor)
        {
            ApplicationUser user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {
                DocumentType documentTypeId = await _documentTypeHelper.ByIdNameAsync("Cédula de ciudadanía");
                Gender genderId = await _genderHelper.ByIdNameAsync("Hombre");
                NeighborhoodSidewalk neighborhood = await _neighborhoodSidewalkHelper.ByIdNameAsync("La esperanza");

                user = new ApplicationUser()
                {
                    UserName = email,
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Address = address,
                    BirdDarte = birdDarte,
                    DocumentTypeId = documentTypeId.DocumentTypeId,
                    GenderId = genderId.GenderId,
                    NeighborhoodSidewalkId = neighborhood.NeighborhoodSidewalkId
                };

                await _userHelper.AddUserAsync(user, passwor);
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }
        }

        private async Task CheckDepartmentAsync()
        {
            if (!_context.Departments.Any())
            {
                _context.Departments.Add(
                    new Department
                    {
                        DepartmentName = "Arauca",
                        Municipalities = new List<Municipality>() {
                            new Municipality {MunicipalityName="Arauca" }
                        }
                    });


                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckZoneAsync()
        {
            if (!_context.Zones.Any())
            {
                _context.Zones.Add(new Zone { ZoneName = "Urbano" });
                _context.Zones.Add(new Zone { ZoneName = "Rural" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypeIdAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.AddRange(
                    new DocumentType() { DocumentTypeName = "Cédula de ciudadanía" },
                    new DocumentType() { DocumentTypeName = "Cédula de extranjería" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckGenderAsync()
        {
            if (!_context.Genders.Any())
            {
                _context.Genders.AddRange(
                    new Gender() { GenderName = "Hombre" },
                    new Gender() { GenderName = "Mujer" },
                    new Gender() { GenderName = "Otro" });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckNeighborhoodSidewalkIdAsync()
        {
            if (!_context.NeighborhoodSidewalks.Any())
            {
                var comuna1 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 1 raimundo cisneros olivera")).FirstOrDefaultAsync();
                if (comuna1 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "20 de julio" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Cabañas del rio" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Libertadores" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Miramar" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Miramar frontera" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Primero de mayo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna1.CommuneTownshipId, NeighborhoodSidewalkName = "Siete de agosto" });
                    await _context.SaveChangesAsync();
                }
                var comuna2 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 2 josefa canelones")).FirstOrDefaultAsync();
                if (comuna1 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Cordoba" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "San luis" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Santa fe" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Santafesito" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna2.CommuneTownshipId, NeighborhoodSidewalkName = "Union" });
                    await _context.SaveChangesAsync();
                }
                var comuna3 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 3 antonio benites")).FirstOrDefaultAsync();
                if (comuna3 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "12 De Octubre" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Corocoras" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Cor Sec San Antonio" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Chorreras" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "El Centauro" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Guarataros" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "La Esperanza" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "La Victoria" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Paraiso" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Pedro Nel Jimenez" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Porvenir" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Primero De Enero" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Santa Teresita" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "El Triunfo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Bosque" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Flor Amarillo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Villa Maria" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Villa San Juan" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Villa Celeste" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Sector El Palmar" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Palma Real" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Bulevar De La Seiba" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Villa Luz" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Las Palmeras" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Arauco" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna3.CommuneTownshipId, NeighborhoodSidewalkName = "Altos De La Sabana" });
                    _context.SaveChanges();
                }
                var comuna4 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 4 jose laurencio")).FirstOrDefaultAsync();
                if (comuna4 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Americas" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Bosque Club" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Chircal" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Cristo Rey" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna4.CommuneTownshipId, NeighborhoodSidewalkName = "Meridiano 70" });
                    _context.SaveChanges();
                }

                var comuna5 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Comuna 5 Juan Jose Rondon")).FirstOrDefaultAsync();

                if (comuna5 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Buena Vista" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Brisas Del Llano" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Costa Hermosa" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Divino Niño" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Flor De Mi Llano" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Fundadores Bajo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Fundadores Alto" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "La Granja" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Venado" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Olimpico" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "San Carlos" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Moriche" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. Santa Barbara" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Villa De Prado" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Villa Del Maestro" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Urb. El Horcon" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Bello Horizonte" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Bello Horizonte Alto" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = comuna5.CommuneTownshipId, NeighborhoodSidewalkName = "Manhatan" });

                    _context.SaveChanges();
                }

                var corregimiento1 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento El Caracol")).FirstOrDefaultAsync();

                if (corregimiento1 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Punto Fijo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Barranca Amarilla" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Villa Nueva Caracol" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Vapor" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Bogota" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Panchera" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Feliciano" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Miedo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Cabuyare" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Maporita" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Merecure" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "La Bendicion" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Matal De Flor Amarillo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "San Pablo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Maporillal" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "San Ramon" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Las Monas" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Cinaruco" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "El Socorro" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento1.CommuneTownshipId, NeighborhoodSidewalkName = "Las Plumas" });

                    _context.SaveChanges();
                }

                var corregimiento2 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Maporillal")).FirstOrDefaultAsync();

                if (corregimiento2 != null)
                {

                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Merecure" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "La Bendicion" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Matal De Flor Amarillo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "San Pablo" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Maporillal" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "San Ramon" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Las Monas" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Cinaruco" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "El Socorro" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento2.CommuneTownshipId, NeighborhoodSidewalkName = "Las Plumas" });

                    _context.SaveChanges();
                }

                var corregimiento3 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento De Santa Barbara")).FirstOrDefaultAsync();

                if (corregimiento3 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Barrancones" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Chaparrito" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "El Rosario" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Gallina" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "La Saya" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "El Torno" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "La Payara" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Bocas Del Arauca" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Clarinetero" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Monserrate" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Los Arrecifes" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Mata De Piña" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Los Caballos" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento3.CommuneTownshipId, NeighborhoodSidewalkName = "Penjamo" });

                    _context.SaveChanges();
                }

                var corregimiento4 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Todos Los Santos")).FirstOrDefaultAsync();

                if (corregimiento4 != null)
                {
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Corocito" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Todos Los Santos" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "La Yuca" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Altamira" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Las Nubes A" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "Las Nubes B" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Siani" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Final" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "La Becerra" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento4.CommuneTownshipId, NeighborhoodSidewalkName = "El Sol" });

                    _context.SaveChanges();
                }

                var corregimiento5 = await _context.CommuneTownships.Where(m => m.CommuneTownshipName.Equals("Corregimiento Cañas Bravas")).FirstOrDefaultAsync();

                if (corregimiento5 != null)
                {

                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "San Jose Del Lipa" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Pastora" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Selvas Del Lipa" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Salas" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Salto Del Lipa" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Brisas Del Salto" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Alto Primores" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Vigia" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Cañas Bravas" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Milagro" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Azul" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Colorado" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Caño Seco" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Perocero" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Comunidad" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Manatiales" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Maporal" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "El Perocero B" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "La Conquista" });
                    _context.NeighborhoodSidewalks.Add(new NeighborhoodSidewalk { CommuneTownshipId = corregimiento5.CommuneTownshipId, NeighborhoodSidewalkName = "Los Andes" });

                    _context.SaveChanges();
                }

            }
        }

        private async Task CheckCommuneTownshipAsync()
        {
            if (!_context.CommuneTownships.Any())
            {
                var mpio = await _context.Municipalities.Where(m => m.MunicipalityName.Equals("Arauca")).FirstOrDefaultAsync();
                if (mpio != null)
                {
                    var zone = await _context.Zones.Where(z => z.ZoneName.Equals("Urbano")).FirstOrDefaultAsync();
                    if (zone != null)
                    {

                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone.ZoneId, CommuneTownshipName = "Comuna 1 raimundo cisneros olivera" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone.ZoneId, CommuneTownshipName = "Comuna 2 josefa canelones" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone.ZoneId, CommuneTownshipName = "Comuna 3 antonio benites" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone.ZoneId, CommuneTownshipName = "Comuna 4 jose laurencio" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone.ZoneId, CommuneTownshipName = "Comuna 5 juan jose rondon" });
                        _context.SaveChanges();
                    }

                    var zone2 = await _context.Zones.Where(z => z.ZoneName.Equals("Rural")).FirstOrDefaultAsync();

                    if (zone2 != null)
                    {
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento El Caracol" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Maporillal" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento De Santa Barbara" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Todos Los Santos" });
                        _context.CommuneTownships.Add(new CommuneTownship { MunicipalityId = mpio.MunicipalityId, ZoneId = zone2.ZoneId, CommuneTownshipName = "Corregimiento Cañas Bravas" });
                        _context.SaveChanges();
                    }
                }
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Administrador.ToString());
            await _userHelper.CheckRoleAsync(UserType.Publicador.ToString());
            await _userHelper.CheckRoleAsync(UserType.Usuario.ToString());
            await _userHelper.CheckRoleAsync(UserType.Prensa.ToString());
        }
    }
}
