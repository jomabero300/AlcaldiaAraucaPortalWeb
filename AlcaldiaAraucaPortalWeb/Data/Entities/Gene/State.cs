using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("States", Schema = "Gene")]
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Column(TypeName = "char(1)")]
        [MaxLength(1, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de estado")]
        public string StateType { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Activo/Inactivo")]
        public bool StateB { get; set; }
        //public virtual ICollection<Subscriber> Subscriber { get; set; }
        public virtual ICollection<SubscriberSector> SubscriberSectors { get; set; }
    }
}
