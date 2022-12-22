using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Alar
{
    [Table("PqrsStrategicLines", Schema = "Alar")]
    public class PqrsStrategicLine
    {
        [Key]
        public int PqrsStrategicLineId { get; set; }

        [Column(TypeName = "varchar(40)")]
        [MaxLength(40, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Linea estratégica")]
        public string PqrsStrategicLineName { get; set; }
    }
}
