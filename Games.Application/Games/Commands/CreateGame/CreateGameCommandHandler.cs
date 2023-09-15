using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Application.Interfaces;
using Games.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Games.Application.Games.Commands.CreateGame
{
    internal class CreateGameCommandHandler 
        : IRequestHandler<CreateGameCommand, Guid> 
    {

        private readonly IGamesDbContext _dbContext;

        public CreateGameCommandHandler(IGamesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game
            {
                Id = request.Id,
                Title = request.Title,
                Studio = request.Studio,
                Genres = request.Genres
            };

            await _dbContext.Games.AddAsync(game, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return game.Id;
        }
    }
}
