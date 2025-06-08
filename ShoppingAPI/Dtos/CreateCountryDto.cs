using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Dtos
{
    public class CreateCountryDto
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Name { get; set; }
    }
}
