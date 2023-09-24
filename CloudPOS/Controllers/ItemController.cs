using CloudPOS.DAO;
using CloudPOS.Models.ViewModels;
using CloudPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly AppDbContext _appDbContext;

        //private readonly ICategorySerice _categoryService;
        public ItemController(IItemService itemService,AppDbContext appDbContext)
        {
            _itemService = itemService;
            _appDbContext = appDbContext;
        }
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Entry()
        {
            ViewBag.Categories =_appDbContext.Categories.Select(s=>new CategoryViewModel
            {
                Id=s.Id,
                Description=s.Description
            }).ToList();
            ViewBag.Brands =_appDbContext.Brands.Select(s=>new BrandViewModel
            {
            Id=s.Id,
            Name=s.Name,
            }).ToList();
            return View();
        }
    }
}
