namespace Road_Safety.Models
{
    public class MST_AccidentModel
    {
        public int AccidentID { get; set; }
        public int LocationID { get; set; }
        public int CauseID { get; set; }
        public int SeverityID { get; set; }
        public int WeatherID { get; set; }
        public DateTime AccidentTime { get; set; }
        public int NumberofCasualties { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
