using System.ComponentModel.DataAnnotations;

namespace CustomerOrder.Domain.Entities
{
    public class Customer : IIdentifiable 
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
