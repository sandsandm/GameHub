
using System.Text.Json;

namespace GameHub.Views;

public class NoteEntry
{
    public string Date { get; set; }
    public string Text { get; set; }
}

public partial class DnDHubPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    string _historyFileName = Path.Combine(FileSystem.AppDataDirectory, "notes_history.json");

    List<NoteEntry> _history = new();

    public DnDHubPage()
    {
        InitializeComponent();
        LoadCurrentNote();
        LoadHistory();
    }

    void LoadCurrentNote()
    {
        if (File.Exists(_fileName))
        {
            editor.Text = File.ReadAllText(_fileName);
        }
    }

    void LoadHistory()
    {
        if (File.Exists(_historyFileName))
        {
            var json = File.ReadAllText(_historyFileName);
            _history = JsonSerializer.Deserialize<List<NoteEntry>>(json) ?? new();
        }

        RefreshHistoryList();
    }

    void RefreshHistoryList()
    {
        historyList.ItemsSource = null;
        historyList.ItemsSource = _history.OrderByDescending(n => n.Date).ToList();
    }

    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, editor.Text);

        _history.Add(new NoteEntry
        {
            Date = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
            Text = editor.Text
        });

        File.WriteAllText(_historyFileName, JsonSerializer.Serialize(_history));

        RefreshHistoryList();
    }

    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        editor.Text = string.Empty;
    }
}