namespace GameHub.Views.Modules;

public partial class DiceView : ContentView
{
    private Random random = new Random();
    private List<string> history = new List<string>();

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnRollDiceClicked(object sender, EventArgs e)
    {
        
        int result = random.Next(1, 7);

        
        ResultLabel.Text = result.ToString();

       

       
        string historyEntry = $"{DateTime.Now:HH:mm:ss} - Выпало: {result}";
        history.Add(historyEntry);

      
        var lastEntries = history.Count > 10 ? history.GetRange(history.Count - 10, 10) : history;
        HistoryLabel.Text = string.Join("\n", lastEntries);
    }

    private void OnClearHistoryClicked(object sender, EventArgs e)
    {
        history.Clear();
        HistoryLabel.Text = "Нет истории";
        ResultLabel.Text = "?";
    }
}