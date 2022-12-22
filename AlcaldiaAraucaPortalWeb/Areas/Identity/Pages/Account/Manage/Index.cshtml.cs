// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlcaldiaAraucaPortalWeb.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IGenderHelper _genderHelper;
        private readonly IDocumentTypeHelper _documentTypeHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;
        private readonly IUserHelper _userHelper;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IGenderHelper genderHelper,
            IDocumentTypeHelper documentTypeHelper,
            IZoneHelper zoneHelper,
            ICommuneTownshipHelper communeTownship,
            INeighborhoodSidewalkHelper neighborhoodSidewalk,
            IUserHelper userhelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _genderHelper = genderHelper;
            _documentTypeHelper = documentTypeHelper;
            _zoneHelper = zoneHelper;
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
            _userHelper = userhelper;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Display(Name = "Documento")]
            [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            public string Document { get; set; }

            [Display(Name = "Tipo Documento")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int DocumentTypeId { get; set; }

            [Display(Name = "Nombres")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
            public string FirstName { get; set; }

            [Display(Name = "Apellidos")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
            public string LastName { get; set; }

            [Display(Name = "Fecha Nacimiento")]
            [Required(ErrorMessage = "El campo {0} es requerido")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
            public DateTime BirdDarte { get; set; }

            [Display(Name = "Género")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int GenderId { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Display(Name = "Dirección")]
            public string Address { get; set; }

            [Display(Name = "Zona")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int ZoneId { get; set; }

            [Display(Name = "Comuna/Corregimiento")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int CommuneTownshipId { get; set; }

            [Display(Name = "Barrio/Vereda")]
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
            public int NeighborhoodSidewalkId { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;
            
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            NeighborhoodSidewalk neighborhoodSidewalk = await _neighborhoodSidewalk.ByIdAsync(user.NeighborhoodSidewalkId);

            CommuneTownship communeTownship = await _communeTownship.ByIdAsync(neighborhoodSidewalk.CommuneTownshipId);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Document=user.Document,
                DocumentTypeId=user.DocumentTypeId,
                FirstName=user.FirstName,
                LastName=user.LastName,
                BirdDarte=user.BirdDarte,
                GenderId=user.GenderId,
                Address=user.Address,
                NeighborhoodSidewalkId=user.NeighborhoodSidewalkId,
                ZoneId= communeTownship.ZoneId,
                CommuneTownshipId= communeTownship.CommuneTownshipId
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName",user.GenderId);
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName",user.DocumentTypeId);

            NeighborhoodSidewalk neighborhoodSidewalk = await _neighborhoodSidewalk.ByIdAsync(user.NeighborhoodSidewalkId);

            CommuneTownship communeTownship = await _communeTownship.ByIdAsync(neighborhoodSidewalk.CommuneTownshipId);


            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName", communeTownship.ZoneId);
            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(communeTownship.ZoneId), "CommuneTownshipId", "CommuneTownshipName", communeTownship.CommuneTownshipId);
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(communeTownship.CommuneTownshipId), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName", user.NeighborhoodSidewalkId);

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            bool lbEsta = false;
            if (user == null)
            {
                return NotFound($"No se puede cargar el usuario con ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Error inesperado al intentar configurar el número de teléfono.";
            //        return RedirectToPage();
            //    }
            //}
            if (Input.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = Input.PhoneNumber;
                lbEsta= true;
            }
            if (Input.Document != user.Document)
            {
                user.Document = Input.Document;
                lbEsta = true;
            }
            if (Input.DocumentTypeId != user.DocumentTypeId)
            {
                user.DocumentTypeId = Input.DocumentTypeId;
                lbEsta = true;
            }
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
                lbEsta = true;
            }
            if (Input.LastName!= user.LastName)
            {
                user.LastName = Input.LastName;
                lbEsta = true;
            }
            if (Input.GenderId!= user.GenderId)
            {
                user.GenderId = Input.GenderId;
                lbEsta = true;
            }
            if (Input.BirdDarte!= user.BirdDarte)
            {
                user.BirdDarte = Input.BirdDarte;
                lbEsta = true;
            }
            if (Input.Address!= user.Address)
            {
                user.Address = Input.Address;
                lbEsta = true;
            }
            if (Input.NeighborhoodSidewalkId!= user.NeighborhoodSidewalkId)
            {
                user.NeighborhoodSidewalkId = Input.NeighborhoodSidewalkId;
                lbEsta = true;
            }
            if(lbEsta)
            {
                var response = await _userHelper.UpdateUserAsync(user);

                if(!response.Succeeded)
                {
                    StatusMessage = "Error inesperado al intentar actualizar el usuario.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Tu perfil ha sido actualizado";
            return RedirectToPage();
        }
    }
}
