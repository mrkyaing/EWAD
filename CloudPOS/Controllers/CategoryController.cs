using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudPOS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            IList<CategoryViewModel> categories = _context.Categories.Select(s=>new CategoryViewModel
            {
                Id=s.Id,//to delete, update for UI actions (Delete,Edit/Update)
                Code=s.Code,
                Description=s.Description,
                CreatedAt=s.CreatedAt
            }).ToList();
            return View(categories);//return to the view with categories IList Data 
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(CategoryViewModel viewModel)
        {
            try
            {
                //Data Transfer from viewModel to Entity
                var categoryEntity = new CategoryEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = viewModel.Code,
                    Description=viewModel.Description
                };
               _context.Categories.Add(categoryEntity);//Setting the entity to the db Sets
                _context.SaveChanges();//Actually Save to the database  >> insert into values 
                //ViewBag.Info = "Successfully save a record to the system";
                TempData["Info"] = "Successfully save a record to the system";
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when save a record to the system !" + e.Message;
               
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(string Id)
        {
            try
            {
                var category = _context.Categories.Where(x => x.Id == Id).FirstOrDefault();
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    TempData["Info"] = "Successfully delete a record from the system";
                }
               
            }
            catch (Exception e)
            {
                TempData["Info"] = "Error occur when delete a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string Id)//1
        {
                CategoryViewModel categoryViewModel = _context.Categories.AsNoTracking().Where(x => x.Id == Id)
                .Select(s=>new CategoryViewModel
                {
                 Id=s.Id,
                 Code=s.Code,
                 Description=s.Description
                }).FirstOrDefault();//Method style Linq 
            //CategoryEntity category1 = (from c in _context.Categories where c.Id == Id select c).FirstOrDefault();//Query Style Linq
            if (categoryViewModel != null)
                return View(categoryViewModel);
            else
            {
                TempData["Info"] = "There is no record that you selected";
                return RedirectToAction("List");
            }
        }
        [HttpPost]
       public IActionResult Update(CategoryViewModel viewModel)
        {
            try
            {
                //Data Transfer from viewModel to Entity
                var categoryEntity = new CategoryEntity()
                {
                    Id = viewModel.Id,
                    Code = viewModel.Code,
                    Description = viewModel.Description,
                    ModifiedAt = DateTime.Now
                };
                _context.Entry(categoryEntity).State = EntityState.Modified;
                _context.SaveChanges();
                TempData["Info"] = "Successfully update a record to the system";
            }
            catch (Exception e)
            {

                TempData["Info"] = "Error occur when update a record to the system !" + e.Message;
            }
            return RedirectToAction("List");
        }
    }
}
