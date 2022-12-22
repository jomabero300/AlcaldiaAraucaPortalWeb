using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("AffiliateGroupProductives", Schema = "Afil")]
    public class AffiliateGroupProductive
    {
        [Key]
        public int AffiliateGroupProductiveId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Afiliado")]
        public int AffiliateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Gupo productivo")]
        public int GroupProductiveId { get; set; }

        public virtual Affiliate Affiliate { get; set; }
        public virtual GroupProductive GroupProductive { get; set; }

    }
}