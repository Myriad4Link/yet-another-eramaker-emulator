using Avalonia.Media;
using Pure.DI;
using YaEmuera.Properties.Abstractions;

namespace YaEmuera.ViewModels;

public class MainWindowViewModel(
    [Tag("TextBoxForegroundColorProperty")]
    IColorProperty textBoxForegroundColorProperty,
    [Tag("TextBoxBackgroundColorProperty")]
    IColorProperty textBoxBackgroundColorProperty,
    [Tag("TextBoxBorderBackgroundColorProperty")]
    IColorProperty textBoxBorderBackgroundColorProperty
) : ViewModelBase
{
    public Color TextBoxForegroundColorProperty { get; set; } = textBoxForegroundColorProperty.ColorProperty;
    public Color TextBoxBackgroundColorProperty { get; set; } = textBoxBackgroundColorProperty.ColorProperty;

    public Color TextBoxBorderBackgroundColorProperty { get; set; } =
        textBoxBorderBackgroundColorProperty.ColorProperty;
}