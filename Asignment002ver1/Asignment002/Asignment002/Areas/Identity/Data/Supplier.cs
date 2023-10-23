using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asignment002.Areas.Identity.Data
{
    [Table("Suppliers")]
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
