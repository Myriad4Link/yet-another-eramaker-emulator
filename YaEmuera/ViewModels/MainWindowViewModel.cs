using System.Reactive;
using Avalonia.Media;
using NLog;
using ReactiveUI;
using YaEmuera.ViewModels.Services.ScreenResolution;
using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;
using YaEmuera.Views;

namespace YaEmuera.ViewModels;

public class MainWindowViewModel : AbstractMainWindowViewModel
{
    // Set the size of menu items dynamically according to screen resolution. 
    // Base resolution: 1920x1080
    private const int DefaultSecondaryMenuItemWidth = 272;
    private const int DefaultMenuItemHeight = 23;

    private const int DefaultScreenResolutionWidth = 1920;
    private const int DefaultScreenResolutionHeight = 1080;
    public readonly IScreenResolutionChangeNotifier ScreenResolutionChangeNotifier;

    private int _menuItemHeight = DefaultMenuItemHeight;
    private int _secondaryMenuItemWidth = DefaultSecondaryMenuItemWidth;

    public MainWindowViewModel(IScreenResolutionChangeNotifier screenResolutionChangeNotifier, ILogger logger)
    {
        ScreenResolutionChangeNotifier = screenResolutionChangeNotifier;
        ScreenResolutionChangeNotifier.ScreenSolutionChanged += OnScreenResolutionChanged;

        logger.Debug("MainWindowViewModel created");
    }

    public MainWindow? MainWindow { private get; set; }

    public Color TextBoxForegroundColorProperty { get; set; } = Colors.White;
    public Color TextBoxBackgroundColorProperty { get; set; } = Colors.Black;

    public Color TextBoxBorderBackgroundColorProperty { get; set; } = Colors.Black;

    public int SecondaryMenuItemWidth
    {
        get => _secondaryMenuItemWidth;
        set => this.RaiseAndSetIfChanged(ref _secondaryMenuItemWidth, value);
    }

    public int MenuItemHeight
    {
        get => _menuItemHeight;
        set => this.RaiseAndSetIfChanged(ref _menuItemHeight, value);
    }

    public ReactiveCommand<Unit, Unit> RestartCommand { get; } = ReactiveCommand.Create(() => { });

    private void OnScreenResolutionChanged(object? _, ScreenResolutionChangedEventArgs e)
    {
        switch (e)
        {
            case ScreenResolutionWidthChangedEventArgs widthChangedEventArgs:
                SecondaryMenuItemWidth = DefaultSecondaryMenuItemWidth * widthChangedEventArgs.Value /
                                         DefaultScreenResolutionWidth;
                break;
            case ScreenResolutionHeightChangedEventArgs heightChangedEventArgs:
                MenuItemHeight = DefaultMenuItemHeight * heightChangedEventArgs.Value / DefaultScreenResolutionHeight;
                break;
        }
    }
}