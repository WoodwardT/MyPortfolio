using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyPortfolioContext _context;

        public HomeController(MyPortfolioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ListModel = new ListModel();
            ListModel.SkillModel = await _context.Skill.ToListAsync();
            ListModel.ArticleModel = await _context.Article.ToListAsync();
            ListModel.ExperienceModel = await _context.Experience.ToListAsync();
            ListModel.PortfolioModel = await _context.Portfolio.ToListAsync();
            return View(ListModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

