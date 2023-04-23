using Road_Safety.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Accident_Info.Controllers
{
    public class CAU_CauseController : Controller
    {
        #region Configuration
        private IConfiguration Configuration;
        public CAU_CauseController(IConfiguration _configuration)

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
            cmd.CommandText = "PR_CAU_Cause_SelectAll";
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();

            return View("CAU_CauseList", dt);
            #endregion
        }
        #endregion
       
        public IActionResult Add(int? CauseID)
        {
            return View("CAU_CauseAdd");
        }

        [HttpPost]
        public IActionResult Save(CAU_CauseModel modelCAU_Cause)
        {
            if (ModelState.IsValid)
            {

                string str = this.Configuration.GetConnectionString("MyConnectionString");
                SqlConnection conn = new SqlConnection(str);

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_CAU_Cause_Insert";
                cmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add("@CauseDescription", SqlDbType.NVarChar).Value = modelCAU_Cause.CauseDescription;
                cmd.Parameters.Add("@CauseID", SqlDbType.Int).Value = modelCAU_Cause.CauseID;
                cmd.Parameters.Add("@Modification", SqlDbType.DateTime).Value = DBNull.Value;
                //cmd.Parameters.Add("@PhotoPath", SqlDbType.NVarChar).Value = modelCAU_Cause.PhotoPath;

                if (Convert.ToBoolean(cmd.ExecuteNonQuery()))
                {
                    if (modelCAU_Cause.CauseID == null)
                    {
                        TempData["CauseInsertMessage"] = "Cause inserted successfully.";
                    }
                    else
                    {
                        //TempData["ContactInsertMessage"] = "Record Update Successfully";
                        return RedirectToAction("Index");
                    }
                }
                conn.Close();
            }

            return RedirectToAction("Index"); //Add
        }


    }
        }
