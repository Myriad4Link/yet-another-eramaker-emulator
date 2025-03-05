using Avalonia.Media;

namespace YaEmuera.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public Color TextBoxForegroundColorProperty { get; set; } = Colors.White;
    public Color TextBoxBackgroundColorProperty { get; set; } = Colors.Black;
    public Color TextBoxBorderBackgroundColorProperty { get; set; } = Colors.Black;
}