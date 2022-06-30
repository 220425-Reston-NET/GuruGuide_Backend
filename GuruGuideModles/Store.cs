namespace GuruGuideModles
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public List<Service> Services { get; set; }
        public Store()
        {
            StoreId = 0;
            Name = "Default";
            Services = new List<Service>();
        }
    }
}