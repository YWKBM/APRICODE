using Games.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler 
        : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IGamesDbContext _dbContext;

        public UpdateGameCommandHandler(IGamesDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Games.FirstOrDefaultAsync( game => game.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
            {
                throw new Exception();
            }

            entity.Title = request.Title;   
            entity.Studio = request.Studio;
            entity.Genres = request.Genres;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
