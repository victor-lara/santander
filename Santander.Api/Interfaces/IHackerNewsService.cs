using Santander.Api.Models;

namespace Santander.Api.Interfaces
{
    public interface IHackerNewsService
    {
        Task<List<StoryResult>> GetTopStoriesAsync(int count);
    }
}
