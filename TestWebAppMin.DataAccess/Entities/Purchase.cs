using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebAppMin.DataAccess.Entities
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
    }
}
