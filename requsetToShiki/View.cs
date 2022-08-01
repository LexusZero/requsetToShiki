namespace RequestToShiki;

public class View : IView
{
    public void ShowStudio(StudioWithTopAnime studioWithTopAnime)
    {
        Console.WriteLine($"Название - {studioWithTopAnime.Studio.Name}");
        var count = 0;

        foreach (var anime in studioWithTopAnime.TopAnimes)
        {
            count++;
            Console.WriteLine($"Аниме номер {count} " + anime.Name);
        }
    }
    public void ShowAnime(Anime anime) => Console.WriteLine($@"Название - {anime.Name}  
Название на английском - {anime.EnglishName}
Название на японском - {anime.JapaneseName}
Описание - {anime.Description}");
    public string ReadName() => Console.ReadLine();
    public void NotFound() => Console.WriteLine("Этого аниме или этой студии не существует");
}

