using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTech_Store.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Description { get; set; }


        [ForeignKey("Brand")]

        public int? BrandId { get; set; }


        public Brand? Brand { get; set; }


    }
}
