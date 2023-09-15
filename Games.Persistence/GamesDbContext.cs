using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Domain;
using Games.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Games.Persistence.EntityTypeConfiguration;

namespace Games.Persistence
{
    public class GamesDbContext : DbContext, IGamesDbContext
    {
        public DbSet<Game> Games { get; set; }
        public GamesDbContext(DbContextOptions<GamesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameConfiguration());
            base.OnModelCreating(builder);  
        }
    }
}
