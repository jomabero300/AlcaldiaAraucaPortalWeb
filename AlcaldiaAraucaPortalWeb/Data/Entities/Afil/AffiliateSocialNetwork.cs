using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("AffiliateSocialNetworks", Schema = "Afil")]
    public class AffiliateSocialNetwork
    {
        [Key]
        public int AffiliateSocialNetworkId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Afiliado")]
        public int AffiliateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Red social")]
        public int SocialNetworkId { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Url")]
        public string AffiliateSocialNetworURL { get; set; }

        public virtual Affiliate Affiliate { get; set; }
        public virtual SocialNetwork SocialNetwork { get; set; }

    }
}