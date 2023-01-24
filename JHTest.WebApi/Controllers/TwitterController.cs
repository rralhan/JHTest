using JHTest.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace JHTest.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterController : ControllerBase
    {
        private readonly ITwitterService _twtService;
        public TwitterController(ITwitterService twtService)
        {
            _twtService = twtService;
        }


        [HttpGet("count")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCount()
        {
            return Ok(await _twtService.Count());
        }

        [HttpGet("hashtags")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHashtags()
        {
            return Ok(await _twtService.GetTopHashtags());
        }
    }
}