using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewCont
{
    public class ContentEditViewModel
    {
        public int ContentId { get; set; }
        public string UserId { get; set; }
        public DateTime ContentDate { get; set; }
        public int StateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Sector")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineSectorId { get; set; }

        [MaxLength(120, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Titulo")]
        public string ContentTitle { get; set; }

        [MaxLength(300, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Contenido")]
        public string ContentText { get; set; }

        //[MinFileSize(125), MaxFileSize(5 * 1024 * 1024)]
        //[AllowedExtensions(new[] { ".jpg", ".png", ".gif", ".jpeg", ".tiff" })]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public IFormFile ContentUrlImg { get; set; }
        public string ContentUrlImg1 { get; set; }


        public virtual List<ContentDetail> ContentDetails { get; set; } = new List<ContentDetail>();
    }
}
