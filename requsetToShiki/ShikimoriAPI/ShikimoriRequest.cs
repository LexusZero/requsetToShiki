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
        var studios = await this.client.GetFromJsonAsync<List<ShikimoriStudio>>(StudiosPath, this.serializeOptions);
        var foundStudio = studios.FirstOrDefault(stud => stud.Name == name || stud.filteredName == name);
        if (foundStudio == null)
            return null;
        var studio = new Studio
        {
            Name = foundStudio.Name
        };

        var topAnimesShiki = await this.client.GetFromJsonAsync<List<ShikimoriAnime>>(
               $"/api/animes/?limit=5&studio={foundStudio.Id}&order=popularity",
               this.serializeOptions);

        var topAnimes = topAnimesShiki.Select(ConvertToAnime).ToList();

        return new StudioWithTopAnime { Studio = studio, TopAnimes = topAnimes };
    }

    public async Task<Anime> AnimesByName(string name)
    {
        var animes = await this.client.GetFromJsonAsync<List<ShikimoriAnime>>(
            $"/api/animes/?limit=3&search={name}", this.serializeOptions);

        if (animes.Count == 0)
            return null;

        var animeShiki = await this.client.GetFromJsonAsync<ShikimoriAnime>(
            $"/api/animes/{animes[0].Id}", this.serializeOptions);
        return ConvertToAnime(animeShiki);
    }
    private static Anime ConvertToAnime(ShikimoriAnime animeShiki) => new()
    {
        Name = animeShiki.Name,
        Description = animeShiki.Description,
        EnglishName = animeShiki.English?.FirstOrDefault(),
        JapaneseName = animeShiki.Japanese?.FirstOrDefault()
    };
}
