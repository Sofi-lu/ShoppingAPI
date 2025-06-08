using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Pais")]
        public Country? Country { get; set; }

        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; }
    }
}
