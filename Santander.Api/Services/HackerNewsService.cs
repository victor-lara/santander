using Santander.Api.Interfaces;
using Santander.Api.Models;

namespace Santander.Api.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;

        // These can be env variables or secrets
        private const string Best_Api = "https://hacker-news.firebaseio.com/v0/beststories.json";
        private const string Detail_API_BASE = "https://hacker-news.firebaseio.com/v0/item";

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Retrieves the list of best stories
        private async Task<List<int>> GetBestStoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<int>>(
                Best_Api);

            return response ?? new List<int>();
        }

        // Using tasks to get resources async
        public async Task<List<StoryResult>> GetTopStoriesAsync(int count)
        {
            var ids = await GetBestStoriesAsync();

            // It only use the requested amount of stories
            // Maybe can move this param to the GetBestStoriesAsync, but at the end the request returns the full response
            var tops = ids.Take(count);

            var tasks = tops.Select(async id =>
            {
                var story = await _httpClient.GetFromJsonAsync<Story>(
                    $"{Detail_API_BASE}/{id}.json");

                if (story != null)
                {
                    return new StoryResult
                    {
                        Title = story?.Title,
                        Uri = story?.Url,
                        PostedBy = story?.By,
                        Time = DateTimeOffset.FromUnixTimeSeconds(story.Time).ToString("yyyy-MM-ddTHH:mm:sszzz"),
                        Score = story.Score,
                        CommentCount = story.Descendants
                    };
                }
                else
                {
                    return null;
                }
            });

            var stories = await Task.WhenAll(tasks);

            // Sort the list and return
            // Need to handle nullability
            return stories
                .Where(s => s != null)
                .OrderByDescending(s => s.Score)
                .ToList();
        }
    }
}
