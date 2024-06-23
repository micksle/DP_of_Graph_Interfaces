using System.IO;
using System.Windows;
using System.Windows.Input;

namespace DP_of_Graph_Interfaces;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
        // Реєстрація прив'язки
        CommandBindings.Add(saveCommand);
        
        CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
        // Реєстрація прив'язки
        CommandBindings.Add(openCommand);
        
        CommandBinding deleteCommand = new CommandBinding(ApplicationCommands.Delete, execute_Delete, canExecute_Delete);
        // Реєстрація прив'язки
        CommandBindings.Add(deleteCommand);
    }
    
    private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
    {
        if (InputTextBox != null && InputTextBox.Text.Trim().Length > 0)
            e.CanExecute = true;
        else
            e.CanExecute = false;
    }

    private void execute_Save(object sender, ExecutedRoutedEventArgs e)
    {
        File.WriteAllText("d:\\myFile.txt", InputTextBox.Text);
        MessageBox.Show("The file was saved!");
    }
    
    private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    private void execute_Open(object sender, ExecutedRoutedEventArgs e)
    {
        InputTextBox.Text = File.ReadAllText("d:\\myFile.txt");
    }
    
    private void canExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
    {
        if (InputTextBox != null && InputTextBox.Text.Trim().Length > 0)
            e.CanExecute = true;
        else
            e.CanExecute = false;
    }

    private void execute_Delete(object sender, ExecutedRoutedEventArgs e)
    {
        InputTextBox.Text = "";
    }
}