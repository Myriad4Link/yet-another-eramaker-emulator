using System;
using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

namespace YaEmuera.ViewModels.Services.ScreenResolution;

public interface IScreenResolutionChangeNotifier
{
    public int ScreenWidth { set; }
    public int ScreenHeight { set; }
    public event EventHandler<ScreenResolutionChangedEventArgs> ScreenSolutionChanged;
}