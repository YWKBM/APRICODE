using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Commands.DeleteGame
{
    public class DeleteGameCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
