namespace SmartTech_Store.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Shop>? Shops { get; set; }
    }
}
