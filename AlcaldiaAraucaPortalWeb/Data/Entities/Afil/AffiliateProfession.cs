using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Afil
{
    [Table("AffiliateProfessions", Schema = "Afil")]
    public class AffiliateProfession
    {
        public int AffiliateProfessionId { get; set; }

        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Afiliado")]
        public int AffiliateId { get; set; }

        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesión")]
        public int ProfessionId { get; set; }

        [Column(TypeName = "varchar(200)")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Camara de Comercio")]
        public string Concept { get; set; }

        [Column(TypeName = "varchar(200)")]
        //[Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(200, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Camara de Comercio")]
        public string DocumentoPath { get; set; }

        public virtual Affiliate Affiliate { get; set; }
        public virtual Profession Profession { get; set; }
    }
}