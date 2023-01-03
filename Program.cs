using System; 
using projetobanco;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace projetobanco
{
    class Program 
    {   
        static void Menu() {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void SubMenu(){
            Console.WriteLine("1 - Sacar");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a opção desejada: ");
        }

        static void Main(string[] args) 
        { 
            Console.Clear();
            ContaFacade f = new ContaFacade();  

            int option = 7;

            do 
            {
                
              Menu();
              try
              {
                option = int.Parse(Console.ReadLine());
                if(option<0||option>6)
                {   Console.Clear();
                    Console.WriteLine("Opcão invalida");
                }
              }
              catch
              { Console.Clear();
                Console.WriteLine("Caracteres não são validos");
              }
              

              Console.WriteLine("-----------------");

                switch (option) {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:

                        Console.WriteLine("Digite o cpf do Usuário:");
                        int cpf = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o nome do Usuário:");
                        string titular = Console.ReadLine();

                        Console.WriteLine("Digite a senha do Usuário:");
                        string senha = Console.ReadLine();

                        Console.WriteLine("Digite o saldo do Usuário:");
                        double saldo = double.Parse(Console.ReadLine());

                        f.RegistrarNovoUsuario(cpf,titular,senha,saldo );
                        break;
                    case 2:
                        Console.WriteLine("Digite o cpf do usuário que vc quer deletar:");
                        int buscacpf = int.Parse(Console.ReadLine());
                        f.DeletarUsuario(buscacpf);
                        break;
                    case 3:
                        f.ListarTodasAsContas();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Digite o cpf do Usuário para mais detalhes:");
                        int buscacpf2 = int.Parse(Console.ReadLine());
                        f.DetalhesUsuario(buscacpf2);
                        break;
                    case 5:

                        f.TotalBanco();
                        break;
                    case 6:
                        int suboption = 100000;
                        do
                        {
                            SubMenu();

                            try
                            {
                                suboption = int.Parse(Console.ReadLine());
                                if(option<0||option>3)
                                {   Console.Clear();
                                    Console.WriteLine("Opcão invalida");
                                }
                            }
                            catch
                            { Console.Clear();
                                Console.WriteLine("Caracteres não são validos");
                            }

                            switch(suboption)
                            {
                                case 1:
                                Console.WriteLine("Digite a quantia que deseja sacar:");
                                double saque = double.Parse(Console.ReadLine());
                                Console.WriteLine("Informe o cpf:");
                                int cpfsaque = int.Parse(Console.ReadLine());
                                Console.WriteLine("Informe a senha:");
                                string senhasaque = Console.ReadLine();
                                break;
                                
                                case 2:
                                Console.WriteLine("Digite a quantia que deseja depositar:");
                                double deposito = double.Parse(Console.ReadLine());
                                Console.WriteLine("Informe o cpf:");
                                int cpfdeposito = int.Parse(Console.ReadLine());
                                break;

                                case 3:
                                Console.WriteLine("Digite a quantia que deseja transferir:");
                                double transferir = double.Parse(Console.ReadLine());
                                Console.WriteLine("Informe o cpf origem:");
                                int cpforigem = int.Parse(Console.ReadLine());
                                Console.WriteLine("Informe a senha:");
                                string senhatransferir = Console.ReadLine();
                                Console.WriteLine("Informe o cpf destino:");
                                int cpfdestino = int.Parse(Console.ReadLine());
                                break;
                            }

                        }while(suboption!=0);
                        break;
                }

              Console.WriteLine("-----------------");

            } while (option != 0);

        }
    }
}
