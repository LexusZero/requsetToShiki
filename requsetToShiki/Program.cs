namespace RequestToShiki
{
    class Program
    {
        static async Task Main()
        {
            Request request = new Request();
            View view = new View();
            var name = view.ReadName();
            var studio = await request.StudioByName(name);
            if (studio != null)
            {
                view.ShowStudio(studio);
                return;
            }
            var anime = await request.AnimesByName(name);
            if (anime != null)
            {
                view.ShowAnime(anime);
                return;
            }
            view.NotFound();
        }
    }
}



