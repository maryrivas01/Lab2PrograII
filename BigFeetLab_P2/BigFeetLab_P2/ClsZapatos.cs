using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFeetLab_P2
{
    public class ClsZapatos
    {
        public string IdProducto { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Talla { get; set; }
        public int Cantidad { get; set; }
        public float PrecioCompra { get; set;}
        public float PrecioVenta { get; set; }
    }
}
