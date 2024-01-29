using System.ComponentModel.DataAnnotations;

namespace CustomerOrder.Domain.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
