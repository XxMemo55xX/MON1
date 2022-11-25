using Microsoft.AspNetCore.Mvc;
using project2.Models;
using System.Data.SqlClient;

namespace project2.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();

            com.CommandText = "select * from [2019SBD].[s20431].[Student]";
            com.Connection = con;

            con.Open();
            var dr = com.ExecuteReader();
            var students = new List<Student>();
            while(dr.Read())
            {
                var s = new Student();
                s.Name = dr["FirstName"].ToString();
                s.LastName = dr["LastName"].ToString();
                s.Email = dr["Email"].ToString();

                students.Add(s);
            }
            //Business logic
            

            //1.
            //ViewBag.Names = names;
            ViewBag.Title = "Students";

            //2 strongly-typed approach

            return View(students);
        }

        public IActionResult Studies()
        {
            return View();
        }
    }
}
