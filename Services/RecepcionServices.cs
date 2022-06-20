using AppPicking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Services
{
    public class RecepcionServices
    {
        HttpClient httpClient;
        List<Recepcion> recepcions;
        List<Articulos> articulos;

        public RecepcionServices()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Recepcion>> GetRecepcion()
        {
            if (recepcions?.Count > 0)
                return recepcions;

            // Online
            //var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    recepcions = await response.Content.ReadFromJsonAsync<List<Recepcion>>();
            //}

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("Recepcion.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            recepcions = JsonSerializer.Deserialize<List<Recepcion>>(contents);
            
            return recepcions;
}

        public async Task<List<Articulos>> GetArticulos(int pedidoId)
        {

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("Articulos.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            articulos = JsonSerializer.Deserialize<List<Articulos>>(contents);

            return articulos;
        }
    }
}
