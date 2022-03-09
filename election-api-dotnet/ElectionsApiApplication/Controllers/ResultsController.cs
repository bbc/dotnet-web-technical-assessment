using ElectionsApiApplication.Models;
using ElectionsApiApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectionsApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsController : ControllerBase
    {

        private readonly IResultService _resultService;

        public ResultsController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _resultService.GetResult(id);

            if (result == null)
            {
                return new ResultNotFound(id);
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult NewResult([FromBody] ConstituencyResult result)
        {
            if (result.Id > 0)
            {
                _resultService.NewResult(result);
                return Ok($"{result.Id} created");
            }
            return BadRequest($"Id was '{result.Id}'");
        }

        [HttpGet("scoreboard")]
        public ActionResult GetScoreboard()
        {
            return Ok(new Scoreboard());
        }
    }
}