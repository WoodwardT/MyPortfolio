#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio.Data
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext (DbContextOptions<MyPortfolioContext> options)
            : base(options)
        {
        }
        public DbSet<Experience> Experience { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<MyPortfolio.Models.Portfolio> Portfolio { get; set; }

        public DbSet<MyPortfolio.Models.Skill> Skill { get; set; }

        public DbSet<MyPortfolio.Models.Message> Message { get; set; }

        public DbSet<MyPortfolio.Models.GuestBook> GuestBook { get; set; }

        public DbSet<MyPortfolio.Models.About> About { get; set; }

        public DbSet<MyPortfolio.Models.Test> Test { get; set; }
    }
}
