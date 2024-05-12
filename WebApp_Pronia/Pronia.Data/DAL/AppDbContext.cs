using Microsoft.EntityFrameworkCore;
using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Data.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Slider> Sliders { get; set; }

}
