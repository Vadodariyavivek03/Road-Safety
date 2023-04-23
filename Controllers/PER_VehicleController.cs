﻿using Road_Safety.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Accident_Info.Controllers
{
    public class PER_VehicleController : Controller
    {
            #region Configuration
            private IConfiguration Configuration;
            public PER_VehicleController(IConfiguration _configuration)

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
                cmd.CommandText = "PR_PER_Vehical_SelectAll";
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                conn.Close();

                return View("PER_VehicleList", dt);
                #endregion
            }
            #endregion

      
        }
    }