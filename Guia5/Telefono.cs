using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia5
{
    public class Telefono
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precio { get; set; }
        public int  stock { get; set; }



      
        public void mostrarinformacion()
        {
        Console.WriteLine($"Marca:{marca},Modelo:{modelo},Precio:${precio},Stock:{stock}");
        }
    }
}
