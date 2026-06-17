namespace GameHub.Views.Modules;

public partial class DiceView : ContentView
{
    private Random random = new Random();
    private List<string> history = new List<string>();

    public DiceView()
    {
        InitializeComponent();
    }

    private void OnRollDiceClicked(object sender, EventArgs e)
    {
        
        int sides = GetSelectedSides();

      
        int result = random.Next(1, sides + 1);

        ResultLabel.Text = result.ToString();

        string historyEntry = $"{DateTime.Now:HH:mm} - D{sides}: {result}";
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

    private int GetSelectedSides()
    {
        
        if (DiceTypePicker.SelectedIndex == -1)
        {
            return 6; 
        }

        
        return DiceTypePicker.SelectedIndex switch
        {
            0 => 6,
            1 => 12,
            2 => 20,
            3 => 25,
            _ => 6
        };
    }
}