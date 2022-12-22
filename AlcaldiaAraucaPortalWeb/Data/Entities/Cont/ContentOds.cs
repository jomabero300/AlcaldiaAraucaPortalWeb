using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Cont
{
    [Table("ContentOds", Schema = "Cont")]
    public class ContentOds
    {
        [Key]
        public int ContentOdsId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int PqrsStrategicLineSectorId { get; set; }

        [Column(TypeName = "varchar(150)")]
        [MaxLength(150, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Descripción")]
        public string ContentOdsText { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Imagen")]
        public string ContentOdsImg { get; set; }

        [Column(TypeName = "varchar(150)")]
        [MaxLength(150, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string ContentOdsUrl { get; set; }

        public virtual PqrsStrategicLineSector PqrsStrategicLineSector { get; set; }
    }
}
