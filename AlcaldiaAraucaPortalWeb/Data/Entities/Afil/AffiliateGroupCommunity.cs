using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("AffiliateGroupCommunities", Schema = "Afil")]
    public class AffiliateGroupCommunity
    {
        [Key]
        public int AffiliateGroupCommunityId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Afiliado")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int AffiliateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Grupo comunatario")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int GroupCommunityId { get; set; }

        public virtual Affiliate Affiliate { get; set; }
        public virtual GroupCommunity GroupCommunity { get; set; }
    }
}
