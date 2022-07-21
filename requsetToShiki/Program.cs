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
                if (await LookingStudioAsync(name))
                {
                    Console.WriteLine();
                }
                else
                {


                    var animes = await client.GetFromJsonAsync<List<Anime>>($"/api/animes/?limit=3&search={name}", serializeOptions);
                    var anime = await client.GetFromJsonAsync<Anime>($"/api/animes/{animes[0].Id}", serializeOptions);
                    
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
        static public async Task<bool> LookingStudioAsync(string name)
        {
            var studios = await client.GetFromJsonAsync<List<Studio>>("/api/studios", serializeOptions);
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
                return found;
            }
            return false;
        }
    }
}



