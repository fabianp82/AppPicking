using AppPicking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Services
{
    public class LoginServices
    {
        UserBasicInfo userBasicInfo;
        public LoginServices()
        {

        }

        public async Task<UserBasicInfo> LoginAsync(string usuario, string password)
        {
            //Aca va la conexion a servicios ahora esta por archivos json 

            using var stream = await FileSystem.OpenAppPackageFileAsync("Usuarios.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            var listUserBasicInfo = JsonSerializer.Deserialize<List<UserBasicInfo>>(contents).ToList();

            userBasicInfo = listUserBasicInfo.Where(x => x.Usuario == usuario && x.Pass == password).FirstOrDefault();

            return userBasicInfo;
        }

    }
}
