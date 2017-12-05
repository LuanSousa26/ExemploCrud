using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCrud
{

    /*
     Para baixar as classes do SqlCliente deve-se colar o código abaixo no terminal : dotnet add package System.Data.SqlClient
    */

    public class BancoDados
    {

        //Variavel de conexão do SQL
        SqlConnection Conexao;
        //Variavel que recebe os comandos ex. SELECT * FROM
        SqlCommand comandos;
        //Variavel para a leitura da Tabela SQL
        SqlDataReader rd;



        /*
             Forma Orientada a Objetos
             */
        public bool Adicionar(Categorias cat)
        {

            /*
               O Adicionar está sendo realizado de forma otimizada com a classe CRUD(Utilizando o objeto c1) para facilitar
               e reusar o código, os demais métodos estão estruturados.
             */

            Crud c1 = new Crud();

            bool Insert = false;
            try
            {
                //Instância a variável conexão com uma nova conexão com  o banco de dados.
                //  Conexao = new SqlConnection();


                //Define o servidor(.\sqlExpress)servidor interno(SQL server managment) a DATABASE(Papelaria) usuário e senha.
                //Conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123;";


                //Abre a conexão com o banco de dados.
                // Conexao.Open();


                //Instância a Váriavel comandos como um novo comando SQL.
                //comandos = new SqlCommand();


                // Aponta que os comandos serão realizados em cima da conexão igualada, ou seja, a Conexao.
                //comandos.Connection = Conexao;


                //Define que o tipo de comando utilizado será Texto.
                c1.comandos.CommandType = CommandType.Text;

                // @Titulo(Serve como um parametro, um elemento parameterizado)
                //Define o comando de texto como um insert into e define que o campo titulo será parameterizado e receberá o valor de @Titulo.
                c1.comandos.CommandText = "INSERT INTO Categorias(titulo)VALUES(@Titulo)";



                //Irá adicionar ao parametro @Titulo o valor do cat.titulo.
                c1.comandos.Parameters.AddWithValue("@Titulo", cat.Titulo);

                /*
                Executa o INSERT sem uma QUERY e retorna o valor de linhas alteradas, por isso está sendo atribuído a váriavel r.
                 */

                int r = c1.comandos.ExecuteNonQuery();
                if (r > 0)
                    Insert = true;


                //Limpa o parametro @Titulo, pois se tentasse inserir um valor sem limpa-lo haveria um erro.
                c1.comandos.Parameters.Clear();


            }
            catch (SqlException Erro)
            {
                throw new EvaluateException("Erro ao tentar Cadastrar." + Erro.Message);
            }
            catch (Exception Error)
            {
                throw new Exception("Erro Inesperado. " + Error);
            }

            finally
            {
                //Fecha a conexão.
                c1.Conexao.Close();
            }

            return Insert;
        }







        /*
         Forma Estruturada
         */


        public bool Atualizar(Categorias cat)
        {


            bool uptade = false;
            try
            {
                //Instância a variável conexão com uma nova conexão com  o banco de dados.
                Conexao = new SqlConnection();

                //Define o servidor(.\sqlExpress)servidor interno(SQL server managment) a DATABASE(Papelaria) usuário e senha.
                Conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123;";

                //Abre a conexão com o banco de dados.
                Conexao.Open();

                //Instância a Váriavel comandos como um novo comando SQL.
                comandos = new SqlCommand();

                // Aponta que os comandos serão realizados em cima da conexão igualada, ou seja, a Conexao.
                comandos.Connection = Conexao;

                //Define que o tipo de comando utilizado será Texto.
                comandos.CommandType = CommandType.Text;

                // @Titulo(Serve como um parametro, um elemento parameterizado)
                //Define o comando de texto como um UPDATE e define que o campo titulo e Id será parameterizado e receberá o valor de @Titulo e @Id.
                comandos.CommandText = "UPDATE Categorias SET titulo=@Titulo WHERE idCategoria= @Id";



                //Irá adicionar ao parametro @Titulo o valor do cat.titulo.
                //Irá adicionar ao parametro @Id o valor do cat.IdCategoria.
                comandos.Parameters.AddWithValue("@Titulo", cat.Titulo);
                comandos.Parameters.AddWithValue("@Id", cat.IdCategoria);
                /*
                Executa o INSERT sem uma QUERY e retorna o valor de linhas alteradas, por isso está sendo atribuído a váriavel r.
                 */

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    uptade = true;


                //Limpa o parametro @Titulo, pois se tentasse inserir um valor sem limpa-lo haveria um erro.
                comandos.Parameters.Clear();


            }
            catch (SqlException Erro)
            {
                throw new EvaluateException("Erro ao tentar Cadastrar." + Erro.Message);
            }
            catch (Exception Error)
            {
                throw new Exception("Erro Inesperado. " + Error);
            }

            finally
            {
                //Fecha a conexão.
                Conexao.Close();
            }

            return uptade;
        }


        public bool Apagar(Categorias cat)
        {


            bool delete = false;
            try
            {
                //Instância a variável conexão com uma nova conexão com  o banco de dados.
                Conexao = new SqlConnection();

                //Define o servidor(.\sqlExpress)servidor interno(SQL server managment) a DATABASE(Papelaria) usuário e senha.
                Conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123;";

                //Abre a conexão com o banco de dados.
                Conexao.Open();

                //Instância a Váriavel comandos como um novo comando SQL.
                comandos = new SqlCommand();

                // Aponta que os comandos serão realizados em cima da conexão igualada, ou seja, a Conexao.
                comandos.Connection = Conexao;

                //Define que o tipo de comando utilizado será Texto.
                comandos.CommandType = CommandType.Text;

                // @Titulo(Serve como um parametro, um elemento parameterizado)
                //Define o comando de texto como um UPDATE e define que o campo titulo e Id será parameterizado e receberá o valor de @Titulo e @Id.
                comandos.CommandText = "DELETE FROM Categorias SET WHERE idCategoria= @Id";




                //Irá adicionar ao parametro @Id o valor do cat.IdCategoria.
                comandos.Parameters.AddWithValue("@Id", cat.IdCategoria);

                /*
                Executa o INSERT sem uma QUERY e retorna o valor de linhas alteradas, por isso está sendo atribuído a váriavel r.
                 */

                int r = comandos.ExecuteNonQuery();
                if (r > 0)
                    delete = true;


                //Limpa o parametro @Titulo, pois se tentasse inserir um valor sem limpa-lo haveria um erro.
                comandos.Parameters.Clear();


            }
            catch (SqlException Erro)
            {
                throw new EvaluateException("Erro ao tentar Cadastrar." + Erro.Message);
            }
            catch (Exception Error)
            {
                throw new Exception("Erro Inesperado. " + Error);
            }

            finally
            {
                //Fecha a conexão.
                Conexao.Close();
            }

            return delete;
        }


        public List<Categorias> ListarCategorias(int Id)
        {
            List<Categorias> lista = new List<Categorias>();


            try
            {
                Conexao = new SqlConnection();
                Conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123;";
                Conexao.Open();
                comandos.Connection = Conexao;


                comandos.CommandType = CommandType.Text;


                comandos.CommandText = "SELECT * FROM Categorias idCategoria= @Id";
                comandos.Parameters.AddWithValue("@Id", Id);

                //Reader
                rd = comandos.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new Categorias
                    {
                        //Pega a coluna 0 do banco (Id da tabela categorias no banco de dados)
                        IdCategoria = rd.GetInt32(0),
                        //Pega a coluna 1 do banco (Titulo da tabela categorias no banco de dados)
                        Titulo = rd.GetString(1)

                    });


                }


            }
            catch
            {

            }


            return lista;


        }

    }


}