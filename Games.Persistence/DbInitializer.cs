using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(GamesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
