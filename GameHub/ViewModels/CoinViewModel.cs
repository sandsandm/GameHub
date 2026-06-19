using System.Windows.Input;

namespace GameHub.ViewModels;

public class CoinViewModel : BindableObject
{    
    public ICommand FlipCommand { get; }
	private readonly Random _random = new();
    private List<string> history = new List<string>();
    private string _result = "";
    public string Result
    {
        get => _result;
        set
        {
            if (_result == value) return;
            _result = value;
            OnPropertyChanged(nameof(Result));
        }
    }
    private string _historyText = "Нет истории";
    public string HistoryLabel
    {
        get => _historyText;
        set
        {
            if (_historyText == value) return;
            _historyText = value;
            OnPropertyChanged(nameof(HistoryLabel));
        }
    }
    public CoinViewModel()
	{
	    FlipCommand = new Command(() =>
        {
            Result = _random.Next(0, 2) == 0
                ? "🦅"
                : "🪙";

            
            string historyEntry = $"{DateTime.Now:HH:mm} - {Result}";
            history.Add(historyEntry);

            var lastEntries = history.Count > 10 ? history.GetRange(history.Count - 10, 10) : history;
            HistoryLabel = string.Join("\n", lastEntries);
        });

	}
}