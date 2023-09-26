using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCep
{
    using Correios.Net;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LocalizarCEP()
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                Address endereco = SearchZip.GetAddress(txtCEP.Text);
                if (endereco.Zip != null)
                {
                    txtEstado.Text = endereco.State;
                    txtCidade.Text = endereco.City;
                    txtBairro.Text = endereco.District;
                    txtEndereco.Text = endereco.Street;
                }
                else
                {
                    MessageBox.Show("Cep não localizado...");
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }
        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
