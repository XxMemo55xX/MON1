using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MON1_tut2.Models;
using System.Data.SqlClient;

namespace MON1_tut2.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();
        static StudentsController()
        {
            _students.Add(new Student
            {
                IdStudent = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "doe@wp.pl",
                IndexNumber = "s1234"
            });
            _students.Add(new Student
            {
                IdStudent = 2,
                FirstName = "Anne",
                LastName = "Doe",
                Email = "anne@wp.pl",
                IndexNumber = "s4321"
            });
        }

        //Get list of students
        [HttpGet]
        public IActionResult GetStudents( string orderByColumn)
        {
            //OkResult result = Ok();
            //return result; //200 OK HTTP

            //connection to remote db

            SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=2019SBD;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from student";

            //send the sql 
            con.Open();
            SqlDataReader dr = com.ExecuteReader();

            //get the result back
            List<Student> names = new List<Student>();
            while (dr.Read())
            {
                var st = new Student();
                st.LastName = dr["LastName"].ToString();
                names.Add(st);
            }
            //return the result as JSON
            return Ok(names);
        }

        //Get details of students
        [HttpGet("{studentId}")]
        public IActionResult GetSingleStudent( int studentId)
        {
            Student st = null;
            foreach(Student s in _students)
            {
                if (s.IdStudent == studentId)
                {
                    return Ok(s);
                }
            }

            return NotFound($"Student with the id {studentId} was not found");
            
        }

        //Add new student - POST
        [HttpPost]
        public IActionResult AddNewStudent(Student newStudent)
        {
            //... saving  to db
            newStudent.IdStudent = new Random().Next(10000);
            _students.Add(newStudent);

            return Ok(newStudent);
        }

        //Update student - PUT
        [HttpPut("{idStuent}")]
        public IActionResult UpdateStudent(int idStudent, Student updateData)
        {
            if (idStudent != updateData.IdStudent)
            {
                return BadRequest($"Id: ({idStudent}) in the URL is not matching the id in the request body {updateData.IdStudent}");
            }
            //1. Find the student we want to update (404 otherwise)
            foreach(var student in _students)
            {
                if(student.IdStudent==updateData.IdStudent)
                {
                    //2. Update th values describing the student

                    student.FirstName = updateData.FirstName;
                    student.LastName = updateData.LastName;
                    student.Email = updateData.Email;
                    student.IndexNumber = updateData.IndexNumber;

                    return Ok(student);
                }
            }

                return NotFound($"Student with the id {updateData.IdStudent} cannot be found");

        }

        //remove stuent - DELETE
        [HttpDelete("{idStudent}")]
        public IActionResult DeleteStudent(int idStudent)
        {
            //1. Find the student we want to update (404 otherwise)
            var student = FindStudent(idStudent);
            if (student == null)
            {
            return NotFound($"Student with the id {idStudent} cannot be found");
            }

            //2. delete the student
            _students.Remove(student);
            return Ok(student);

        }

        private Student FindStudent(int idStudentToFind)
        {
            foreach (var student in _students)
            {
                if(student.IdStudent==idStudentToFind)
                {
                    return student;
                    }
            }
            return null;
        }


    }
}
