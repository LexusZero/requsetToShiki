namespace RequestToShiki;
public class LookupController
{
    private readonly IView view;
    public IRequest Request { get; set; }

    public LookupController(IView view, IRequest request)
    {
        this.view = view;
        Request = request;
    }

    public async Task LookupByName()
    {
        var name = this.view.ReadName();
        var studio = await Request.StudioByName(name);
        if (studio != null)
        {
            this.view.ShowStudio(studio);
            return;
        }

        var anime = await Request.AnimesByName(name);
        if (anime != null)
        {
            this.view.ShowAnime(anime);
            return;
        }
        this.view.NotFound();
    }
}
