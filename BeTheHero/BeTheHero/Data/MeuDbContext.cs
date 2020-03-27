using BeTheHero.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeTheHero.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
