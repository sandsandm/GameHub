using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GameHub.ViewModels;

public class RandomizerViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly Random _random = new();
    private int _minValue = 1;
    private int _maxValue = 100;
    private int _result;
    private bool _isResultVisible;

    public int MinValue
    {
        get => _minValue;
        set
        {
            _minValue = value;
            OnPropertyChanged();
            ValidateRange();
        }
    }

    public int MaxValue
    {
        get => _maxValue;
        set
        {
            _maxValue = value;
            OnPropertyChanged();
            ValidateRange();
        }
    }

    public int Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    public bool IsResultVisible
    {
        get => _isResultVisible;
        set
        {
            _isResultVisible = value;
            OnPropertyChanged();
        }
    }

    public string RangeValidationMessage { get; private set; } = string.Empty;

    public ICommand GenerateRandomCommand { get; }

    public RandomizerViewModel()
    {
        GenerateRandomCommand = new Command(GenerateRandom);
        ValidateRange();
    }

    private void GenerateRandom()
    {
        if (MinValue >= MaxValue) return;

        Result = _random.Next(MinValue, MaxValue + 1);
        IsResultVisible = true;
    }

    private void ValidateRange()
    {
        if (MinValue >= MaxValue)
        {
            RangeValidationMessage = "От должно быть меньше До";
        }
        else
        {
            RangeValidationMessage = string.Empty;
        }

        OnPropertyChanged(nameof(RangeValidationMessage));
    }
}