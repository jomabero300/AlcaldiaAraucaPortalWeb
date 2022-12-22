using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Subs
{
    [Table("SubscriberSector", Schema = "Subs")]
    public class SubscriberSector
    {
        [Key]
        public int SubscriberSectorId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Suscriptor")]
        public int SubscriberId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Sector")]
        public int PqrsStrategicLineSectorId { get; set; }
        public int StateId { get; set; }

        [Column(TypeName = "varchar(2)")]
        [MaxLength(2, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Link")]
        public string Url { get; set; }

        public bool SendUrl { get; set; }

        public virtual State State { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public virtual PqrsStrategicLineSector PqrsStrategicLineSector { get; set; }
    }
}