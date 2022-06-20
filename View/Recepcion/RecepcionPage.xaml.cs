namespace AppPicking.View;

public partial class RecepcionPage : ContentPage
{
	public RecepcionPage(RecepcionPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}