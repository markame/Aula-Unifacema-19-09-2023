using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Models.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace Models.Droid.Resources.DataBaseHelper
{
    public class DataBase
    {
            // Busaca da pasta atraves do método GetFolderPath
            string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //Metodo para criar o banco de dados 
            public bool CriarBancoDeDados()
            {
                // Criação do Banco e tratamento de erros
                try
                {

                    using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                    {
                        //Note que o Banco Pessoa.db é com base na classe Pessoa.
                        conexao.CreateTable<Pessoa>();
                        return true;
                    }
                } catch (Exception ex)
                {
                    // Conjunto de Mensagens para que possamos saber que nosso banco foi malsucedido
                    Log.Info("SQliteEX", ex.Message);
                    Toast.MakeText(Application.Context,"Mensagem"+ ex.Message,ToastLength.Long).Show();
                    return false;
                }
            }

        public bool InserirPessoa(Pessoa pessoa)
        {
            try
            {
                // encontramos nosso banco de dados e selecionamos o mesmo
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    /*Usamos o metodo INSERT para fazer a adição de mais um registro em nosso banco de dados
                    note que novamento essa opção só possivel pq anteriormente estruturamos o nosso banco
                    com base em nossa classe Pessoa.cs*/
                    conexao.Insert(pessoa);
                    return true;
                }
                
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQliteEX", ex.Message);
                return false;
            }
        }

        public List<Pessoa> GetPessoa()
        {
            // funçao para  listar todas as Pessoas no Banco de dados
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    return conexao.Table<Pessoa>().ToList();
                }

            }
            catch (Exception ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
           
        }
        public bool AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                // funçao para  atualizar por id as pessoas no banco de dados
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    conexao.Query<Pessoa>("UPDATE Pessoa set NomePessoa=?,IdadePessoa=?, EnderecoPessoa=? ," +
                        " DataNasc =?" +
                        " Where IdPessoa=?", pessoa.NomePessoa, pessoa.IdadePessoa, pessoa.EnderecoPessoa,
                        pessoa.DataNasc, pessoa.IdPessoa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}