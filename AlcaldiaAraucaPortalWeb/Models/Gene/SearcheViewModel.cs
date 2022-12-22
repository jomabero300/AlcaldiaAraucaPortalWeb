using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.Gene
{
    public class SearcheViewModel
    {
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Busqueda")]
        public string Search { get; set; }
    }
}
