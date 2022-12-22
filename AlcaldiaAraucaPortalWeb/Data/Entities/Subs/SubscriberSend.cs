using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Subs
{
    [Table("SubscriberSend", Schema = "Subs")]
    public class SubscriberSend
    {
        [Key]
        public int SubscriberSendId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Sector")]
        public int SubscriberSectorId { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public virtual SubscriberSector SubscriberSector { get; set; }
    }
}
