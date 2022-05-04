using BookMyService.Data;
using BookMyService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookMyService.Controllers
{
    public class SeekerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeekerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var main = new ServiceViewModel();
            main.ServiceList = new List<Service>();
            var data = _context.Services.ToList();
            main.ServiceList = data;
            return View(main);
        }
        public IActionResult Booked(Service service)
        {
            var username = HttpContext.Session.GetString("username");
            var data = new Booked();
            data.Status = "Booked";
            data.Service = service.Name;
            data.ServiceProvider = service.ProviderDetail;
            data.ServiceSeeker = username;
            _context.BookList.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
