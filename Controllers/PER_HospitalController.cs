using Road_Safety.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Accident_Info.Controllers
{
    public class PER_HospitalController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public PER_HospitalController(IConfiguration _configuration)

        {
            Configuration = _configuration;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            #region SelectAll
            string str = this.Configuration.GetConnectionString("MyConnectionString");
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(str);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_PER_Hospital_SelectAll";
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();

            return View("PER_HospitalList", dt);
            #endregion
        }
        #endregion

      
    }
}