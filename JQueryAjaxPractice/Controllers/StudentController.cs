using JQueryAjaxPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace JQueryAjaxPractice.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(StudentModel student)
        {
            if(student is not null)
            {
                ViewBag.Info = $"Hello,{student.LastName} {student.LastName},you are successfully registerd";
            }
           
            return View();
        }
    }
}
