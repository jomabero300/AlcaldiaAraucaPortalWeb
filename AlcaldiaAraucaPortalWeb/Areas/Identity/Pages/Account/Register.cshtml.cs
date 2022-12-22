// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Enun;

namespace AlcaldiaAraucaPortalWeb.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        private readonly IGenderHelper _genderHelper;
        private readonly IDocumentTypeHelper _documentTypeHelper;
        private readonly IZoneHelper _zoneHelper;
        private readonly ICommuneTownshipHelper _communeTownship;
        private readonly INeighborhoodSidewalkHelper _neighborhoodSidewalk;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _emailHelper;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IGenderHelper genderHelper,
            IDocumentTypeHelper documentTypeHelper,
            IZoneHelper zoneHelper,
            ICommuneTownshipHelper communeTownship,
            INeighborhoodSidewalkHelper neighborhoodSidewalk,
            IUserHelper userHelper,
            IMailHelper emailHelper)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _genderHelper = genderHelper;
            _documentTypeHelper = documentTypeHelper;
            _zoneHelper = zoneHelper;
            _communeTownship = communeTownship;
            _neighborhoodSidewalk = neighborhoodSidewalk;
            _userHelper = userHelper;
            _emailHelper = emailHelper;
        }

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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Correo electrónico")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [EmailAddress(ErrorMessage = "El campo de correo electrónico no es una dirección válida")]
            public string Email { get; set; }

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

            [Display(Name = "Longitud")]
            public string Length { get; set; }

            [Display(Name = "Latitud")]
            public string Latitude { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caractéres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName");
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName");
            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName");
            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(0), "CommuneTownshipId", "CommuneTownshipName");
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(0), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                ApplicationUser user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);

                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                user.Document = Input.Document;

                user.DocumentTypeId = Input.DocumentTypeId;

                user.FirstName = lLowr(Input.FirstName);

                user.LastName = lLowr(Input.LastName);

                user.BirdDarte = Input.BirdDarte;

                user.GenderId = Input.GenderId;

                user.Address = Input.Address;

                user.NeighborhoodSidewalkId = Input.NeighborhoodSidewalkId;

                user.Length=Input.Length;

                user.Latitude = Input.Latitude;

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserType.Usuario.ToString());

                    _logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);
                    
                    Response response= _emailHelper.SendMail(
                                        Input.Email,
                                        "Araucactiva - Confirmación de cuenta",
                                        $"<h1>Araucactiva - Confirmación de cuenta</h1>" +
                                        $"Para habilitar el usuario, " +
                                        $"por favor hacer clic en el siguiente enlace <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Confirmar Email</a>.");
                    
                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewData["GenderId"] = new SelectList(await _genderHelper.ComboAsync(), "GenderId", "GenderName",Input.GenderId);
            ViewData["DocumentTypeId"] = new SelectList(await _documentTypeHelper.ComboAsync(), "DocumentTypeId", "DocumentTypeName",Input.DocumentTypeId);
            ViewData["ZoneId"] = new SelectList(await _zoneHelper.ComboAsync(), "ZoneId", "ZoneName",Input.ZoneId);
            ViewData["CommuneTownshipId"] = new SelectList(await _communeTownship.ComboAsync(Input.ZoneId), "CommuneTownshipId", "CommuneTownshipName",Input.CommuneTownshipId);
            ViewData["NeighborhoodSidewalkId"] = new SelectList(await _neighborhoodSidewalk.ComboAsync(Input.CommuneTownshipId), "NeighborhoodSidewalkId", "NeighborhoodSidewalkName",Input.NeighborhoodSidewalkId);

            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"No se puede crear una instancia de '{nameof(ApplicationUser)}'. " +
                    $"Asegurarse de que '{nameof(ApplicationUser)}' no es una clase abstracta y tiene un constructor sin parámetros, o alternativamente " +
                    $"anular la página de registro en /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        private string lLowr(string cadena)
        {
            if (cadena.Length > 0)
            {
                var letra = cadena.Substring(0, 1).ToUpper();

                cadena = letra + cadena.Substring(1, cadena.Length - 1);
            }

            return cadena;
        }
    }
}
