using System.Data;
using System.Data.SqlClient;

namespace kristofferhusdata.Data
{
    public class ClimateInformationService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        public async Task<List<ClimateInformation>> GetClimateInformation()
        {
            DatabaseQuerys db = new DatabaseQuerys();
            SqlCommand command = new SqlCommand();
            DataTable dt;

            command = new SqlCommand("SELECT * FROM ClimateInformation");
            dt = db.PullTable(command);



            //int totalRows = dt.Rows.Count;
            var climateInformation = new List<ClimateInformation>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    climateInformation.Add(new ClimateInformation()
            //    {
            //        Date = (string)row[0],
            //        Temperature = (int)row[1],
            //        Humidity = (int)row[2]
            //    });
            //}
            return climateInformation;
        }
    }
}