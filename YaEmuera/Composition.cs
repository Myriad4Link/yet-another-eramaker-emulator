using Pure.DI;
using YaEmuera.ViewModels;
using YaEmuera.Views;

namespace YaEmuera;

public partial class Composition
{
    private void Setup() => DI.Setup()
        .Root<MainWindowViewModel>(nameof(MainWindowViewModel))
        .Root<MainWindow>(nameof(MainWindow))
        .Bind().As(Lifetime.Singleton).To<MainWindowViewModel>();
}