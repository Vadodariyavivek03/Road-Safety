using Road_Safety.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Accident_Info.Controllers
{
    public class MST_AccidentController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public MST_AccidentController(IConfiguration _configuration)

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
            cmd.CommandText = "PR_MST_Accident_SelectAll";
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();

            return View("MST_AccidentList", dt);
            #endregion
        }
        #endregion

    }
}