using Santander.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Santander.Api.Models;

namespace Santander.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public StoriesController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopStories([FromQuery] int n = 1)
        {
            // Return error if number is less than 1
            // Todo: Handle more scenarios, like HackerNews API is not available
            if (n <= 0)
                return BadRequest("The paramenter n should be greater or equals to 1");

            List<StoryResult> stories = await _hackerNewsService.GetTopStoriesAsync(n);
            return Ok(stories);
        }
    }

}
