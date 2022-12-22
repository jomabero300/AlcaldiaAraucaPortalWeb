using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewCont
{
    public class ContentModelsViewContPren : ContentModelsViewCont
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Linea estrategica")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }
    }
}
