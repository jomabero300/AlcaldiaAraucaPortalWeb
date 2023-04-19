using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Helpers.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Cont;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewCont;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;

namespace AlcaldiaAraucaPortalWeb.Controllers.Cont
{
    public class ContentsController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IContentHelper _contentHelper;
        private readonly IPqrsUserStrategicLineHelper _userStrategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineHelper;
        private readonly IPqrsStrategicLineSectorHelper _strategicLineSectorHelper;
        private readonly IFolderStrategicLineasHelper _folderStrategicLineasHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IUtilitiesHelper _utilitiesHelper;


        public ContentsController(IContentHelper contentHelper,
                                IPqrsUserStrategicLineHelper userStrategicLineHelper,
                                IPqrsStrategicLineSectorHelper strategicLineHelper,
                                IImageHelper imageHelper,
                                IFolderStrategicLineasHelper folderStrategicLineasHelper,
                                IConfiguration configuration,
                                IPqrsStrategicLineSectorHelper strategicLineSectorHelper,
                                IUtilitiesHelper utilitiesHelper)
        {
            _contentHelper = contentHelper;
            _userStrategicLineHelper = userStrategicLineHelper;
            _strategicLineHelper = strategicLineHelper;
            _imageHelper = imageHelper;
            _folderStrategicLineasHelper = folderStrategicLineasHelper;
            _configuration = configuration;
            _strategicLineSectorHelper = strategicLineSectorHelper;
            _utilitiesHelper = utilitiesHelper;
        }

        public async Task<IActionResult> Index()
        {
            string linea = await LineName();

            if (linea == null)
            {
                return NotFound();
            }

            ViewBag.LineName = linea;

            List<Content> model = await _contentHelper.ListUserAsync(User.Identity.Name);

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Content model = await _contentHelper.ByUserIdAsync(User.Identity.Name,(int)id);

            Content model = await _contentHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            string lineName = await LineName();

            if (lineName == null)
            {
                return NotFound();
            }

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineHelper.ComboAsync(User.Identity.Name), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ViewBag.LineName = lineName;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContentModelsViewCont model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.Name;

                Response response = await _contentHelper.AddAsync(model);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineHelper.ComboAsync(User.Identity.Name), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content content = await _contentHelper.ByIdAsync((int)id);

            if (content == null)
            {
                return NotFound();
            }

            ContentEditViewModel model = new ContentEditViewModel()
            {
                ContentId = content.ContentId,
                UserId = content.UserId,
                ContentDate = content.ContentDate,
                StateId = content.StateId,
                PqrsStrategicLineSectorId = content.PqrsStrategicLineSectorId,
                ContentTitle = content.ContentTitle,
                ContentText = content.ContentText,
                ContentUrlImg1 = content.ContentUrlImg,
                ContentDetails = content.ContentDetails,
            };

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineHelper.ComboAsync(User.Identity.Name), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ViewBag.LineName = await LineName(); 

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContentEditViewModel model)
        {
            if (id != model.ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.Name;

                Response response =await _contentHelper.UpdateAsync(model);

                if(response.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError(string.Empty, response.Message);
            }

            ViewData["PqrsStrategicLineSectorId"] = new SelectList(await _strategicLineHelper.ComboAsync(User.Identity.Name), "PqrsStrategicLineSectorId", "PqrsStrategicLineSectorName");

            ViewBag.LineName = await LineName();

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content model=await _contentHelper.ByIdAsync((int)id);

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
            List<string> img = await _contentHelper.ByImageAsync(id);

            Content model = await _contentHelper.ByIdAsync(id);

            if(model == null)
            { return NotFound(); }

            Response response =await _contentHelper.DeleteAsync(id);

            if(response.Succeeded)
            {
                if (img != null)
                {
                    string folder = await _folderStrategicLineasHelper.FolderPathAsync(model.PqrsStrategicLineSectorId, User.Identity.Name);

                    foreach (string item in img)
                    {
                        await _imageHelper.DeleteImageAsync(item, folder);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.Message);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddContentDetalle(int id, string Title, string ContentText, IFormFile file, string fileUrl)
        {
            //TODO: Agregar las imagenes
            Content lineaSector = await _contentHelper.ByIdAsync(id);
            string imgUrl = fileUrl;

            if (Title.Contains("http"))
            {
                Title =Common.Utilities.ConvertToTextInLik(Title);
            }
            if (ContentText.Contains("http"))
            {
                ContentText = Common.Utilities.ConvertToTextInLik(ContentText);
            }

            if (file != null)
            {
                string folder = await _folderStrategicLineasHelper.FolderPathAsync(lineaSector.PqrsStrategicLineSectorId, User.Identity.Name);
                imgUrl = await _imageHelper.UploadImageAsync(file, folder);
            }

            ContentDetail detalle = new ContentDetail
            {
                ContentId = id,
                ContentTitle = Title,
                ContentText = ContentText,
                ContentUrlImg = imgUrl,
                ContentDate = DateTime.Now,
                StateId = 1
            };

            Response response = await _contentHelper.AddEditDetailAsync(detalle);


            return Json(new { status = response.Succeeded });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContentDetalle(int id, string Title, string ContentText, IFormFile file, string fileUrl, int idDetail, string UrlImgOld, DateTime ContentDetailDate)
        {
            ContentDetail detalle=await _contentHelper.DetailsIdAsync(idDetail);

            Content lineaSector = await _contentHelper.ByIdAsync(id);

            PqrsStrategicLineSector linea = await _strategicLineSectorHelper.ByIdAsync(lineaSector.PqrsStrategicLineSectorId);

            string response = string.Empty;

            response = !string.IsNullOrWhiteSpace(fileUrl) ? fileUrl : UrlImgOld;

            if (Title.Contains("http"))
            {
                Title = _utilitiesHelper.ConvertToTextInLik(Title);
            }
            if (ContentText.Contains("http"))
            {
                ContentText = _utilitiesHelper.ConvertToTextInLik(ContentText);
            }

            string folder = file != null || response != UrlImgOld ? await _folderStrategicLineasHelper.FolderPathAsync(linea.PqrsStrategicLineId, lineaSector.PqrsStrategicLineSectorId):"";

            if (file != null)
            {
                response = await _imageHelper.UploadImageAsync(file, folder);
            }
            if (response != UrlImgOld)
            {
                await _imageHelper.DeleteImageAsync(UrlImgOld, folder);
            }

            detalle.ContentTitle = Title;
            detalle.ContentText = ContentText;
            detalle.ContentUrlImg = response;

            Response responsed = await _contentHelper.AddEditDetailAsync(detalle);

            if(!responsed.Succeeded)
            {
                ModelState.AddModelError(string.Empty, responsed.Message);
            }

            return Json(new { status = responsed.Succeeded });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDetails(int id)
        {
            try
            {
                ContentDetail model = await _contentHelper.DetailsIdAsync(id);
                Content content = await _contentHelper.ByIdAsync(model.ContentId);

                var response = await _contentHelper.DeleteDetailsAsync(id);

                //TODO: Eliminar las imagenes
                if (response.Succeeded)
                {
                    string folder = await _folderStrategicLineasHelper.FolderPathAsync(content.PqrsStrategicLineSectorId, User.Identity.Name);

                    string responsE = await _imageHelper.DeleteImageAsync(model.ContentUrlImg, folder);
                }
                return Json(new { status = true });
            }
            catch (System.Exception ex)
            {
                string ltmensaje = string.Empty;
                if (ex.InnerException.Message.Contains("IX_"))
                {
                    ltmensaje = "El registro ya existe..";
                }
                else if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    ltmensaje = "El registro no se puede eliminar porque tiene registros relacionados";
                }
                else
                {
                    ltmensaje = ex.Message;
                }

                return Json(new { status = false, message = ltmensaje });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadeTemp(IFormFile file)
        {
            string folder = _configuration["MyFolders:Content"];

            string response = await _imageHelper.UploadImageAsync(file, folder);
            

            return Json(new { path = response });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTemp(string file)
        {


            var folder = _configuration["MyFolders:Content"];

            string response = await _imageHelper.DeleteImageAsync(file, folder);

            return Json(new { path = "Ok" });
        }

        [HttpGet]
        public async Task<IActionResult> Active(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content model = await _contentHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActiveConfirmed(int id)
        {
            Response response = await _contentHelper.ActiveAsync(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Inactive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content model = await _contentHelper.ByIdAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost, ActionName("Inactive")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InactiveConfirmed(int id)
        {
            Response response = await _contentHelper.InactiveAsync(id);

            if (response.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction(nameof(Index));

        }

        private async Task<string> LineName()
        {
            PqrsStrategicLine model = await _userStrategicLineHelper.PqrsStrategicLineEmaildAsync(User.Identity.Name);
            return model.PqrsStrategicLineName;
        }

        public IActionResult ImportExcelFile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ImportExcelFile(bool esta)
        {

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult ImportExcelFile(IFormFile formFile)
        //{
        //    string mainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadExcelFile");

        //    if (!Directory.Exists(mainPath))
        //    {
        //        Directory.CreateDirectory(mainPath);

        //    }
        //    string filePath = Path.Combine(mainPath, formFile.FileName);

        //    using (FileStream stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        formFile.CopyTo(stream);
        //    }

        //    string fileName = formFile.FileName;

        //    string extension = Path.GetExtension(fileName);

        //    string conString = string.Empty;

        //    switch (extension)
        //    {
        //        case ".xls":
        //            conString = "Provider=Microsoft.Jet.OLDB.4.0; Data Source=" + filePath + ";Extended Properties='Excel 8.0;' HDR=Yes'";
        //            break;
        //        case ".xlsx":
        //            //conString = "Provider=Microsoft.ACE.OLDB.12.0; Data Source=" + filePath + ";Extended Properties='Excel 8.0;' HDR=Yes'";
        //            conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";
        //            break;
        //        default:
        //            break;
        //    }

        //    DataTable dt = new DataTable();

        //    conString = string.Format(conString, filePath);

        //    using (OleDbConnection conExcel = new OleDbConnection(conString))
        //    {
        //        using (OleDbCommand cmdExcel = new OleDbCommand())
        //        {
        //            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
        //            {
        //                cmdExcel.Connection = conExcel;
        //                conExcel.Open();
        //                DataTable dtExcelSchema = conExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //                string sheetName = dtExcelSchema.Rows[0]["Table_Name"].ToString();
        //                cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";
        //                odaExcel.SelectCommand = cmdExcel;
        //                odaExcel.Fill(dt);
        //                conExcel.Close();
        //            }
        //        }
        //    }


        //    return RedirectToAction(nameof(Index));
        //}


    }
}
