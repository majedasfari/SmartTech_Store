using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartTech_Store.Datacon;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    public class ShopController : Controller
    {
        private readonly majedDbContext _context;

        public ShopController(majedDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            try
            {

                IEnumerable<Shop> data = _context.Shops.Include("Brand").ToList();  
                return View(data);

            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0509164022");

            }


        }

        private void creatlist()
        {

            IEnumerable<Brand> Brands = _context.Brands.ToList();
            SelectList selectListItems = new SelectList(Brands, "Id", "Name");
            ViewBag.Categories = selectListItems;

        }



        [HttpGet]
        public IActionResult Create()
        {
            creatlist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Shop shop)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(shop);
                }

                _context.Shops.Add(shop);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0509164022");
            }
        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _context.Shops.Find(Id);
            creatlist();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Shop shop)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(shop);
                }

                _context.Shops.Update(shop);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0509164022");
            }
        }



        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var category = _context.Shops.Find(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Shop shop)
        {
            try
            {

                _context.Shops.Remove(shop);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0509164022");
            }
        }
    }
}
