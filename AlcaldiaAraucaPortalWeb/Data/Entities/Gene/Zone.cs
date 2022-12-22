using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("Zones", Schema = "Gene")]
    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string ZoneName { get; set; }
    }
}
