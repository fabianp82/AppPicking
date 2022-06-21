
namespace AppPicking.View;

public partial class RecepcionDetailsPage : ContentPage
{
	public RecepcionDetailsPage(RecepcionDetailsPageViewModel viewModel)
	{
        InitializeComponent();
        this.BindingContext = viewModel;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}