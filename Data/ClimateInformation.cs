using System.Runtime.Serialization;

namespace kristofferhusdata.Data
{
    public class ClimateInformation
    {
        public string DateStamp { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

    }
}