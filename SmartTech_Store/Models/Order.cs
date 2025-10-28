using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTech_Store.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public double TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string? Address { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }



    }
}
