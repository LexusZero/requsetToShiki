using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace RequestToShiki
{
    class Program
    {


        static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://www.shikimori.one") };
        static readonly JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        static async Task Main()

        {
            try
            {
                var name = Console.ReadLine();
                var requestStudios = await client.GetStreamAsync("/api/studios");
                var studios = await JsonSerializer.DeserializeAsync<List<Studio>>(requestStudios, serializeOptions);
                var foundStudio = studios.FirstOrDefault(stud => stud.Name == name || stud.filteredName == name);
                var found = foundStudio != null;
                if (found)
                {
                    Console.WriteLine($"Название - {foundStudio.Name}");
                    var top5 = await client.GetFromJsonAsync<List<Anime>>(
                        $"/api/animes/?limit=5&studio={foundStudio.Id}&order=popularity",
                        serializeOptions);
                    foreach (var top in top5)
                    {
                        Console.WriteLine(top.Name);
                    }
                }
                else
                {


                    var response = await client.GetStreamAsync($"/api/animes/?limit=3&search={name}");
                    var animes = await JsonSerializer.DeserializeAsync<List<Anime>>(response, serializeOptions);
                    var secondResponse = await client.GetStreamAsync($"/api/animes/{animes[0].Id}");
                    var anime = await JsonSerializer.DeserializeAsync<Anime>(secondResponse, serializeOptions);
                    Console.WriteLine($@"Id = {anime.Id}
Название - {anime.Name}  
Название на английском - {anime.English[0]}
Название на японском - {anime.Japanese[0]}
Описание - {anime.Description}
                    ");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}



