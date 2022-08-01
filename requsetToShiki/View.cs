using RequestToShiki.ShikimoriAPI;

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
    public void ShowAnime(ShikimoriAnime anime) => Console.WriteLine($@"Id = {anime.Id}
Название - {anime.Name}  
Название на английском - {anime.English[0]}
Название на японском - {anime.Japanese[0]}
Описание - {anime.Description}
                    ");
    public string ReadName() => Console.ReadLine();
    public void NotFound() => Console.WriteLine("Этого аниме или этой студии не существует");
}

