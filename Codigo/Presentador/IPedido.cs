using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JugandoConWF_Pizzeria_04.Modelo;
using JugandoConWF_Pizzeria_04.Presentador;


namespace JugandoConWF_Pizzeria_04.Presentador {
   public interface IPedido {
  
        int mesaParaPersonas();
        int menoresEdad { get; }
        string comida { get; set; }
        string bebida { get; set; }
        bool cupon { get; }

        List<string> listaPedido(float valor);
    }
}
