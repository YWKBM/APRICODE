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
    public class GetFilteredGameListQueryHandler :
        IRequestHandler<GetFilteredGameListQuery, GameListVm>
    {
        private readonly IGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFilteredGameListQueryHandler(IGamesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GameListVm> Handle(GetFilteredGameListQuery request, CancellationToken cancellationToken)
        {
            var filteredGamesQuery = await _dbContext.Games.Where(e => e.Genres.Any(g => request.Genres.Contains(g))).
                ProjectTo<GameDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new GameListVm { Games = filteredGamesQuery };
        }
    }
}