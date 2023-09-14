using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string[] Genres { get; set; }    
    }
}
