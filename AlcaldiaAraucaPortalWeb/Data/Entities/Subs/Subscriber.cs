using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Subs
{
    [Table("Subscriber", Schema = "Subs")]
    public class Subscriber
    {
        [Key]
        public int SubscriberId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Email Confimar")]
        public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Estado")]
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<SubscriberSector> SubscriberSectors { get; set; }
    }
}
