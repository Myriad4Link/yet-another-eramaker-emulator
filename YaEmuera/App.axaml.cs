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
        if (Resources[nameof(Composition)] is Composition composition)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = composition.MainWindow;
                var vm = composition.MainWindowViewModel;

                if (desktop.MainWindow.Screens.Primary != null)
                {
                    // Which it should never be null.
                    vm.PrimaryScreenResolutionWidth = desktop.MainWindow.Screens.Primary.Bounds.Width;
                    vm.PrimaryScreenResolutionHeight = desktop.MainWindow.Screens.Primary.Bounds.Height;
                }
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}