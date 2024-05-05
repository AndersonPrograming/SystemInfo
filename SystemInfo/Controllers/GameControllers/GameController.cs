using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;
using SystemInfo.Services;
using SystemInfo.Services.GameServices;

namespace SystemInfo.Controllers.GameControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAll()
        {
            return Ok(await _gameService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _gameService.GetGame(id);
            if (game == null)
            {
                return BadRequest("Farm not found");
            }

            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<Game>> create(int UserId, DateTime GameDate, string EnergyType)
        {
            var createGame = await _gameService.Create(UserId, GameDate, EnergyType);
            if (createGame == null)
            {
                return BadRequest("Game not Created");
            }
            return Ok(createGame);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, int UserId, DateTime GameDate, string EnergyType)
        {
            var createGame = await _gameService.Update(id, UserId, GameDate, EnergyType);
            if (createGame == null)
            {
                return BadRequest("Game not Updated");
            }
            return Ok(createGame);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _gameService.DeleteGame(id);
            if (game == null)
            {
                return BadRequest("Game not Deleted");
            }
            return Ok(game);

        }
    }
}
