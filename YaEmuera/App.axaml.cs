using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace YaEmuera;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var composition = new Composition(defaultWidth: 1920, defaultHeight: 1080);
        Resources.Add(nameof(Composition), composition);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = composition.MainWindow;
            var vm = composition.MainWindowViewModel;

            if (desktop.MainWindow.Screens.Primary != null)
            {
                // Which it should never be null.
                vm.ScreenResolutionChangeNotifier.ScreenWidth =
                    desktop.MainWindow.Screens.Primary.Bounds.Width;
                vm.ScreenResolutionChangeNotifier.ScreenHeight =
                    desktop.MainWindow.Screens.Primary.Bounds.Height;
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}