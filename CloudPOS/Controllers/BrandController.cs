using CloudPOS.DAO;
using CloudPOS.Models;
using CloudPOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudPOS.Controllers
{
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            IList<BrandViewModel> brands = _context.Brands.Select(s=>new BrandViewModel
            {
                Id=s.Id,//to delete, update for UI actions (Delete,Edit/Update)
                Code=s.Code,
                Name=s.Name,
                ManufacturedCompany=s.ManufacturedCompany,
                CreatedAt=s.CreatedAt
            }).ToList();
            return View(brands);//return to the view with categories IList Data 
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(BrandViewModel viewModel)
        {
            try
            {
                //Data Transfer from viewModel to Entity
                var entity = new BrandEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = viewModel.Code,
                    Name=viewModel.Name,
                    ManufacturedCompany=viewModel.ManufacturedCompany
                };
               _context.Brands.Add(entity);//Setting the entity to the db Sets
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
                var entity = _context.Brands.Where(x => x.Id == Id).FirstOrDefault();
                if (entity != null)
                {
                    _context.Brands.Remove(entity);
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
                BrandViewModel viewModel = _context.Brands.AsNoTracking().Where(x => x.Id == Id)
                .Select(s=>new BrandViewModel
                {
                 Id=s.Id,
                 Code=s.Code,
                 Name=s.Name,
                 ManufacturedCompany=s.ManufacturedCompany
                }).FirstOrDefault();//Method style Linq 
            //CategoryEntity category1 = (from c in _context.Categories where c.Id == Id select c).FirstOrDefault();//Query Style Linq
            if (viewModel != null)
                return View(viewModel);
            else
            {
                TempData["Info"] = "There is no record that you selected";
                return RedirectToAction("List");
            }
        }
        [HttpPost]
       public IActionResult Update(BrandViewModel viewModel)
        {
            try
            {
                //Data Transfer from viewModel to Entity
                var entity = new BrandEntity()
                {
                    Id = viewModel.Id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    ManufacturedCompany=viewModel.ManufacturedCompany,
                    ModifiedAt = DateTime.Now
                };
                _context.Entry(entity).State = EntityState.Modified;
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
