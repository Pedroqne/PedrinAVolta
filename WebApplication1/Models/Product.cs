using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsActive { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
