using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asignment002.Areas.Identity.Data
{
    [Table("Products")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        [ForeignKey(nameof(Supplier))]
        public int? SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategogyID { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public string? ProductImage { get; set; }

    }
}
