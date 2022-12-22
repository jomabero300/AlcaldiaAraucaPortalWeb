using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateGroupProductiveViewModelsProc
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Gupo productivo")]
        public int GroupProductiveId { get; set; }
        public virtual GroupProductive GroupProductive { get; set; }
    }
}