using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asignment002.Areas.Identity.Data
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Asignment002User))]
        public int OrderID { get; set; }
        //account
        public virtual Asignment002User Account { get; set; } = null!;


        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Freight { get; set; }

        public string? ShipAdress { get; set; }

        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

    }
}
