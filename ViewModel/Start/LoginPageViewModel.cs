
using AppPicking.Helpers;
using AppPicking.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        LoginServices loginServices;

        [ObservableProperty]
        private string _usuario;

        [ObservableProperty]
        private string _password;

        public LoginPageViewModel(LoginServices loginServices)
        {
            this.Title = "Login";
            this.loginServices= loginServices;
        }


        #region
        [RelayCommand]
        async Task Login() {

            try
            {
                var user = await loginServices.LoginAsync(this.Usuario, this.Password);

                if (user is not null)
                {

                string userDetailStr = JsonConvert.SerializeObject(user);
                App.UserDetails = user;
                Preferences.Set(nameof(App.UserDetails), userDetailStr);
                await AppConstant.AddFlyoutMenusDetails();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
