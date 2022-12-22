using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("NeighborhoodSidewalks", Schema = "Gene")]
    public class NeighborhoodSidewalk
    {
        public int NeighborhoodSidewalkId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        [Display(Name = "Municipio")]
        public int CommuneTownshipId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Usuario")]
        public string NeighborhoodSidewalkName { get; set; }

        public virtual CommuneTownship CommuneTownship { get; set; }
    }
}
