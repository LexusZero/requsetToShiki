namespace RequestToShiki;
using System.Threading.Tasks;

public class LookupController
{
    private readonly IView view;
    private readonly IRequest request;
    public LookupController(IView view, IRequest request)
    {
        this.view = view;
        this.request = request;
    }
    public async Task LookupByName()
    {
        var name = this.view.ReadName();
        var studio = await this.request.StudioByName(name);
        if (studio != null)
        {
            this.view.ShowStudio(studio);
            return;
        }
        var anime = await this.request.AnimesByName(name);
        if (anime != null)
        {
            this.view.ShowAnime(anime);
            return;
        }
        this.view.NotFound();
    }
}
