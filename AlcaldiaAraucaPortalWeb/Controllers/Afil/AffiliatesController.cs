using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Enun;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AlcaldiaAraucaPortalWeb.Controllers.Afil
{
    [Authorize(Roles =nameof(UserType.Usuario))]

    public class AffiliatesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        private readonly IAffiliateHelper _affiliate;
        private readonly IAffiliateGroupProductiveHelper _affiliateGroupProductiveHelper;
        private readonly IAffiliateGroupCommunityHelper _AffiliateGroupCommunityHelper;
        private readonly IAffiliateProfessionHelper _affiliateProfessionHelper;


        private readonly IGroupProductiveHelper _productiveHelper;
        private readonly IGroupCommunityHelper _communityHelper;
        private readonly IProfessionHelper _professionHelper;
        private readonly ISocialNetworkHelper _socialNetworkHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IFolderStrategicLineasHelper _folderStrategicLineasHelper;
        private readonly IUserHelper _userHelper;

        public AffiliatesController(IGroupProductiveHelper productiveHelper,
            IAffiliateHelper affiliate,
            IGroupCommunityHelper communityHelper,
            IProfessionHelper professionHelper,
            ISocialNetworkHelper socialNetworkHelper,
            IImageHelper imageHelper,
            IFolderStrategicLineasHelper folderStrategicLineasHelper,
            IUserHelper userHelper,
            IConfiguration configuration,
            IWebHostEnvironment env,
            IAffiliateGroupProductiveHelper affiliateGroupProductiveHelper,
            IAffiliateGroupCommunityHelper affiliateGroupCommunityHelper,
            IAffiliateProfessionHelper affiliateProfessionHelper)
        {
            _productiveHelper = productiveHelper;
            _affiliate = affiliate;
            _communityHelper = communityHelper;
            _professionHelper = professionHelper;
            _socialNetworkHelper = socialNetworkHelper;
            _imageHelper = imageHelper;
            _folderStrategicLineasHelper = folderStrategicLineasHelper;
            _userHelper = userHelper;
            _configuration = configuration;
            _env = env;
            _affiliateGroupProductiveHelper = affiliateGroupProductiveHelper;
            _AffiliateGroupCommunityHelper = affiliateGroupCommunityHelper;
            _affiliateProfessionHelper = affiliateProfessionHelper;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await _affiliate.AffiliateListAsync();
            return View(applicationDbContext);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliate = await _affiliate.AffiliateByIdAsync((int)id);

            if (affiliate == null)
            {
                return NotFound();
            }

            return View(affiliate);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ComboAsync(), "GroupProductiveId", "GroupProductiveName");
            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ComboAsync(), "GroupCommunityId", "GroupCommunityName");
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(), "ProfessionId", "ProfessionName");
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(), "SocialNetworkId", "SocialNetworkName");
            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName");
                                                                 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AffiliateViewModelsProc model)
        {

            if (ModelState.IsValid)
            {
                //Guardar la imagen
                var path = string.Empty;

                if (model.ImagePath != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImagePath, "Image\\Afiliate\\Image");
                }

                if (model.Professions.Count > 0)
                {
                    for (int i = 0; i < model.Professions.Count; i++)
                    {
                        string pathFile = _affiliateProfessionHelper.FileMove(model.Professions[i].DocumentoPath, "Image\\Afiliate\\Document");
                        model.Professions[i].DocumentoPath = pathFile;
                        pathFile = _affiliateProfessionHelper.FileMove(model.Professions[i].ImagePath, "Image\\Afiliate\\Image");
                        model.Professions[i].ImagePath = pathFile;
                    }
                }

                ApplicationUser userId =await _userHelper.GetUserAsync(User.Identity.Name);

                Affiliate afiliate = new Affiliate()
                {
                    UserId = userId.Id.ToString(),
                    TypeUserId = model.TypeUserId,
                    Name = model.Name,
                    Nit = model.Nit,
                    Address = model.Address,
                    Phone = model.Phone,
                    CellPhone = model.CellPhone,
                    Email = model.Email,
                    ImagePath = path,
                    GroupProductives = model.Productivo.Select(p => new AffiliateGroupProductive() { GroupProductiveId = p.GroupProductiveId }).ToList(),
                    GroupCommunities = model.Comuntario.Select(c => new AffiliateGroupCommunity() { GroupCommunityId = c.GroupCommunityId }).ToList(),
                    Professions = model.Professions.Select(p => new AffiliateProfession() { ProfessionId = p.ProfessionId, Concept = p.Concept, ImagePath = p.ImagePath, DocumentoPath = p.DocumentoPath }).ToList(),
                    SocialNetworks = model.SocialNetwork.Select(s => new AffiliateSocialNetwork() { SocialNetworkId = s.SocialNetworkId, AffiliateSocialNetworURL = s.SocialNetworURL }).ToList()
                };

                Response response = await _affiliate.AddUpdateAsync(afiliate);

                if (response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ComboAsync(), "GroupProductiveId", "GroupProductiveName");

            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ComboAsync(), "GroupCommunityId", "GroupCommunityName");

            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ComboAsync(), "ProfessionId", "ProfessionName");

            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(), "SocialNetworkId", "SocialNetworkName");

            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName", model.TypeUserId);

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Affiliate affiliate = await _affiliate.AffiliateByIdAsync((int)id);

            if (affiliate == null)
            {
                return NotFound();
            }

            AffiliateViewModels model = new AffiliateViewModels()
            {
                AffiliateId=affiliate.AffiliateId,
                UserId=affiliate.UserId,
                TypeUserId=affiliate.TypeUserId,
                Name=affiliate.Name,
                Nit=affiliate.Nit,
                Address=affiliate.Address,
                Phone=affiliate.Phone,
                CellPhone=affiliate.CellPhone,
                Email=affiliate.Email,
                ImagePath=affiliate.ImagePath,
                GroupProductives=affiliate.GroupProductives,
                GroupCommunities=affiliate.GroupCommunities,
                SocialNetworks = affiliate.SocialNetworks,
                Professions=affiliate.Professions,
            };

            ViewData["GroupProductiveId"] = new SelectList(await _productiveHelper.ByIdAffiliateAsync(model.AffiliateId), "GroupProductiveId", "GroupProductiveName");
            ViewData["GroupCommunityId"] = new SelectList(await _communityHelper.ByIdAffiliateAsync(model.AffiliateId), "GroupCommunityId", "GroupCommunityName");
            ViewData["ProfessionId"] = new SelectList(await _professionHelper.ByIdAffiliateAsync(model.AffiliateId), "ProfessionId", "ProfessionName");
            ViewData["SocialNetworkId"] = new SelectList(await _socialNetworkHelper.ComboAsync(model.AffiliateId), "SocialNetworkId", "SocialNetworkName");
            ViewData["TypeUserId"] = new SelectList(typeUser(), "TypeUserId", "TypeUserName", model.TypeUserId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AffiliateId,UserId,TypeUserId,Name,Nit,Address,Phone,CellPhone,Email,ImagePath,ImagePathNew")] AffiliateViewModels model)
        {
            if (id != model.AffiliateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (model.ImagePathNew != null)
                {
                    string path = await _imageHelper.UploadImageAsync(model.ImagePathNew, "Image\\Afiliate\\Image");
                    await _imageHelper.DeleteImageAsync(model.ImagePath, "Image\\Afiliate\\Image");
                    model.ImagePath=path;
                }

                Affiliate modelUpdate = new Affiliate
                {
                    AffiliateId = model.AffiliateId,
                    UserId = model.UserId,
                    TypeUserId = model.TypeUserId,
                    Name = model.Name,
                    Nit = model.Nit,
                    Address = model.Address,
                    Phone = model.Phone,
                    CellPhone = model.CellPhone,
                    Email = model.Email,
                    ImagePath = model.ImagePath,
                };

                Response response =await _affiliate.AddUpdateAsync(modelUpdate);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> getCommunity(string GroupCommunity)
        {
            List<GroupCommunity> model;

            if (GroupCommunity == null)
            {
                model = await _communityHelper.ComboAsync();
            }
            else
            {
                GroupCommunity = GroupCommunity.Substring(0, GroupCommunity.Length - 1);

                string[] groupProductiveId = GroupCommunity.Split(',').Select(d => d.ToString()).ToArray();

                model = await _communityHelper.ComboAsync(groupProductiveId,true);

            }
            
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> getProfession(string GroupProfession)
        {
            List<Profession> model;

            if (GroupProfession == null)
            {
                model = await _professionHelper.ComboAsync();

                return Json(model);
            }
            else
            {
                GroupProfession = GroupProfession.Substring(0, GroupProfession.Length - 1);

                string[] groupProfessionId = GroupProfession.Split(',').Select(d => d.ToString()).ToArray();

                model = await _professionHelper.ComboAsync(groupProfessionId,true);

            }
            
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> getProductive(string GroupProductive)
        {
            List<GroupProductive> model;

            if (GroupProductive == null)
            {
                model = await _productiveHelper.ComboAsync();
            }
            else
            {
                GroupProductive = GroupProductive.Substring(0, GroupProductive.Length - 1);

                string[] groupProductiveId = GroupProductive.Split(',').Select(d => d.ToString()).ToArray();

                model = await _productiveHelper.ComboAsync(groupProductiveId,true);

            }
            
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> getSocialNetwork(string SocialNetwork)
        {
            List<SocialNetwork> model;
            if (SocialNetwork == null)
            {
                model = await _socialNetworkHelper.ComboAsync();
            }
            else
            {
                SocialNetwork = SocialNetwork.Substring(0, SocialNetwork.Length - 1);

                string[] SocialNetworkName = SocialNetwork.Split(',').Select(d => d.ToString()).ToArray();

                model = await _socialNetworkHelper.ComboAsync(SocialNetworkName,true);
            }
            
            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> ProductiveAdd(int id, int GroupProductiveId)
        {
            AffiliateGroupProductive model = new AffiliateGroupProductive()
            {
                AffiliateId = id,
                GroupProductiveId = GroupProductiveId
            };

            Response response = await _affiliateGroupProductiveHelper.AddUpdateAsync(model);

            return Json(new { res = true });

        }
        [HttpPost]
        public async Task<JsonResult> ProductiveDelete(int GroupProductiveId)
        {
            Response response = await _affiliateGroupProductiveHelper.DeleteAsync(GroupProductiveId);

            return Json(new { res = response.Succeeded});
        }


        [HttpPost]
        public async Task<JsonResult> GroupCommunityAdd(int id, int GroupCommunityId)
        {
            AffiliateGroupCommunity model = new AffiliateGroupCommunity()
            {
                AffiliateId = id,
                GroupCommunityId = GroupCommunityId
            };

            Response response = await _AffiliateGroupCommunityHelper.AddUpdateAsync(model);

            return Json(new { res = response.Succeeded });

        }
        [HttpPost]
        public async Task<JsonResult> GroupCommunityDelete(int GroupCommunityId)
        {
            Response response = await _AffiliateGroupCommunityHelper.DeleteAsync(GroupCommunityId);

            return Json(new { res = response.Succeeded});
        }


        [HttpPost]
        public async Task<JsonResult> ProfessionAdd(int id, int ProfessionId,IFormFile ImagePath,string Concept, IFormFile DocumentoPath)
        {
            AffiliateProfessionViewModels model = new AffiliateProfessionViewModels()
            {
                AffiliateProfessionId=0,
                AffiliateId = id,
                ProfessionId= ProfessionId,
                ImagePath=ImagePath,
                Concept = Concept,
                DocumentoPath=DocumentoPath
            };

            Response response = await _affiliateProfessionHelper.AddUpdateAsync(model);

            return Json(new { res = response.Succeeded });

        }
        [HttpPost]

        public async Task<JsonResult> ProfessionDelete(int ProfessionId)
        {
            Response response = await _affiliateProfessionHelper.DeleteAsync(ProfessionId);

            return Json(new { res = response.Succeeded});
        }



        [HttpPost]
        public async Task<IActionResult> UploadeTemp(IFormFile fileImg, IFormFile fileDoc)
        {
            string path = _configuration["MyFolders:AfiliateTemp"];

            string responseImg = await _imageHelper.UploadImageAsync(fileImg, path);

            string responseDoc = await _imageHelper.UploadFileAsync(fileDoc, path);

            return Json(new { pathImg = responseImg, pathDoc = responseDoc });
        }

        [HttpPost]
        public IActionResult DeleteTemp(string fileImg, string filePdf)
        {
            string path = _configuration["MyFolders:AfiliateTemp"];

            int startFile = fileImg.LastIndexOf("/") + 1;

            string pathFile = fileImg.Substring(startFile, fileImg.Length - startFile);

            pathFile = Path.Combine(_env.WebRootPath, path, pathFile);

            FileInfo fi = new FileInfo(pathFile);

            if (fi != null)
            {
                System.IO.File.Delete(pathFile);
                fi.Delete();
            }

            startFile = filePdf.LastIndexOf("/") + 1;

            pathFile = filePdf.Substring(startFile, filePdf.Length - startFile);

            pathFile = Path.Combine(_env.WebRootPath, path, pathFile);


            FileInfo fiPdf = new FileInfo(pathFile);
            if (fiPdf != null)
            {
                System.IO.File.Delete(pathFile);
                fiPdf.Delete();
            }

            return Json(new { path = "Ok" });
        }


        private List<TypeUserModelsView> typeUser()
        {
            List<TypeUserModelsView> typeUser = new List<TypeUserModelsView>();
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "P", TypeUserName = "Persona" });
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "E", TypeUserName = "Empresa" });
            typeUser.Add(new TypeUserModelsView() { TypeUserId = "", TypeUserName = "[Selecciones Tipo...]" });

            return typeUser.OrderBy(t => t.TypeUserName).ToList();

        }
    }
}
