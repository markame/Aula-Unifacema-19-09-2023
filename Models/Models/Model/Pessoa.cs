using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Models.Model
{
    public class Pessoa
    {
        int idPessoa;
        string nomePessoa;
        int idadePessoa;
        string enderecoPessoa;
        string dataNasc;

        [PrimaryKey, AutoIncrement]
        public int IdPessoa { get => idPessoa; set => idPessoa = value; }
        public string NomePessoa { get => nomePessoa; set => nomePessoa = value; }
        public int IdadePessoa { get => idadePessoa; set => idadePessoa = value; }
        public string EnderecoPessoa { get => enderecoPessoa; set => enderecoPessoa = value; }
        public string DataNasc { get => dataNasc; set => dataNasc=value; }
    }
}
