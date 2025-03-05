using Pure.DI;
using YaEmuera.Properties.Implementations;
using YaEmuera.ViewModels;

namespace YaEmuera;

public partial class Composition
{
    private void Setup() => DI.Setup()
        .Root<MainWindowViewModel>(nameof(MainWindowViewModel))
        .Bind(nameof(TextBoxForegroundColorProperty)).To<TextBoxForegroundColorProperty>()
        .Bind(nameof(TextBoxBackgroundColorProperty)).To<TextBoxBackgroundColorProperty>()
        .Bind(nameof(TextBoxBorderBackgroundColorProperty)).To<TextBoxBorderBackgroundColorProperty>();
}