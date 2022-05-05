
#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;




namespace MyPortfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyPortfolioContext _context;
        private PagedList<Message> messages;

        public AdminController(MyPortfolioContext context)
        {
            _context = context;
        }


        // Pagination Code 
        // GET: Admin/Messages
        public async Task<IActionResult> Messages(int page = 1)
        {
            int pageIndex = page;
            int pageSize = 10;


            IQueryable<Message> messageIQ = from m in _context.Message select m;
            messageIQ = messageIQ.OrderByDescending(m => m.Id);
            //.Skip((pageIndex - 1) * pageSize)
            //.Take(pageSize);

            PagedList<Message> messages = await PagedList<Message>.CreateAsync(messageIQ, pageIndex, pageSize);
            //messages = await PagedList<Message>.CreateAsync(messageIQ.AsNoTracking(), pageIndex, pageSize);

            return View(messages);
        }





        /*        public async Task<IActionResult> Messages()
        {
            return View(_context.Message.OrderByDescending(x => x.Id).ToList());
        }*/



        //public async Task<IActionResult> Messages(int page = 1)
        //{
        //    int pageIndex = page;
        //    int pageSize = 10;


        //    IQueryable<Message> messageIQ = from m in _context.Message select m;
        //    messageIQ = messageIQ.OrderByDescending(m => m.Id);
        //    messages = await PagedList<Message>.CreateAsync(messageIQ.AsNoTracking(), pageIndex, pageSize);
        //    return View(messages);
        //}

    }
}

