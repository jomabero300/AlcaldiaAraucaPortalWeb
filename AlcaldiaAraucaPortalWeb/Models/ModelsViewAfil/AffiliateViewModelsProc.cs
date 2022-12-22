using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateViewModelsProc
    {
        public int AffiliateId { get; set; }

        [Display(Name = "Tipo")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string TypeUserId { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Identificación")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nit { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Address { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Phone { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string CellPhone { get; set; }

        [Display(Name = "Email")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico inválida")]
        public string Email { get; set; }

        [Display(Name = "Foto")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public IFormFile ImagePath { get; set; }

        public virtual List<AffiliateGroupProductiveViewModelsProc> Productivo { get; set; } = new List<AffiliateGroupProductiveViewModelsProc>();
        public virtual List<AffiliateGroupCommunityViewModelsProc> Comuntario { get; set; } = new List<AffiliateGroupCommunityViewModelsProc>();
        public virtual List<AffiliateProfessionViewModelsProc> Professions { get; set; } = new List<AffiliateProfessionViewModelsProc>();
        public virtual List<AffiliateSocialNetworkViewModelsProc> SocialNetwork { get; set; } = new List<AffiliateSocialNetworkViewModelsProc>();

    }
}
