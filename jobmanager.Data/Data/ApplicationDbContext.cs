using jobmanager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace jobmanager.Data.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<IsIlani> IsIlanlari{ get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Sirket> Sirketler { get; set; }

    }
}
