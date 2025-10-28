using Microsoft.AspNetCore.Mvc;
using SmartTech_Store.Datacon;
using SmartTech_Store.Filters;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    [SessionAuthorize]
    public class DepartmentsController : Controller
    {


        private readonly majedDbContext _context;

        public DepartmentsController(majedDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Department> Departments = _context.Departments.ToList();
                return View(Departments);
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
        public IActionResult Create(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(department);
                }

                _context.Departments.Add(department);
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
            var department = _context.Departments.Find(Id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(department);
                }

                _context.Departments.Update(department);
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
            var department = _context.Departments.Find(Id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {

                _context.Departments.Remove(department);
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
