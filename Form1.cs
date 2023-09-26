using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Forms;
//using Correios.Net;

namespace ApiCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private async void LocalizarCEP()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCEP.Text))
                {
                    // Formate o CEP para remover caracteres não numéricos
                    string cep = txtCEP.Text.Replace("-", "").Replace(".", "");

                    // URL da API de consulta de CEP
                    string apiUrl = $"https://viacep.com.br/ws/{cep}/json/";

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            dynamic responseData = JsonConvert.DeserializeObject(json);

                            if (responseData.cep != null)
                            {
                                txtEstado.Text = responseData.uf;
                                txtCidade.Text = responseData.localidade;
                                txtBairro.Text = responseData.bairro;
                                txtEndereco.Text = responseData.logradouro;
                            }
                            else
                            {
                                MessageBox.Show("CEP não encontrado...");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erro ao consultar o CEP. Verifique sua conexão com a internet.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Informe um CEP válido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void LocalizarCEP()
        //{
        //    if (!string.IsNullOrWhiteSpace(txtCEP.Text))
        //    {
        //        Address endereco = SearchZip.GetAddress(txtCEP.Text);
        //        if (endereco.Zip != null)
        //        {
        //            txtEstado.Text = endereco.State;
        //            txtCidade.Text = endereco.City;
        //            txtBairro.Text = endereco.District;
        //            txtEndereco.Text = endereco.Street;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cep não localizado...");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Informe um CEP válido");
        //    }
        //}

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
