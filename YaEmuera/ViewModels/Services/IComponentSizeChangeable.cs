using YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

namespace YaEmuera.ViewModels.Services;

public interface IComponentSizeChangeable
{
    public void OnScreenResolutionChanged(object? _, ScreenResolutionChangedEventArgs e);
}