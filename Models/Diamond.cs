namespace DiamondsApi.Models
{
    public class Diamond
    {
        public long Id { get; set; }
        public string Shape { get; set; }
        public float Size { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public float Price { get; set; }
        public float ListPrice { get; set; }
    }
}