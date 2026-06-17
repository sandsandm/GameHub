using System.Windows.Input;

namespace GameHub.ViewModels;

public class TimerViewModel : BindableObject
{
    private readonly System.Timers.Timer _timer;
    private TimeSpan _remaining = TimeSpan.FromMinutes(5);

    public TimerViewModel()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += (_, _) =>
        {
            if (_remaining.TotalSeconds > 0)
            {
                _remaining = _remaining.Add(TimeSpan.FromSeconds(-1));
                OnPropertyChanged(nameof(DisplayTime));
            }
            else
            {
                _timer.Stop();
            }
        };

        StartCommand = new Command(() => _timer.Start());
        PauseCommand = new Command(() => _timer.Stop());
        ResetCommand = new Command(() =>
        {
            _timer.Stop();
            _remaining = TimeSpan.FromMinutes(5);
            OnPropertyChanged(nameof(DisplayTime));
        });
    }

    public string Title => "Game Timer";
    public string DisplayTime => _remaining.ToString(@"mm\:ss");
    public ICommand StartCommand { get; }
    public ICommand PauseCommand { get; }
    public ICommand ResetCommand { get; }
}