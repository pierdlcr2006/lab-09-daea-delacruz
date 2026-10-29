using System.ComponentModel.DataAnnotations;

namespace LaboratorioCRUDProductos.Models
{
    public class ProductoModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "El Id debe ser mayor que cero.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "El precio no puede ser negativo.")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
    }
}
