namespace RequestToShiki;

using System.Threading.Tasks;

public interface IRequest
{
    Task<Anime> AnimesByName(string name);
    Task<StudioWithTopAnime> StudioByName(string name);
}
