#nullable disable
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;



namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ContactController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {

            Message message1 = new Message();
            message1.FullName = fullName;
            message1.Email = email;
            message1.Body = message;
            message1.CreatedAt = DateTime.Now;
            _context.Message.Add(message1);
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from<b> {fullName}</b> email address <b>({email})</b> has been sent successfully. <br><br> <b>Message:</b> <br> {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Something went wrong, this message comes from the Contact Controller.{ex.Message}";

            }
            return View();
        }
    }
}
