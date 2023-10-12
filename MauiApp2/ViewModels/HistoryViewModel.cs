using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp2.ViewModels;

[QueryProperty("Text", "Text")]
public partial class HistoryViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
