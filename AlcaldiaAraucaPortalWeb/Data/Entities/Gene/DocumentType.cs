using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlcaldiaAraucaPortalWeb.Data.Entities.Gene
{
    [Table("DocumentTypes", Schema = "Gene")]
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "El máximo tamaño del campo {0} es {1} caractéres")]
        [Display(Name = "Descripción")]
        public string DocumentTypeName { get; set; }
    }
}
