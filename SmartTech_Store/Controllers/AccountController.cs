﻿using Microsoft.AspNetCore.Mvc;
using SmartTech_Store.Datacon;

namespace SmartTech_Store.Controllers
{
    public class AccountController : Controller
    {

        private readonly majedDbContext _context;

        public AccountController(majedDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Employees
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
