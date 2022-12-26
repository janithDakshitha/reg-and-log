using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class UniAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UniAdminModel uniAdminModel)
        {
            string connection = "Data Source=DESKTOP-3QGNVSM;Initial Catalog=BestVsBestReg;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            using(SqlConnection sqlconn=new SqlConnection(connection))
            {
                string sqlquery = "insert into UniAdMin(Username,Uemail,Pwd) values ('" + uniAdminModel.Username + "','" + uniAdminModel.Uemail + "','" + uniAdminModel.Pwd + "')";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                    ViewData["Message"] = "The New University Admin " + uniAdminModel.Username + " Is Saved Successfully..!";
                }
            }
            return View(uniAdminModel);
        }
    }
}
