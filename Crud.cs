using System.Data.SqlClient;

namespace ExemploCrud
{
    public class Crud
    {
         //Variavel de conexão do SQL
     public SqlConnection Conexao;
        //Variavel que recebe os comandos ex. SELECT * FROM
     public SqlCommand comandos;
        //Variavel para a leitura da Tabela SQL
     public  SqlDataReader rd;

            public Crud()
            {    

                //Instância a variável conexão com uma nova conexão com  o banco de dados.
                this.Conexao = new SqlConnection();

                 //Define o servidor(.\sqlExpress)servidor interno(SQL server managment) a DATABASE(Papelaria) usuário e senha.
                this.Conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123;";
                
                //Abre a conexão com o banco de dados.
                this.Conexao.Open();
                 //Instância a Váriavel comandos como um novo comando SQL.
                this.comandos = new SqlCommand();
                
                // Aponta que os comandos serão realizados em cima da conexão igualada, ou seja, a Conexao.
                this.comandos.Connection = Conexao;
            }
    }
}