using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateProfessionViewModels
    {
        public int AffiliateProfessionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Afiliado")]
        public int AffiliateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Imagen")]
        public IFormFile ImagePath { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Camara de Comercio")]
        public string Concept { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Camara de Comercio")]
        public IFormFile DocumentoPath { get; set; }
    }
}
