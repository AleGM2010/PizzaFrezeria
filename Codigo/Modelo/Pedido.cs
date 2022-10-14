using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugandoConWF_Pizzeria_04.Modelo {
     class Pedido {
        int precio = 0;

        public Pedido(string comida,string bebida) {
            switch (comida) 
                {
                case "Papas fritas": this.precio += 700; break;
                case "Pizza": this.precio += 800; break;
                case "Hamburguesa": this.precio += 900; break;
                default: this.precio += 0; break;
            }
            switch (bebida) {
                case "Agua": this.precio += 200; break;
                case "Sprite": this.precio += 300; break;
                case "Coca-Cola": this.precio += 400; break;
                default: this.precio += 0; break;
            }

        }

        // pedido recibe valores de cant menores edad, mesas y comida y calcula costos
        public float calcularPedido(int cantMesas, int cantMenores,bool cupon) {
            int valorMesa = cantMesas == 1 ? 600 : cantMesas == 2 ? 800: cantMesas == 3 ? 900:1000;          
            float total = ((valorMesa + this.precio) * (100 - cantMenores * 3)) / 100;
            return cupon ? (total*85)/100:total;
           

        }
    }
}
