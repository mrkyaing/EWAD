using EFCorePracticeWithMVC.DAO;
using EFCorePracticeWithMVC.Models;
using EFCorePracticeWithMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFCorePracticeWithMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(StudentViewModel viewModel)
        {
            try
            {
                //Data Transfer from viewModel to Entity
                var studentEntity = new StudentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = viewModel.Code,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    DOB = viewModel.DOB,
                    Address = viewModel.Address
                };
                _context.Students.Add(studentEntity);//Setting the entity to the db Sets
                _context.SaveChanges();//Actually Save to the database  >> insert into values 
                ViewBag.Info = "Successfully save a record to the system";
            }
            catch (Exception e)
            {
                ViewBag.Info = "Error occur when save a record to the system !"+e.Message;
            }
            return View();
        }
    }
}
