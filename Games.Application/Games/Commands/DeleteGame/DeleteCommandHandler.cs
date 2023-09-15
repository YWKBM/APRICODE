using Games.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Games.Application.Games.Commands.DeleteGame
{
    public class DeleteCommandHandler : IRequestHandler<DeleteGameCommand, Unit>
    {
        private readonly IGamesDbContext _dbContext;

        public DeleteCommandHandler(IGamesDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }
        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var entity =
                 await _dbContext.Games.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null || entity.Id != request.Id) 
            {
                throw new Exception(); 
            }

            _dbContext.Games.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
