using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace RequestToShiki
{
    class Program
    {
        static async Task Main()
        {
            var name = View.ReadName();
            var studio = await Request.StudioByName(name);
            if (studio != null)
            {
                View.ShowStudio(studio);
                return;
            }
            var anime = await Request.AnimesByName(name);
            if (anime != null)
            {
                View.ShowAnime(anime);
                return;
            }
            View.NotFound();
        }
        
    }
}



