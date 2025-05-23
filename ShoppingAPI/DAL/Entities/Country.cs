using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name ="País: ")]
        [MaxLength(50, ErrorMessage ="El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage ="Campo obligatorio.")]
       public string Name { get; set; } 
    }
    
    
}
