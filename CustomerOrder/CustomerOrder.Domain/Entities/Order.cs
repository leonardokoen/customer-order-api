using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrder.Domain.Entities
{
    public class Order
    { 
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public List<Guid> ItemIds { get; set; } = null!;

        public List<int> Quantity { get; set; } = null!;
        public float TotalCost { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
