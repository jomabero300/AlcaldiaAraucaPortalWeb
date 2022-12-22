using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateSocialNetworkViewModelsProc
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Red social")]
        public int SocialNetworkId { get; set; }

        [MaxLength(50, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string SocialNetworURL { get; set; }
        public virtual SocialNetwork SocialNetwork { get; set; }
    }
}