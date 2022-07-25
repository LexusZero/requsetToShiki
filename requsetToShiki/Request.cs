namespace RequestToShiki;

using System.Net.Http.Json;
using System.Text.Json;

public class Request : IRequest
{
    private readonly HttpClient client = new() { BaseAddress = new Uri("https://www.shikimori.one") };
    private readonly JsonSerializerOptions serializeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };
    private const string StudiosPath = "/api/studios";

    public async Task<StudioWithTopAnime> StudioByName(string name)
    {
        var studios = await this.client.GetFromJsonAsync<List<Studio>>(StudiosPath, this.serializeOptions);
        var foundStudio = studios.FirstOrDefault(stud => stud.Name == name || stud.filteredName == name);
        if (foundStudio == null)
        {
            return null;
        }

        var topAnimes = await this.client.GetFromJsonAsync<List<Anime>>(
               $"/api/animes/?limit=5&studio={foundStudio.Id}&order=popularity",
               this.serializeOptions);
        return new StudioWithTopAnime { Studio = foundStudio, TopAnimes = topAnimes };
    }

    public async Task<Anime> AnimesByName(string name)
    {
        var animes = await this.client.GetFromJsonAsync<List<Anime>>($"/api/animes/?limit=3&search={name}", this.serializeOptions);
        if (animes.Count == 0)
        {
            return null;
        }
        return await this.client.GetFromJsonAsync<Anime>($"/api/animes/{animes[0].Id}", this.serializeOptions);
    }
}
