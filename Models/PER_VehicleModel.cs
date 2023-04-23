namespace Road_Safety.Models
{
    public class PER_VehicleModel
    {
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public string PlateNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
