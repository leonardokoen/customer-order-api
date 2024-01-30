using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrder.Domain.Entities
{
    public class Order : IIdentifiable
    { 
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public float TotalCost { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
