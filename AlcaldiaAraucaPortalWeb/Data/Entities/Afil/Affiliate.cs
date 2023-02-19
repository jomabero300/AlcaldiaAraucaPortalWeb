using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("Affiliates", Schema = "Afil")]
    public class Affiliate
    {
        [Key]
        public int AffiliateId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [MaxLength(450, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column(TypeName = "char(1)")]
        [Display(Name = "Tipo")]
        [MaxLength(1, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string TypeUserId { get; set; }

        [Column(TypeName = "varchar(60)")]
        [Display(Name = "Nombre")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(13)")]
        [Display(Name = "Identificación")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nit { get; set; }

        [Column(TypeName = "varchar(60)")]
        [Display(Name = "Dirección")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(13)")]
        [Display(Name = "Teléfono")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(13)")]
        [Display(Name = "Móvil")]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string CellPhone { get; set; }

        [Column(TypeName = "varchar(60)")]
        [Display(Name = "Email")]
        [MaxLength(60, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico inválida")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Foto")]
        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string ImagePath { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<AffiliateGroupCommunity> GroupCommunities { get; set; } = new List<AffiliateGroupCommunity>();
        public virtual List<AffiliateGroupProductive> GroupProductives { get; set; } = new List<AffiliateGroupProductive>();
        public virtual List<AffiliateProfession> Professions { get; set; } = new List<AffiliateProfession>();
        public virtual List<AffiliateSocialNetwork> SocialNetworks { get; set; } = new List<AffiliateSocialNetwork>();

    }
}