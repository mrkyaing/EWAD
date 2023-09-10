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
                ViewBag.Info = $"Hello,{student.LastName} {student.LastName},you are successfully registerd.\n your home address is {student.HomeAddress.Country},{student.HomeAddress.City},{student.HomeAddress.Township},{student.HomeAddress.PostalCode},{student.HomeAddress.Street}.";
            }
            return View();
        }

        public IActionResult MultiStudent() => View();
        [HttpPost]
        public IActionResult MultiStudent(IList<string> Id,IList<string> FirstName, IList<string> LastName)
        {
            //1,Su SU
            //2,Mya Mya
           var students= new List<string>();
            for(int i = 0; i < Id.Count; i++)
            {
                students.Add(Id[i]+","+ FirstName[i] +" "+ LastName[i]);
            }
            TempData["infos"]= students;//carrying the students info to other pages
            return RedirectToAction("Index");//go to Action Index
        }
    }
}
