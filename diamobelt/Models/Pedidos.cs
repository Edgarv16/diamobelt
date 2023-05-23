using System;
using System.Collections.Generic;
using System.Text;

namespace diamobelt.Models
{
    public class Pedidos
    {
        //public int idPedido { get; set; }
        public int idCliente {  get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime fechaEntrega { get; set; }
        public double valorTotal { get; private set; }
        public string direccionEntrega { get; set; }
        public string formaPago { get; set; }
        public string pagado { get; set; }
        public string fotoPedido { get; set;}

    }
}
