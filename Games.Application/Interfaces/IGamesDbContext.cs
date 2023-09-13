using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Games.Domain;

namespace Games.Application.Interfaces
{
    public interface IGamesDbContext
    {
        DbSet<Game> Games { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
