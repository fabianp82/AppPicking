using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.ViewModel
{
    public partial class RecepcionPageViewModel : BaseViewModel
    {
        public ObservableCollection<Recepcion> recepcions { get; } = new();
        RecepcionServices recepcionServices;
        IConnectivity connectivity;
        [ObservableProperty]
        bool isRefreshing;

        public RecepcionPageViewModel(RecepcionServices recepcionServices, IConnectivity connectivity)
        {
            this.Title = "Recepcion de Mercaderias";
            this.recepcionServices = recepcionServices;
            this.connectivity = connectivity;
            var a = GetRecepcionsAsync();
        }

        [RelayCommand]
        async Task GetRecepcionsAsync()
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
                var recepciones = await recepcionServices.GetRecepcion();

                if (recepciones.Count != 0)
                    recepcions.Clear();

                foreach (var monkey in recepciones)
                    recepcions.Add(monkey);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async void GoToDetails(Recepcion recepcion)
        {
            if (recepcion == null)
                return;

            //await Shell.Current.DisplayAlert("Pedido!", recepcion.NroPedido, "OK");


            //await Shell.Current.GoToAsync($"//{nameof(RecepcionPage)}");
            await Shell.Current.GoToAsync($"{nameof(RecepcionDetailsPage)}", true, new Dictionary<string, object>
            {
                ["Recepcion"]= recepcion 
            });
        }
    }
}
