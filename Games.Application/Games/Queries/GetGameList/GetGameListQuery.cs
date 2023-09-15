using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Queries.GetGameList
{
    public class GetGameListQuery : IRequest<GameListVm>
    {
        //TODO: Guid UserId { get; set; }
    }
}
