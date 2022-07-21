using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RequestToShiki
{
    public static class Request
    {
        static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://www.shikimori.one") };
        static readonly JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        const string StudiosPath = "/api/studios";

        public static async Task<StudioWithTopAnime> StudioByName(string name)
        {
            var studios = await client.GetFromJsonAsync<List<Studio>>(StudiosPath, serializeOptions);
            var foundStudio = studios.FirstOrDefault(stud => stud.Name == name || stud.filteredName == name);
            if (foundStudio == null)
            {
                return null;
            }

            var topAnimes = await client.GetFromJsonAsync<List<Anime>>(
                   $"/api/animes/?limit=5&studio={foundStudio.Id}&order=popularity",
                   serializeOptions);
            return new StudioWithTopAnime { Studio = foundStudio, TopAnimes = topAnimes };
        }

        public static async Task<Anime> AnimesByName(string name)
        {
            var animes = await client.GetFromJsonAsync<List<Anime>>($"/api/animes/?limit=3&search={name}", serializeOptions);
            if (animes.Count == 0)
            {
                return null;
            }
            return await client.GetFromJsonAsync<Anime>($"/api/animes/{animes[0].Id}", serializeOptions);
        }
    }
}
