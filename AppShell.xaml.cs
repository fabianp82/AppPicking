namespace AppPicking;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
        Routing.RegisterRoute("RecepcionDetailsPage", typeof(RecepcionDetailsPage));

    }
}
