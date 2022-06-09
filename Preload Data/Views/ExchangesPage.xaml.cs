using Preload_Data.ViewModels;

namespace Preload_Data.Views;

public partial class ExchangesPage : ContentPage
{
	public ExchangesPage(ExchangesViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}