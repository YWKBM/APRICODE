using Games.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Games.Persistence.EntityTypeConfiguration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(game => game.Id);
            builder.HasIndex(game => game.Id).IsUnique();
            builder.Property(game => game.Title).HasMaxLength(255);
            builder.Property(game => game.Studio).HasMaxLength(255);
            builder.Property(game => game.Genres);
                //.HasConversion(
                //v => string.Join(',', v),
                //v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)); 
        }
    }
}
