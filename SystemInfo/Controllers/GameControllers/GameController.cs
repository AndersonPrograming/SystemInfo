using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;
using SystemInfo.Services;
using SystemInfo.Services.GameServices;
using static SystemInfo.Controllers.GameControllers.UserController;

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
        public async Task<ActionResult<Game>> create([FromBody] GameModel model)
        {
            var createGame = await _gameService.Create(model.UserId, model.GameDate, model.EnergyType, model.Score);
            if (createGame == null)
            {
                return BadRequest("Game not Created");
            }
            return Ok(createGame);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromBody] GameModelUpdate model)
        {
            var createGame = await _gameService.Update(model.GameId, model.UserId, model.GameDate, model.EnergyType, model.Score);
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

        public class GameModel
        {
            public int UserId { get; set; }
            public DateTime GameDate { get; set; }
            public string EnergyType { get; set; }
            public string Score { get; set; }
        }
        public class GameModelUpdate
        {
            public int GameId { get; set; }
            public int UserId { get; set; }
            public DateTime GameDate { get; set; }
            public string EnergyType { get; set; }
            public string Score { get; set; }
        }
    }
}
