namespace RequestToShiki.Desktop;

public partial class LookupWindow : Form, IView
{
    public event EventHandler LookupTriggered;
    public LookupWindow()
    {
        InitializeComponent();
    }

    public void NotFound()
    {
        this.output.Text = "Ничего не найдено";
    }
    public string ReadName()
    {
        return this.input.Text;
    }

    public void ShowAnime(Anime anime)
    {
        this.output.Text = $@"Id = {anime.Id}
Название - {anime.Name}  
Название на английском - {anime.English[0]}
Название на японском - {anime.Japanese[0]}
Описание - {anime.Description}
                    ";

    }
    public void ShowStudio(StudioWithTopAnime studioWithTopAnime)
    {
        this.output.Text = $"Название - {studioWithTopAnime.Studio.Name}";
        var count = 0;

        foreach (Anime? anime in studioWithTopAnime.TopAnimes)
        {
            count++;
            this.output.Text += ($"\nАниме номер {count} " + anime.Name);
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void lookupButton_Click(object sender, EventArgs e)
    {
        LookupTriggered?.Invoke(this, EventArgs.Empty);
    }

}
