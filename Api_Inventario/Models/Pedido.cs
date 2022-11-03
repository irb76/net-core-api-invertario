using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Inventario.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idProd { get; set; }
        public int cantidad { get; set; }
    }
}
