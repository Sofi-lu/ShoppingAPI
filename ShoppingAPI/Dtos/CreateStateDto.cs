using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Dtos
{
    public class CreateStateDto
    {
        [Required(ErrorMessage = "Campo obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public Guid CountryId { get; set; }
    }
}
