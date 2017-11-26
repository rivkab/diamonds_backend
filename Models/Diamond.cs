namespace DiamondsApi.Models
{
    public class Diamond
    {
        public long Id { get; set; }
        public string Shape { get; set; }
        public double Size { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public double Price { get; set; }
        public double ListPrice { get; set; }
    }
}