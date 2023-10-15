
using Models.Model;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Models.DataBaseHelper
{
    public class DataBase
    {
            // Busaca da pasta atraves do método GetFolderPath
            string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //Metodo para criar o banco de dados 
            public   bool CriarBancoDeDados()
            {
                // Criação do Banco e tratamento de erros
                try
                {
                if (System.IO.Path.Combine(pasta, "Pessoa.db").Contains("Pessoa.db")!=true)
                {


                    using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                    {
                        //Note que o Banco Pessoa.db é com base na classe Pessoa.
                        conexao.CreateTable<Pessoa>();
                        return true;
                    }
                 }
               
                return false;
            } catch (Exception ex)
                {
                    // Conjunto de Mensagens para que possamos saber que nosso banco foi malsucedido
                 
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
             
                return false;
            }
        }

        public ObservableCollection<Pessoa> GetPessoa()
        {
            // funçao para  listar todas as Pessoas no Banco de dados
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    List<Pessoa> listaModel = conexao.Table<Pessoa>().ToList();
                   ObservableCollection<Pessoa> ObsModel = new ObservableCollection<Pessoa>(listaModel);
                    return ObsModel;




                }

            }
            catch (Exception ex)
            {
               
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
              
                return false;
            }
        }
        public bool DeletarPessoa(Pessoa pessoa)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    conexao.Delete(pessoa);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
            
                return false;
            }
        }

        public bool GetPessoabyId(int Id)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Pessoa.db")))
                {
                    conexao.Query<Pessoa>("SELECT * FROM Pessoa Where Id=?", Id);
                 
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
               
                return false;
            }
        }
    }
}