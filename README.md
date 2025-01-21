# NumberListWpfCodingChallenge

This WPF application allows users to input a comma-delimited list of integers and perform various operations such as finding the largest number, summing odd-positioned numbers, and summing even-positioned numbers. 

## Features
- **Input Validation**: Accepts positive and negative integers separated by commas. Provides error feedback for invalid input.
- **Find Largest Number**: Identifies the largest number from the input list.
- **Sum Odd-Positioned Numbers**: Calculates the sum of numbers at odd positions in the list (index-based).
- **Sum Even-Positioned Numbers**: Calculates the sum of numbers at even positions in the list (index-based).
- **Dynamic UI Feedback**:
  - Input validation enables or disables buttons dynamically.
  - Output is displayed in red for negative values and green for positive values.

## UI Overview
- **User Input**: A labeled input textbox for entering a list of integers.
- **Buttons**:
  - "Find Largest"
  - "Find Odd Positioned Sum"
  - "Find Even Positioned Sum"
- **Output**: A result label displaying the operation result, with color-coded feedback.
  
### UI Layout
1. **Row 1**: Input label ("User Input") and textbox.
2. **Row 2**: Buttons, spaced evenly with curved corners.
3. **Row 3**: Result label ("Result") and dynamic text output.

## Usage
1. Enter a list of integers separated by commas (e.g., `3,-1,7,8,-5`).
2. Click one of the buttons:
   - **Find Largest**: Displays the largest number in the list.
   - **Find Odd Positioned Sum**: Displays the sum of numbers at odd positions.
   - **Find Even Positioned Sum**: Displays the sum of numbers at even positions.
3. Observe the result color and message.

## Input Validation
- Accepts: `3,-1,7,8,-5`
- Invalid examples:
  - `3, abc, 5` (non-numeric input)
  - `3,4.5,7` (decimal values)
  - `3,,7` (extra commas)

## Technologies Used
- **Framework**: .NET WPF
- **Language**: C#
- **Pattern**: MVVM (Model-View-ViewModel)

## Project Structure
```plaintext
NumberListWpfCodingChallenge/
├── MainWindow.xaml          # Main UI layout
├── MainWindow.xaml.cs       # Code-behind for UI
├── ViewModels/
│   └── MainViewModel.cs     # ViewModel for binding logic
├── RelayCommand.cs          # Implementation of ICommand
├── App.xaml                 # Application resources
├── App.xaml.cs              # Application startup
