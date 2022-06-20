using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPicking.Model
{
    public class Recepcion
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string NroPedido { get; set; }
        public string FechaPedido { get; set; }
        public int Cantidad { get; set; }
        public List<Articulos> articulos { get; set; }
        public Recepcion()
        {
            articulos=new List<Articulos>();
        }
    }
    public class Articulos
    {
        public int PedidoId { get; set; }
        public int PedidoDetalleId { get; set; }
        public string Articulo { get; set; }
        public string CodArt { get; set; }
        public int Cantidad { get; set; }
    }

}
