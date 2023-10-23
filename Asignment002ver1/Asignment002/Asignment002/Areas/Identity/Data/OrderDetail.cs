using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asignment002.Areas.Identity.Data
{
    [Table("Order_Details")]
    public class OrderDetail

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }

        public virtual Product Product { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

    }
}
