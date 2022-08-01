namespace RequestToShiki;

public interface IView
{
    void NotFound();
    string ReadName();
    void ShowAnime(Anime anime);
    void ShowStudio(StudioWithTopAnime studioWithTopAnime);
}
