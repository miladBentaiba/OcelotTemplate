using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAtteindanceManagement.Models;

namespace StudentAtteindanceManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StudentAttendance> Get()
        {
            StudentAttendance st1 = new StudentAttendance();
            StudentAttendance st2 = new StudentAttendance();

            st1.StudentID = 1;
            st1.Name = "Adam";
            st1.Percentage = 83.02;

            st2.StudentID = 2;
            st2.Name = "Brad";
            st2.Percentage = 71.02;

            List<StudentAttendance> stList = new List<StudentAttendance>
            {
                st1,
                st2
            };

            return stList;
        }
    }
}
