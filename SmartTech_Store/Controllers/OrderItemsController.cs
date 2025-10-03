using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartTech_Store.Datacon;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly majedDbContext _context;

        public OrderItemsController(majedDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            try
            {

                IEnumerable<OrderItem> data = _context.OrderItems.Include(c => c.Order).ToList();
                return View(data);

            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0509164022");

            }


        }

        private void creatlist()
        {

            IEnumerable<Order> orders = _context.Orders.ToList();
            SelectList selectListItems = new SelectList(orders, "Id", "CustomerName");
            ViewBag.orders = selectListItems;

        }

        [HttpGet]
        public IActionResult Create()
        {

            creatlist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem orderItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(orderItem);
                }

                _context.OrderItems.Add(orderItem);
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
            var orderItem = _context.OrderItems.Find(Id);
            creatlist();
            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Edit(OrderItem orderItem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(orderItem);
                }

                _context.OrderItems.Update(orderItem);
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
            var product = _context.OrderItems.Find(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(OrderItem orderItem)
        {
            try
            {

                _context.OrderItems.Remove(orderItem);
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
