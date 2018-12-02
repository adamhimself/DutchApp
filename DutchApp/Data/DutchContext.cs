using DutchApp.Data.Entities;
using DutchApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchApp.Data
{
  public class DutchContext : IdentityDbContext<AppUser>
  {
    public DutchContext(DbContextOptions<DutchContext> options): base(options)
    {
    }

    public DbSet<Verb> Verbs { get; set; }

  }


  

  
}
