using System;
using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

namespace YaEmuera.ViewModels.Services.ScreenResolution;

public class ScreenResolutionChangeNotifier : IScreenResolutionChangeNotifier
{
    public int ScreenWidth
    {
        set => ScreenSolutionChanged?.Invoke(this, new ScreenResolutionWidthChangedEventArgs { Value = value });
    }

    public int ScreenHeight
    {
        set => ScreenSolutionChanged?.Invoke(this, new ScreenResolutionHeightChangedEventArgs { Value = value });
    }

    public event EventHandler<ScreenResolutionChangedEventArgs>? ScreenSolutionChanged;
}