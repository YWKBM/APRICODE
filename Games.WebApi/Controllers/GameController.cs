using Games.Application.Games.Commands.CreateGame;
using Games.Application.Games.Commands.DeleteGame;
using Games.Application.Games.Commands.UpdateGame;
using Games.Application.Games.Queries.GetGame;
using Games.Application.Games.Queries.GetGameList;
using Microsoft.AspNetCore.Mvc;

namespace Games.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GameController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GameListVm>> GetAll()
        {
            var query = new GetGameListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<GameListVm>> GetAllFiltered([FromBody] GetFilteredGameListQuery query)
        {
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameVm>> Get(Guid id)
        {
            var query = new GetGameQuery
            {
                Id = id 
            };
            var vm = await Mediator.Send(query);    
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGameCommand command)
        {
            var gameId = await Mediator.Send(command);
            return Ok(gameId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateGameCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGameCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
