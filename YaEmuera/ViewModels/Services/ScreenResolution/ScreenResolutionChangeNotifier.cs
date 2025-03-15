using System;
using NLog;
using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

namespace YaEmuera.ViewModels.Services.ScreenResolution;

public class ScreenResolutionChangeNotifier : IScreenResolutionChangeNotifier
{
    private readonly ILogger _logger;

    public ScreenResolutionChangeNotifier(ILogger logger)
    {
        _logger = logger;
    }

    public int ScreenWidth
    {
        set
        {
            ScreenSolutionChanged?.Invoke(this, new ScreenResolutionWidthChangedEventArgs { Value = value });
            _logger.Debug($"Screen width detected: {value}.");
        }
    }

    public int ScreenHeight
    {
        set
        {
            ScreenSolutionChanged?.Invoke(this, new ScreenResolutionHeightChangedEventArgs { Value = value });
            _logger.Debug($"Screen height detected: {value}.");
        }
    }

    public event EventHandler<ScreenResolutionChangedEventArgs>? ScreenSolutionChanged;
}