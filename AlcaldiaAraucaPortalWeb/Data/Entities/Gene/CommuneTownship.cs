using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("CommuneTownships", Schema = "Gene")]
    public class CommuneTownship
    {
        [Key]
        public int CommuneTownshipId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Municipio")]
        public int MunicipalityId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Zona")]
        public int ZoneId { get; set; }

        [Column(TypeName = "varchar(80)")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        public string CommuneTownshipName { get; set; }

        public virtual Zone Zone { get; set; }

        public virtual Municipality Municipality { get; set; }


    }
}
