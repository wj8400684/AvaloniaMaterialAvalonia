using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AvaloniaMaterialAvalonia.ViewModels;
using AvaloniaMaterialAvalonia.Views;

namespace AvaloniaMaterialAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var windows = new MainWindow();
            windows.DataContext = new MainWindowViewModel
            {
                Window = windows,
            };
            desktop.MainWindow = windows;
        }

        base.OnFrameworkInitializationCompleted();
    }
}