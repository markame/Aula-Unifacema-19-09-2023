using Models.DataBaseHelper;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        DataBase db;

        public PessoaView()
        {
            InitializeComponent();
            CarregarDados();



        }
        private void CarregarDados()
        {

            lvDados.ItemsSource = db.GetPessoa();
        }
    }
}