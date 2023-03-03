using RequestToShiki.ShikimoriAPI;

namespace RequestToShiki.Desktop;

public partial class LookupWindow : Form, IView
{
    public LookupController LookupController { get; set; }

    public event EventHandler LookupTriggered;
    public LookupWindow()
    {
        InitializeComponent();
        this.comboBox1.Items.Add("RequestToShiki");
        this.comboBox1.Items.Add("RequestToGist");
        this.comboBox1.SelectedIndex = 0;
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
        this.output.Text = $@"Название - {anime.Name} 
Название на английском - {anime.EnglishName}
Название на японском - {anime.JapaneseName}
Описание - {anime.Description}
                    ";

    }
    public void ShowStudio(StudioWithTopAnime studioWithTopAnime)
    {
        this.output.Text = $"Название - {studioWithTopAnime.Studio.Name}";
        var count = 0;

        foreach (var anime in studioWithTopAnime.TopAnimes)
        {
            count++;
            this.output.Text += ($"\nАниме номер {count} " + anime.Name);
        }
    }

    private void lookupButton_Click(object sender, EventArgs e)
    {
        LookupTriggered?.Invoke(this, EventArgs.Empty);
    }

    private void input_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            LookupTriggered?.Invoke(this, EventArgs.Empty);
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.comboBox1.SelectedIndex == 0)
        {
            var shikimoriRequest = new ShikimoriRequest();
            LookupController.Request = shikimoriRequest;
        }
        if (this.comboBox1.SelectedIndex == 1)
        {
            LookupController.Request = new GistCsvRequest();
        }
    }
}
