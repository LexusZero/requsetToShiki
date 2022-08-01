using System.Net.Http.Json;
using System.Text.Json;

namespace RequestToShiki.ShikimoriAPI;
public class ShikimoriRequest : IRequest
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
        List<ShikimoriStudio> studios = await this.client.GetFromJsonAsync<List<ShikimoriStudio>>(StudiosPath, this.serializeOptions);
        ShikimoriStudio foundStudio = studios.FirstOrDefault(stud => stud.Name == name || stud.filteredName == name);
        if (foundStudio == null)
            return null;
        Studio studio = new()
        {
            Name = foundStudio.Name
        };

        List<ShikimoriAnime> topAnimes = await this.client.GetFromJsonAsync<List<ShikimoriAnime>>(
               $"/api/animes/?limit=5&studio={foundStudio.Id}&order=popularity",
               this.serializeOptions);
        Anime anime = new();

        return new StudioWithTopAnime { Studio = foundStudio, TopAnimes = topAnimes };
    }

    public async Task<ShikimoriAnime> AnimesByName(string name)
    {
        List<ShikimoriAnime> animes = await this.client.GetFromJsonAsync<List<ShikimoriAnime>>($"/api/animes/?limit=3&search={name}", this.serializeOptions);
        if (animes.Count == 0)
            return null;
        return await this.client.GetFromJsonAsync<ShikimoriAnime>($"/api/animes/{animes[0].Id}", this.serializeOptions);
    }
}
