using Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Models.View;
using System.Data;
using Xamarin.Forms.PlatformConfiguration;
using Models.DataBaseHelper;

namespace Models
{
    public partial class MainPage : ContentPage
    {
        DataBase bd = new DataBase();
        public MainPage()
        {
            InitializeComponent();
           
           
            if (bd.CriarBancoDeDados() == true)
            {
                DisplayAlert("Mensagem do Banco", "Acabei de nascer Obrigado", "Deu foi Certo");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Pessoa pessoa = new Pessoa
            {
                NomePessoa =  nome.Text,
                IdadePessoa = Convert.ToInt32( idade.Text),
                EnderecoPessoa=  nome.Text,
                DataNasc=  nome.Text
            };



            bd.InserirPessoa(pessoa);

            DisplayAlert("Registro","Registro gravado com sucesso","Concluido");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _=Navigation.PushModalAsync(new PessoaView());
        }
    }
}
