using Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Models.View;

namespace Models
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Pessoa pessoa =  new Pessoa();
            pessoa.IdPessoa = Convert.ToInt32(id.Text);
            pessoa.NomePessoa = nome.Text;
            pessoa.IdadePessoa = Convert.ToInt32(idade.Text);
            pessoa.EnderecoPessoa = endere.Text;
            pessoa.DataNasc = data.Date.ToShortDateString();
            _=Navigation.PushModalAsync(new PessoaView(pessoa));

        }
    }
}
