using Pure.DI;
using YaEmuera.ViewModels;

namespace YaEmuera;

public partial class Composition
{
    private void Setup() => DI.Setup()
        .Root<MainWindowViewModel>(nameof(MainWindowViewModel));
}