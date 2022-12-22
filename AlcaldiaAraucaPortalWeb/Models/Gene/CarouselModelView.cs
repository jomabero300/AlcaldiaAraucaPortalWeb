using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.Gene
{
    public class CarouselModelView
    {
        [MaxLength(50, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public string ImageName { get; set; }
    }

    public class CarouselModelViewList
    {
        public List<CarouselModelView> carousels { get; set; }
        public List<ContentModelView> contents { get; set; }
    }
    public class CarouselImage
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public IFormFile Image { get; set; }
    }

}
