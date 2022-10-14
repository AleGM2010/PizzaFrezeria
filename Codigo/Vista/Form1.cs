using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JugandoConWF_Pizzeria_04.Presentador;

namespace JugandoConWF_Pizzeria_04 {
    public partial class Form1 : Form , IPedido {

        public Form1() {
            InitializeComponent();
            
        }
        Form2Grid form2Grid = new Form2Grid();

        // Metodos y variables de la interfaz IPedido

        public List<string> listaPedido(float valor) {
            List<string> listaDePedidos = new List<string> { };
            listaDePedidos.Add(mesaParaPersonas().ToString());
            listaDePedidos.Add(menoresEdad.ToString());
            if (cupon){
                listaDePedidos.Add("Si");
            } else {
                listaDePedidos.Add("No");
            }          
            if (comida == "Comidas") {
                listaDePedidos.Add("Nada");
            } else {
                listaDePedidos.Add(comida);
            }
            if (bebida == "Bebidas") {
                listaDePedidos.Add("Nada");
            } else {
                listaDePedidos.Add(bebida);
            }          
            listaDePedidos.Add(valor.ToString());
            return listaDePedidos;
        }
        

        public int mesaParaPersonas() {           
           return rbt1Persona.Checked ? 1:rbt2Persona.Checked? 2: rbt3Persona.Checked ? 3:4 ;
        }              

        public int menoresEdad {
            get {
                int valor = int.Parse(txbCantMenEdad.Text);                                
                return valor;
            }
        }
        public bool cupon { get => checkBox1.Checked;  }
        public string comida { get => btnComida.Text; set => btnComida.Text = value; }
        public string bebida { get => btnBebida.Text; set => btnBebida.Text = value; }    


        // Metodos o eventos de WindowsForm1
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            rbt1Persona.Enabled = !rbt1Persona.Enabled;
        }
        private void button1_Click(object sender, EventArgs e) {
            pnlComida.Visible = !pnlComida.Visible;
        }
        private void button2_Click(object sender, EventArgs e) {
            btnComida.Text = btnPizza.Text;
            pnlComida.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e) {
            btnComida.Text = btnHamburguesa.Text;
            pnlComida.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e) {
            btnComida.Text = btnPapasFritas.Text;
            pnlComida.Visible = false;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) {

        }
        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
        private void Form1_Load(object sender, EventArgs e) {

        }       
        private void button7_Click(object sender, EventArgs e) {
            pnlBebidas.Visible = !pnlBebidas.Visible;
        }

        private void button6_Click(object sender, EventArgs e) {
            btnBebida.Text = btnAgua.Text;
            pnlBebidas.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e) {
            btnBebida.Text = btnCocaCola.Text;
            pnlBebidas.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e) {
            btnBebida.Text = btnSprite.Text;
            pnlBebidas.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e) {

        }
        private void button7_Click_1(object sender, EventArgs e) {
            btnComida.Text = btnNadaC.Text;
            pnlComida.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e) {
            btnBebida.Text = btnNadaB.Text;
            pnlBebidas.Visible = false;
        }

        // Boton cupon
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e) {

        }

        // Boton calcular Total a pagar
        private void btnCalcularTotal_Click(object sender, EventArgs e) {

            try {
            pedidoPresentador presentador = new pedidoPresentador(this);
                if (presentador.verificarDatos()) {
                    btnTotal.Text = Math.Round(presentador.calcularPedido(),2).ToString();
                    try {
                        form2Grid.llenarTablaPedidos(listaPedido(float.Parse(btnTotal.Text)));

                    } catch {
                        // Si se cerro, dara problemas, pero el programa seguira funcionando, solo 
                        // no se vera la Tabla y no podra abrirse
                    }

                } else {
                    MessageBox.Show("No hay mas menores que personas\n o numero incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                            
            } catch {
                MessageBox.Show("Menores de edad debe \nser numerico","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void pedidosRealizadosToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                form2Grid.Show();
            } catch {
                MessageBox.Show("Si cerro la ventana de pedidos\n Debe reiniciar el programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void gananciaDiariaToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("La ganancia diaria es de: " + form2Grid.gananciaTotal(),"Ganancias");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }
    }
}
