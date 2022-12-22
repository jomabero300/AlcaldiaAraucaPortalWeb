using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateProfessionViewModelsProc
    {
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Descripción")]
        public string Concept { get; set; }

        [Display(Name = "Camara de Comercio")]
        public string DocumentoPath { get; set; }

        public virtual Profession Profession { get; set; }
    }
}