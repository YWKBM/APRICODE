using AutoMapper;
using AutoMapper.QueryableExtensions;
using Games.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Queries.GetGameList
{
    public class GetGameListQueryHandler
        : IRequestHandler<GetGameListQuery, GameListVm>
    {
        private readonly IGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameListQueryHandler(IGamesDbContext gamesDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = gamesDbContext;
        }

        public async Task<GameListVm> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            var gamesQuery = await _dbContext.Games.ProjectTo<GameDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GameListVm { Games = gamesQuery };
        }

    }
}
