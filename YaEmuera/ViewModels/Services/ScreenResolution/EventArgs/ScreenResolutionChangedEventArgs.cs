namespace YaEmuera.ViewModels.Services.ScreenResolution.EventArgs;

public abstract class ScreenResolutionChangedEventArgs : System.EventArgs
{
    public required int Value { get; set; }
}