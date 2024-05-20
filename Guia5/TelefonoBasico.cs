using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia5
{
    public class TelefonoBasico : Telefono
    {
        public bool TieneRadioFM { get; set; }
        public bool TieneLinterna { get; set; }


        public void MostrarInformacionBasica()
        {
            base.mostrarinformacion();
            Console.WriteLine($"Tiene Radio FM:{TieneRadioFM},Tiene LInterna:{TieneLinterna}");
        }
    }
}
