using System.Timers;
using System.Windows.Input;
using Timer = System.Timers.Timer;

namespace GameHub.ViewModels;

public class TimerViewModel : BindableObject, IDisposable
{
    private readonly Timer _timer;
    private TimeSpan _remaining = TimeSpan.FromMinutes(5);

    public TimerViewModel()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimerElapsed;

        StartCommand = new Command(() => _timer.Start());
        PauseCommand = new Command(() => _timer.Stop());
        ResetCommand = new Command(() =>
        {
            _timer.Stop();
            _remaining = TimeSpan.FromMinutes(5);
            OnPropertyChanged(nameof(DisplayTime));
        });
        Add10SecCommand = new Command(() => ChangeTime(10));
        Add30SecCommand = new Command(() => ChangeTime(30));
        Add1MinCommand = new Command(() => ChangeTime(60));

        Sub10SecCommand = new Command(() => ChangeTime(-10));
        Sub30SecCommand = new Command(() => ChangeTime(-30));
        Sub1MinCommand = new Command(() => ChangeTime(-60));

    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (_remaining.TotalSeconds > 0)
        {
            _remaining = _remaining.Add(TimeSpan.FromSeconds(-1));
        }
        else
        {
            _timer.Stop();
        }
        MainThread.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(DisplayTime)));
    }
    private void ChangeTime(int seconds)
    {
        if (seconds < 0 && _remaining.TotalSeconds < Math.Abs(seconds))
            return;

        _remaining = _remaining.Add(TimeSpan.FromSeconds(seconds));
        OnPropertyChanged(nameof(DisplayTime));

    }

    public string Title => "Таймер";
    public string DisplayTime => _remaining.ToString(@"mm\:ss");
    public ICommand StartCommand { get; }
    public ICommand PauseCommand { get; }
    public ICommand ResetCommand { get; }
    public ICommand Add10SecCommand { get; }
    public ICommand Add30SecCommand { get; }
    public ICommand Add1MinCommand { get; }
    public ICommand Sub10SecCommand { get; }
    public ICommand Sub30SecCommand { get; }
    public ICommand Sub1MinCommand { get; }

    public void Dispose()
    {
        _timer.Elapsed -= OnTimerElapsed;
        _timer.Stop();
        _timer.Dispose();
    }
}