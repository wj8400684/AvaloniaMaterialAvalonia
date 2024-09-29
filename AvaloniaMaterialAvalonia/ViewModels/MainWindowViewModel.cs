using System.Threading.Tasks;
using System.Xml.Serialization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using AvaloniaMaterialAvalonia.Views;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Material.Dialog;

namespace AvaloniaMaterialAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public required MainWindow Window { get; set; }
    
    [RelayCommand]
    private async Task OnStartAsync()
    {
        var result = await DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams {
            ContentHeader = "Rename folder",
            StartupLocation = WindowStartupLocation.CenterOwner,
            Borderless = true,
            Width = 400,
            TextFields = new TextFieldBuilderParams[] {
                new() {
                    Label = "Folder name",
                    MaxCountChars = 256,
                    DefaultText = "Folder1",
                    HelperText = "* Required"
                }
            },
            DialogButtons = new[] {
                new DialogButton {
                    Content = "CANCEL",
                    Result = "cancel",
                    IsNegative = true
                },
                new DialogButton {
                    Content = "RENAME",
                    Result = "rename",
                    IsPositive = true
                }
            },
        }).ShowDialog(Window);
        
        // var dialog = DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams {
        //     ContentHeader = "Welcome to use Material.Avalonia",
        //     SupportingText = "Enjoy Material Design in AvaloniaUI!",
        //     StartupLocation = WindowStartupLocation.CenterOwner
        // });
        // var result = await dialog.ShowDialog(Window);
    }
}