using System.Reactive;
using Avalonia.Media;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using YaEmuera.Views;

namespace YaEmuera.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // Set the size of menu items dynamically according to screen resolution. 
    // Base resolution: 1920x1080
    private const int DefaultSecondaryMenuItemWidth = 272;
    private const int DefaultMenuItemHeight = 23;

    private const int DefaultScreenResolutionWidth = 1920;
    private const int DefaultScreenResolutionHeight = 1080;

    private int _menuItemHeight = DefaultMenuItemHeight;
    private int _secondaryMenuItemWidth = DefaultSecondaryMenuItemWidth;

    public MainWindowViewModel()
    {
        RestartCommand = ReactiveCommand.Create(() =>
        {
            if (MainWindow != null)
                MessageBoxManager.GetMessageBoxStandard(
                    new MessageBoxStandardParams
                    {
                        ContentTitle = "Restart Confirmation",
                        ContentMessage = """
                                         You are about to restart yaEmuera. All progress unsaved will be loss.
                                         Are you sure to do this?
                                         """,
                        Topmost = true,
                        CanResize = false,
                        ShowInCenter = true,
                        ButtonDefinitions = ButtonEnum.OkCancel
                    }).ShowWindowDialogAsync(MainWindow);
        });
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

    public int PrimaryScreenResolutionWidth
    {
        set => SecondaryMenuItemWidth = value * SecondaryMenuItemWidth / DefaultScreenResolutionWidth;
    }

    public int PrimaryScreenResolutionHeight
    {
        set => MenuItemHeight = value * MenuItemHeight / DefaultScreenResolutionHeight;
    }

    public ReactiveCommand<Unit, Unit> RestartCommand { get; }
}