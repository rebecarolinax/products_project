using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.productsproject.Domains
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid IDProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Product name is mandatory")]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        [Required(ErrorMessage = "Product price is mandatory!")]
        public decimal Price { get; set; }
    }
}
