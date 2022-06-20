
namespace AppPicking.View;

public partial class RecepcionDetailsPage : ContentPage
{
	public RecepcionDetailsPage(RecepcionDetailsPageViewModel viewModel)
	{
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}