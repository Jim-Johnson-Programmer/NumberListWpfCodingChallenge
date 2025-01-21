using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using System.Windows.Media;

namespace NumberListWpfCodingChallenge.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputNumbers;
        private string _largestNumberMessage;
        private Brush _resultColor;
        private static readonly Regex ValidInputRegex = new Regex("^-?[0-9]+(,-?[0-9]+)*$", RegexOptions.Compiled);

        public string InputNumbers
        {
            get => _inputNumbers;
            set
            {
                _inputNumbers = value;
                OnPropertyChanged(nameof(InputNumbers));
                ValidateInput();
            }
        }

        public string LargestNumberMessage
        {
            get => _largestNumberMessage;
            set
            {
                _largestNumberMessage = value;
                OnPropertyChanged(nameof(LargestNumberMessage));
            }
        }

        public Brush ResultColor
        {
            get => _resultColor;
            set
            {
                _resultColor = value;
                OnPropertyChanged(nameof(ResultColor));
            }
        }

        private bool _isInputValid;
        public bool IsInputValid
        {
            get => _isInputValid;
            private set
            {
                _isInputValid = value;
                OnPropertyChanged(nameof(IsInputValid));
                ((RelayCommand)FindLargestCommand).RaiseCanExecuteChanged();
                ((RelayCommand)FindOddSumCommand).RaiseCanExecuteChanged();
                ((RelayCommand)FindEvenSumCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand FindLargestCommand { get; }
        public ICommand FindOddSumCommand { get; }
        public ICommand FindEvenSumCommand { get; }

        public MainViewModel()
        {
            FindLargestCommand = new RelayCommand(FindLargest, () => IsInputValid);
            FindOddSumCommand = new RelayCommand(FindOddSum, () => IsInputValid);
            FindEvenSumCommand = new RelayCommand(FindEvenSum, () => IsInputValid);
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(InputNumbers))
            {
                IsInputValid = false;
                LargestNumberMessage = "Input cannot be empty.";
                ResultColor = Brushes.Black;
                return;
            }

            if (!ValidInputRegex.IsMatch(InputNumbers))
            {
                IsInputValid = false;
                LargestNumberMessage = "Input must contain only integers (positive or negative) and commas.";
                ResultColor = Brushes.Black;
                return;
            }

            IsInputValid = true;
            LargestNumberMessage = string.Empty;
            ResultColor = Brushes.Black;
        }

        private void FindLargest()
        {
            try
            {
                var numbers = InputNumbers.Split(',')
                                          .Select(n => int.Parse(n.Trim()))
                                          .ToArray();

                int largest = numbers.Max();
                LargestNumberMessage = $"The largest number is: {largest}";
                ResultColor = largest >= 0 ? Brushes.Green : Brushes.Red;
            }
            catch (Exception ex)
            {
                LargestNumberMessage = $"Error: {ex.Message}";
                ResultColor = Brushes.Black;
            }
        }

        private void FindOddSum()
        {
            try
            {
                var numbers = InputNumbers.Split(',')
                                          .Select(n => int.Parse(n.Trim()))
                                          .ToArray();

                int sumOddPositioned = numbers.Where((_, index) => index % 2 == 0).Sum();
                LargestNumberMessage = $"The sum of odd-positioned numbers is: {sumOddPositioned}";
                ResultColor = sumOddPositioned >= 0 ? Brushes.Green : Brushes.Red;
            }
            catch (Exception ex)
            {
                LargestNumberMessage = $"Error: {ex.Message}";
                ResultColor = Brushes.Black;
            }
        }

        private void FindEvenSum()
        {
            try
            {
                var numbers = InputNumbers.Split(',')
                                          .Select(n => int.Parse(n.Trim()))
                                          .ToArray();

                int sumEvenPositioned = numbers.Where((_, index) => index % 2 != 0).Sum();
                LargestNumberMessage = $"The sum of even-positioned numbers is: {sumEvenPositioned}";
                ResultColor = sumEvenPositioned >= 0 ? Brushes.Green : Brushes.Red;
            }
            catch (Exception ex)
            {
                LargestNumberMessage = $"Error: {ex.Message}";
                ResultColor = Brushes.Black;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
