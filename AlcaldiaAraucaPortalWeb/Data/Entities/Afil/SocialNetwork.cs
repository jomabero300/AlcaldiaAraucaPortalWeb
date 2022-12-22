using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("SocialNetworks", Schema = "Afil")]
    public class SocialNetwork
    {
        [Key]
        public int SocialNetworkId { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Descripción")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string SocialNetworkName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Estado")]
        public int StateId { get; set; }

        public virtual State State { get; set; }
    }
}