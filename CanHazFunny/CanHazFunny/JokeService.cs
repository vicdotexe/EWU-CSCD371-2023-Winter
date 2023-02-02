using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            var jokeResult = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            var data = JsonSerializer.Deserialize<JokeData>(jokeResult);

            return data?.Joke ?? throw new Exception("No joke retrieved");
        }
    }
}
