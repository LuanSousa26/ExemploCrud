using System;
using System.Collections.Generic;
using System.Threading;

namespace ExemploCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            bool controla2 = false;
            bool Controle = false;
            List<Categorias> lista = new List<Categorias>();



            BancoDados B1 = new BancoDados();

            Categorias c1 = new Categorias();
            


            /*

            */

            // lista=B1.ListarCategorias();
            // foreach(Categorias a in lista)
            // System.Console.WriteLine(a.Titulo);




            // c1.Titulo="Nega da praia";
            // B1.Adicionar(c1);


            //  B1.Atualizar(c1);



            while (Controle == false)
            {

                System.Console.WriteLine("_____________________________\nLOJA\n_____________________________");
                System.Console.WriteLine("\n Favor Escolha umas das opções:\n * 1 - Categorias * \n * 2 - Clientes * \n 3 - Estoque");
                String opcao = Console.ReadLine();


                switch (opcao)
                {
                    // Crud da tabela de categorias   
                    case "1":
                        opcao = "";

                        while (controla2 == false)
                        {
                            System.Console.WriteLine("\n Escolha a operação a ser Realizada:\n * 1- Cadastro de nova Categoria *\n * 2 - Atualização *\n * 3 - Apagar Categoria *\n * 4- Procurar Categoria por ID ou Titulo * \n * 5 - Pesquisar toda a tabela Categoria * \n ");
                            opcao = Console.ReadLine();
                            switch (opcao)
                            {

                                /*
                                 
                                 Cadastro de dados no banco
                                 B1 é um objeto da classe BancoDados e o método adicionar contem o INSERT INTO 
                                 B1.Adicionar(c1);

                                 */
                                case "1":

                                    c1.Titulo = "";
                                    do
                                    {
                                        System.Console.WriteLine("Favor digite o titulo da da categoria(Não pode ser vázio):");
                                        c1.Titulo = Console.ReadLine();
                                    } while (c1.Titulo == "");

                                    //chama o método Adicionar e passa como parametro o id null(no banco é auto increment ) e o titulo inserido pelo usuário.
                                    B1.Adicionar(c1);

                                    controla2 = true;
                                    break;

                                case "2":
                                    //Faz o SELECT * FROM da tabela
                                    View();
                                    //Enquando o controla2 for igual a falso fica pedindo o ID denovo.
                                    while (controla2 == false)
                                    {

                                        try
                                        {
                                            System.Console.WriteLine("\n Escolha o Id a Ser alterado");
                                            c1.IdCategoria = Int32.Parse(Console.ReadLine());
                                            controla2 = true;
                                        }
                                        catch
                                        {
                                            System.Console.WriteLine("\n O id deve ser numérico e não deve ser nulo!");
                                        }


                                        c1.Titulo = "";
                                        do
                                        {
                                            System.Console.WriteLine("Favor Digite o novo Titulo para o id " + c1.IdCategoria + ":\n");
                                            c1.Titulo = Console.ReadLine();
                                        } while (c1.Titulo == "");
                                       
                                       B1.Atualizar(c1);
                                    }

                                    break;

                                    case "3":
                                    View();

                                    while (controla2 == false)
                                    {

                                        try
                                        {
                                            System.Console.WriteLine("\n Escolha o Id a Ser Apagado");
                                            c1.IdCategoria = Int32.Parse(Console.ReadLine());
                                            controla2 = true;
                                        }
                                        catch
                                        {
                                            System.Console.WriteLine("\n O id deve ser numérico e não deve ser nulo!");
                                        }
                                         B1.Apagar(c1);

                                    }
                                    break;

                                    case "4":
                                     int Id;
                                     string text="";
                                     
                                     
                                     do
                                        {
                                            
                                            System.Console.WriteLine("Favor Digite o ID ou Titulo da categoria que deseja pesquisar :\n");
                                            text = Console.ReadLine();
                                        } while (text == "");
                                        try
                                        {
                                          Id=Int32.Parse(text);
                                          lista=B1.ListarCategorias(Id);
                                          
                                          foreach(Categorias c in lista)
                                              System.Console.WriteLine("Id: "+c.IdCategoria + " Título: "+c.Titulo);
                                        }
                                        catch
                                        {
                                             lista=B1.ListarCategorias(text);
                                             foreach(Categorias c in lista)
                                              System.Console.WriteLine("Id: "+c.IdCategoria + " Título: "+c.Titulo);
                                        }
                                       

                                    controla2=true;
                                    break;

                            }
                        }
                        Controle = true;
                        break;
                       





                    case "2":




                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                }
            }






        }
        public static void View()
        {
            //Cria uma lista do tipo Categorias
            List<Categorias> lista = new List<Categorias>();
            //Instância 
            BancoDados B1 = new BancoDados();
            lista = B1.ListarCategorias();
            foreach (Categorias a in lista)
                System.Console.WriteLine("Id: " + a.IdCategoria + "  Título:  " + a.Titulo);

        }
    }
}
