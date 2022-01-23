using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class WebApplication6Context : DbContext
    {
        public WebApplication6Context (DbContextOptions<WebApplication6Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication6.Models.Employe> Employe { get; set; }

        public DbSet<WebApplication6.Models.Job> Job { get; set; }

        public DbSet<WebApplication6.Models.Hire> Hire { get; set; }
    }
}
