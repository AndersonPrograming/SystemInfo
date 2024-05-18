using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models.GameModels;
using SystemInfo.Services.GameServices;
using static SystemInfo.Controllers.GameControllers.GameController;

namespace SystemInfo.Controllers.GameControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeService _gameService;

        public BadgeController(IBadgeService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Badge>>> GetAll()
        {
            return Ok(await _gameService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Badge>> create([FromBody] BadgeModel model)
        {
            var createGame = await _gameService.Create(model.UserId, model.NameBadge, model.Description, model.Completed, model.Experience, model.Image);
            if (createGame == null)
            {
                return BadRequest("Game not Created");
            }
            return Ok(createGame);
        }

        public class BadgeModel
        {
            public int UserId { get; set; }
            public string NameBadge { get; set; }
            public string Description { get; set; }
            public bool Completed { get; set; } = false;
            public int Experience { get; set; }
            public string Image { get; set; }
        }
    }
}
