using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Alar
{
    [Table("PqrsStrategicLineSectors", Schema = "Alar")]
    public class PqrsStrategicLineSector
    {
        [Key]
        public int PqrsStrategicLineSectorId { get; set; }

        [Display(Name = "Linea estrategica")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }

        [Column(TypeName = "varchar(60)")]
        [MaxLength(60, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Linea estratégica")]
        public string PqrsStrategicLineSectorName { get; set; }

        public virtual PqrsStrategicLine PqrsStrategicLine { get; set; }
        public virtual ICollection<SubscriberSector> SubscriberSectors { get; set; }

    }
}
