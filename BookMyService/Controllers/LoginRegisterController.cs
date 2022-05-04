using BookMyService.Data;
using BookMyService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookMyService.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginRegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Register register)
        {
            var data = _context.RegisterUser.Where(x=>x.UserName == register.UserName && x.Password==register.Password).ToList();
            if(data.Count()!=0)
            {
                HttpContext.Session.SetString("username",data.FirstOrDefault().UserName);
                HttpContext.Session.SetString("usertype",data.FirstOrDefault().UserType);
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Register", "LoginRegister");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            var data = new Register();
            data.UserName = register.UserName;
            data.Password = register.Password;
            data.UserType = register.UserType;
            data.Approve  = null;
            if(register.UserType == "Provider")
            {
                data.Approve = "Pending";
            }
            _context.RegisterUser.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index", "LoginRegister");
        }
        public IActionResult Approve()
        {
            var username = HttpContext.Session.GetString("username");
            var con = _context.RegisterUser.Where(x => x.UserName == username).ToList();
            if(con.FirstOrDefault().UserType =="Admin")
            {
                var data = _context.RegisterUser.Where(x => x.UserType == "Provider" && x.Approve == "Pending").ToList();
                var model = new RegisterViewModel();
                model.Registers = new List<Register>();
                model.Registers = data;
                return View(model);
            }
            return RedirectToAction("Index", "LoginRegister");

        }
        [HttpPost]
        public IActionResult Approve(Register register)
        {
            var data = _context.RegisterUser.Find(register.Id);
            data.Approve = "Verified";
            _context.RegisterUser.Update(data);
            _context.SaveChanges();
            return RedirectToAction("Approve", "LoginRegister");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "LoginRegister");

        }
    }
}
