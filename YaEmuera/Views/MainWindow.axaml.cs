using Avalonia.Controls;

namespace YaEmuera.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        if (DataContext is Composition composition)
        {
            composition.MainWindowViewModel.MainWindow = this;
        }
    }
}