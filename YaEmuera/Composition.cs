using NLog;
using NLog.Config;
using Pure.DI;
using YaEmuera.ViewModels;
using YaEmuera.ViewModels.Services.ScreenResolution;
using YaEmuera.Views;
using static Pure.DI.Tag;

namespace YaEmuera;

public partial class Composition
{
    // ReSharper disable once UnusedMember.Local
    private void Setup() => DI.Setup(nameof(Composition))
        // Composition root configuration. Should think of a way to make only one root.
        .Root<MainWindowViewModel>(nameof(MainWindowViewModel))
        .Root<MainWindow>(nameof(MainWindow))

        // Register view models as services for each other to use.
        .Bind().As(Lifetime.Singleton).To<MainWindowViewModel>()
        .Bind().As(Lifetime.Transient).To<DialogWindowViewModel>()

        // Register some universally used arguments.
        .Arg<int>("defaultWidth", DefaultWidth)
        .Arg<int>("defaultHeight", DefaultHeight)

        // Register NLog's ILogger
        .Bind<ILogger>().To(ctx =>
        {
            LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
            return LogManager.GetLogger(ctx.ConsumerTypes[0].FullName);
        })

        // Register other services.
        .Bind().As(Lifetime.Singleton).To<ScreenResolutionChangeNotifier>();
}