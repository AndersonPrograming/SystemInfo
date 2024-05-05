using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemInfo.Models.GameModels;
using SystemInfo.Services.GameServices;

namespace SystemInfo.Controllers.GameControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Score>>> GetAll()
        {
            return Ok(await _scoreService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _scoreService.GetScore(id);
            if (score == null)
            {
                return BadRequest("Score not found");
            }

            return Ok(score);
        }
        [HttpPost]
        public async Task<ActionResult<Score>> create(int GameId, string ScoreValue)
        {
            var createScore = await _scoreService.Create(GameId, ScoreValue);
            if (createScore == null)
            {
                return BadRequest("Score not Created");
            }
            return Ok(createScore);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, int GameId, string ScoreValue)
        {
            var createScore = await _scoreService.Update(id, GameId, ScoreValue);
            if (createScore == null)
            {
                return BadRequest("Score not Updated");
            }
            return Ok(createScore);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            var createScore = await _scoreService.DeleteScore(id); 
            if (createScore == null)
            {
                return BadRequest("Score not Deleted");
            }
            return Ok(createScore);

        }
    }
}
