using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Games.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   
        public string Studio { get; set; }
        public string[] Genres { get; set; }    
    }
}
