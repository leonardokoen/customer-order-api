using System.ComponentModel.DataAnnotations;

namespace CustomerOrder.Domain.Entities
{
    public class Product
    {
        [Key]   
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public float Price { get; set; } = 0.0f;

    }
}
