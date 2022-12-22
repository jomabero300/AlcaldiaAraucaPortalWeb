using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Alar
{

    [Table("PqrsUserStrategicLines", Schema = "Alar")]
    public class PqrsUserStrategicLine
    {
        [Key]
        public int PqrsUserStrategicLineId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [MaxLength(450, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Linea estrategica")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PqrsStrategicLineId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Estado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int StateId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PqrsStrategicLine PqrsStrategicLine { get; set; }
        public virtual State State { get; set; }
        //public virtual ICollection<PqrsTraceability> PqrsTraceabilities { get; set; }

    }
}
