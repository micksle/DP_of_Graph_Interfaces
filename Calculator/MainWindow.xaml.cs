using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private bool isResultShown = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (isResultShown)
            {
                IoTextBox.Clear();
                isResultShown = false;
            }

            if (sender is Button button)
            {
                IoTextBox.Text += button.Content.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (isResultShown)
            {
                isResultShown = false;
            }

            if (sender is Button button)
            {
                IoTextBox.Text += button.Content.ToString();
            }
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            IoTextBox.Text = "";
            isResultShown = false;
        }

        private void OnEqualButton_Click(object sender, RoutedEventArgs e)
        {
            var equation = IoTextBox.Text;

            equation = equation.Replace("×", "*").Replace("÷", "/").Replace(",", ".");
            // Trying to validate and compute the equation, entered into the 'IoTextBox'
            try
            {
                var result = new System.Data.DataTable().Compute(equation, "");
                IoTextBox.Text = Convert.ToDecimal(result).ToString("0.###");
                isResultShown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                Clipboard.SetText(IoTextBox.Text);
            }
        }
    }
}