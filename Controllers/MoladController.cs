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
                logic.EnglishSearch(DateTime.Today);
                return new JsonResult(logic.GetMolad());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the Molad.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        [HttpGet("GoForward")]
        public IActionResult GoForward(string month, int year)
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

        [HttpGet("GoBackward")]
        public IActionResult GoBackward(string month, int year)
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

        [HttpGet("SearchByHebrewDate")]
        public IActionResult SearchByHebrewDate(string month, int year)
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

        [HttpGet("SearchByEnglishDate")]
        public IActionResult SearchByEnglishDate(DateTime search)
        {
            try
            {
                var logic = new MoladLogic();
                logic.EnglishSearch(search);
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
