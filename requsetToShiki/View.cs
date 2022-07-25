namespace RequestToShiki
{
    public class View : IView
    {
        public void ShowStudio(StudioWithTopAnime studioWithTopAnime)
        {
            Console.WriteLine($"Название - {studioWithTopAnime.Studio.Name}");
            int count = 0;

            foreach (var anime in studioWithTopAnime.TopAnimes)
            {
                count++;
                Console.WriteLine($"Аниме номер {count} " + anime.Name);
            }
        }
        public void ShowAnime(Anime anime)
        {
            Console.WriteLine($@"Id = {anime.Id}
Название - {anime.Name}  
Название на английском - {anime.English[0]}
Название на японском - {anime.Japanese[0]}
Описание - {anime.Description}
                    ");
        }
        public string ReadName()
        {
            return Console.ReadLine();
        }
        public void NotFound()
        {
            Console.WriteLine("Этого аниме или этой студии не существует");
        }
    }

}