using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Models.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PessoaView : ContentPage
    {
        public PessoaView(Pessoa pessoa)
        {
            InitializeComponent();
            id.Text = pessoa.IdPessoa.ToString();
            nome.Text = pessoa.NomePessoa.ToString();
            idade.Text = pessoa.IdadePessoa.ToString();
            endere.Text = pessoa.EnderecoPessoa.ToString();
            data.Date = DateTime.ParseExact(pessoa.DataNasc,
                "dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}