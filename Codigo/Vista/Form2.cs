using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JugandoConWF_Pizzeria_04 {
    public partial class Form2Grid : Form {
        
        public Form2Grid() {
            InitializeComponent();
        }     
        private void Form2Grid_Load(object sender, EventArgs e) {
        }
        public void llenarTablaPedidos(List<string> listaPedidos) {
            int celda = dgvTablaPedidos.Rows.Add();
            for (int i = 0; i < listaPedidos.Count; i++) {
                dgvTablaPedidos.Rows[celda].Cells[i].Value = listaPedidos[i];
            }         
        }
        public float gananciaTotal() {
            float valor = 0;
            for (int i=0;i< dgvTablaPedidos.Rows.Count ; i++) {
                valor += float.Parse(dgvTablaPedidos.Rows[i].Cells[gridGanancia.Index].Value.ToString());
            }
            return valor;
        }
    }
}
