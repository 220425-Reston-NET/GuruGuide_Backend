namespace GuruGuideModles
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } //its how many times we can provide service per day.

        public Service()
        {
            ServiceId = 0;
            ServiceName = "Default";
            Price = 0;
            Quantity = 0;
        }
    }
}