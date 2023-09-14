using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Queries.GetGame
{
    public class GetGameQuery : IRequest<GameVm>
    {
        public Guid Id { get; set; }
    }
}
