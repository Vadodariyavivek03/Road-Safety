namespace Road_Safety.Models
{
    public class LOC_LocationModel
    {
        public int LocationID { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string EmergencyNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
