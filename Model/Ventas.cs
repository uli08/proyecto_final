using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ventas
    {
        public int VentasId { get; set; }
        public string Idcliente { get; set; }
        public string Idvendedor { get; set; }
        public string Pieza { get; set; }
        public string Total { get; set; }
        public string Fecha { get; set; }
    }
}
