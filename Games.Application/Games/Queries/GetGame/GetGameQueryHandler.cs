using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Games.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Games.Application.Games.Queries.GetGame
{
    public class GetGameQueryHandler
        : IRequestHandler<GetGameQuery, GameVm>
    {
        private readonly IGamesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGameQueryHandler(IGamesDbContext gamesDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = gamesDbContext;
        }

        public async Task<GameVm> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var entity =
               await _dbContext.Games.FirstOrDefaultAsync(game => game.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new Exception();
            }

            return _mapper.Map<GameVm>(entity);
        }
    }
}
