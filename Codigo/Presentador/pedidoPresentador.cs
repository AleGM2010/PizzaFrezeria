using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugandoConWF_Pizzeria_04.Presentador {
    public class pedidoPresentador {
        IPedido pedidoView;

        public pedidoPresentador(IPedido view) {
            pedidoView = view;          
        }

        public bool verificarDatos() {
            int valor = pedidoView.menoresEdad;
            return valor >= 0 && valor < 5 && valor <= pedidoView.mesaParaPersonas() ? true : false;
        }

        public float calcularPedido() {
            Modelo.Pedido pedido = new Modelo.Pedido(pedidoView.comida,pedidoView.bebida);
            return pedido.calcularPedido(pedidoView.mesaParaPersonas(),
                pedidoView.menoresEdad,pedidoView.cupon);
        }


        

    }
}
