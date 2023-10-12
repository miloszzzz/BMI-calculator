using MauiApp2.ViewModels;

namespace MauiApp2;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(HistoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}