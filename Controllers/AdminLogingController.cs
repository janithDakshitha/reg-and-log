using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Security;

using System.Collections.Specialized;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Configuration;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class AdminLogingController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
        //[AllowAnonymous]
        [HttpPost]
        public IActionResult Index(UniAdminLoging log)
        {
            string mainconn = "Data Source=DESKTOP-3QGNVSM;Initial Catalog=BestVsBestReg;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            //string mainconn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ////string mainconn = ConfigurationManager.ConnectionString["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn =new SqlConnection(mainconn);
            string sqlquery = "select Uemail,Pwd from [dbo].[UniAdmin] where Uemail=@Email and Pwd=@Password";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            //SqlCommand sqlcomm = new SqlCommand("[dbo].[UserLogin]");
            //sqlconn.Open();
            //sqlcomm.Connection= sqlconn;
            //sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.AddWithValue("@Email", log.Email);
            sqlcomm.Parameters.AddWithValue("@Password", log.Password);
            //sqlcomm.Parameters.("@U_Id", log.U_Id);
            SqlDataReader sdr =sqlcomm.ExecuteReader();
            if(sdr.Read())
            {
                HttpContext.Session.SetString("username", log.Email);
                //Session["username"] = log.UserName.ToString();
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed";
            }
            sqlconn.Close();
            return View();
        }
        public ActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();    
        }

    }
}
