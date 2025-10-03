using Microsoft.AspNetCore.Mvc;
using SmartTech_Store.Datacon;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    public class OrdersController : Controller
    {
        private readonly majedDbContext _context;

        public OrdersController(majedDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Order> Orders = _context.Orders.ToList();
                return View(Orders);
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(order);
                }

                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var order = _context.Orders.Find(Id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(order);
                }

                _context.Orders.Update(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var department = _context.Orders.Find(Id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Order department)
        {
            try
            {

                _context.Orders.Remove(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }


        }

    }
}
