using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace trabalho_pratrico_MVC.Models
{
    public class RegistarModel
    {
        [Required(ErrorMessage = "Campo nome tem de ser preenchido")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo email tem de ser preenchido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo morada tem de ser preenchido")]
        public string morada { get; set; }

        [Required(ErrorMessage = "Campo código postal tem de ser preenchido")]
        public string cp { get; set; }
         
        [Required(ErrorMessage = "Campo data de nascimento tem de ser preenchido")]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }

        [Display(Name = "Palavra passe")]
        [Required(ErrorMessage = "Campo password tem de ser preenchido")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Palavras passe não são iguais")]
        public string confirmaPassword { get; set; }
    }

    //class de acesso aos dados

    public class RegistarBD
    {
        string strLigacao;
        SqlConnection ligacaoBD;

        public RegistarBD()
        {
            strLigacao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            try
            {
                ligacaoBD = new SqlConnection(strLigacao);
                ligacaoBD.Open();
            }
            catch (Exception erro)
            {
                Debug.Write(erro.Message);
            }
        }

        ~RegistarBD()
        {
            try
            {
                ligacaoBD.Close();
            }
            catch (Exception erro)
            {
                Debug.Write(erro.Message);
            }
        }

        public void adicionarUtilizador(RegistarModel novo)
        {
            string sql = "INSERT INTO Clientes(nome,email,morada,cp,data_nascimento,password) VALUES (@nome,@email,@morada,@cp,@data,HASHBYTES('SHA1',@password))";
            SqlCommand comando = new SqlCommand(sql, ligacaoBD);
            comando.Parameters.AddWithValue("@nome", (string)novo.nome);
            comando.Parameters.AddWithValue("@email", (string)novo.email);
            comando.Parameters.AddWithValue("@morada", (string)novo.morada);
            comando.Parameters.AddWithValue("@cp", (string)novo.cp);
            comando.Parameters.AddWithValue("@data", (DateTime)novo.data);
            comando.Parameters.AddWithValue("@pass", (string)novo.password);
            comando.ExecuteNonQuery();
            comando.Dispose();
            return;
        }
    }
}