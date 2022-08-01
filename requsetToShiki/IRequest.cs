namespace RequestToShiki;
public interface IRequest
{
    Task<Anime> AnimesByName(string name);
    Task<StudioWithTopAnime> StudioByName(string name);
}
