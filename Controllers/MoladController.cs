using Microsoft.AspNetCore.Mvc;
using MoladWithSearch;

namespace MoladAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoladController : ControllerBase
    {
        private readonly ILogger<MoladController> _logger;

        public MoladController(ILogger<MoladController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetMolad")]
        public IActionResult Get()
        {
            try
            {
                var logic = new MoladLogic();
                var molad = logic.GetMolad();
                return new JsonResult(molad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Molad.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        [HttpPost("GoForward")]
        public IActionResult GoForward([FromBody] string month, int year)
        {
            try
            {
                var logic = new MoladLogic();
                logic.HebrewSearch(month, year);
                logic.GoForward();
                return new JsonResult(logic.GetMolad());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GoForward.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }
        [HttpPost("GoBackward")]
        public IActionResult GoBackward([FromBody] string month, int year)
        {
            try
            {
                var logic = new MoladLogic();
                logic.HebrewSearch(month, year);
                logic.GoBackward();
                return new JsonResult(logic.GetMolad());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GoForward.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        [HttpPost("SearchByHebrewDate")]
        public IActionResult SearchByHebrewDate([FromBody]string month, int year)
        {
            try
            {
                var logic = new MoladLogic();
                logic.HebrewSearch(month, year);
                //logic.GoForward();
                return new JsonResult(logic.GetMolad());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GoForward.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        
    }
}
