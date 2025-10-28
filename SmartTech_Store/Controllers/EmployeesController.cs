using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartTech_Store.Datacon;
using SmartTech_Store.Filters;
using SmartTech_Store.Models;

namespace SmartTech_Store.Controllers
{
    [SessionAuthorize]
    public class EmployeesController : Controller
    {
        private readonly majedDbContext _context;

        public EmployeesController(majedDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Employee> data = _context.Employees
                    .Include(e => e.Department)
                    .Include(e => e.Job).ToList();
                return View(data);
            }
            catch (Exception ex)
            {
                return Content("تواصل معنا على رقم 0434837543");
            }
        }




        private void creatlist()
        {

            IEnumerable<Department> departments = _context.Departments.ToList();
            SelectList selectListItems = new SelectList(departments, "Id", "Name");
            ViewBag.Departments = selectListItems;

            IEnumerable<Job> jobs = _context.Jobs.ToList();
            SelectList selectListItems2 = new SelectList(jobs, "Id", "Name");
            ViewBag.Jobs = selectListItems2;

        }


        [HttpGet]
        public IActionResult Create()
        {
            creatlist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                _context.Employees.Add(employee);
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
            var employee = _context.Employees.Find(Id);
            creatlist();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }

                _context.Employees.Update(employee);
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
            var employee = _context.Employees.Find(Id);
            creatlist();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            try
            {

                _context.Employees.Remove(employee);
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
