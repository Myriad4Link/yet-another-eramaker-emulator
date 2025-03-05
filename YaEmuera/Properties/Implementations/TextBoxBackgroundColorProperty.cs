using Avalonia.Media;
using YaEmuera.Properties.Abstractions;

namespace YaEmuera.Properties.Implementations;

public class TextBoxBackgroundColorProperty : IColorProperty
{
    public Color ColorProperty { get; set; } = Colors.Black;
}