namespace AppPicking.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.UserDetails != null)
        {
			lblUserName.Text = App.UserDetails.FullName;
            //lblUserEmail.Text = App.UserDetails.Usuario;
            lblUserRole.Text = App.UserDetails.RoleText;
        }
    }
}