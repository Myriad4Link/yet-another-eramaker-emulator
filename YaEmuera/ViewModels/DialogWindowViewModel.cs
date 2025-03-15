using YaEmuera.ViewModels.Services;
using YaEmuera.ViewModels.Services.ScreenResolution;
using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

namespace YaEmuera.ViewModels;

// ReSharper disable once ClassNeverInstantiated.Global
public class DialogWindowViewModel : AbstractDialogWindowViewModel, IComponentSizeChangeable
{
    public DialogWindowViewModel(IScreenResolutionChangeNotifier notifier)
    {
        notifier.ScreenSolutionChanged += OnScreenResolutionChanged;
    }

    public override int Width { get; set; }

    public override int Height { get; set; }

    public void OnScreenResolutionChanged(object? _, ScreenResolutionChangedEventArgs e)
    {
        // switch (e)
        // {
        //     case ScreenResolutionWidthChangedEventArgs _widthChanged :
        //         Width = 
        // }
    }
}