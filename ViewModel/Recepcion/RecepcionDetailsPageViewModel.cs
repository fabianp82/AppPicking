using AppPicking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.ViewModel
{
    [QueryProperty(nameof(Recepcion), nameof(Recepcion))]
    public partial class RecepcionDetailsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        Recepcion recepcion;
        RecepcionServices recepcionServices;
        IConnectivity connectivity;
        [ObservableProperty]
        bool isRefreshing;

        public RecepcionDetailsPageViewModel(RecepcionServices recepcionServices, IConnectivity connectivity)
        {
            this.recepcionServices = recepcionServices;
            this.connectivity = connectivity;
            // var a = GetArticulosAsync();
        }

        partial void OnRecepcionChanged(Recepcion value)
        {
            var r = GetArticulosAsync();
        }


        [RelayCommand]
        async Task GetArticulosAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;
                if (recepcion is not null)
                {
                    var articulos = await recepcionServices.GetArticulos(recepcion.Id);

                    Recepcion.articulos.AddRange(articulos);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get articulos: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task GetFotoAsync()
        {
            return ;
        }


    }
}
