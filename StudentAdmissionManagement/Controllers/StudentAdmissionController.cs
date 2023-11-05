using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagement.Models;

namespace StudentAdmissionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAdmissionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StudentAdmission> Get()
        {
            StudentAdmission st1 = new StudentAdmission();
            StudentAdmission st2 = new StudentAdmission();

            st1.StudentID = 1;
            st1.Name = "Adam";
            st1.Class = "X";
            st1.DateJoined = DateTime.Now;

            st2.StudentID = 2;
            st2.Name = "Brad";
            st2.Class = "IX";
            st2.DateJoined = DateTime.Now;

            List<StudentAdmission> stList = new List<StudentAdmission>
            {
                st1,
                st2
            };

            return stList;
        }
    }
}
