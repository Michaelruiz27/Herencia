using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia5
{
    public class TelefonoInteligente : Telefono
    {
        public string sistemaoperativo {  get; set; }
        public int memoriaram {  get; set; }



        public void MostrarInformacionInteligente()
        {



            base.mostrarinformacion();
            Console.WriteLine($"Sistema OPerativo:{sistemaoperativo},Memoria Ram:{memoriaram}GB");

        }
    }
}
