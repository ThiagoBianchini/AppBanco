using CamadaDeDados;
using CamadaDeNegocios;

namespace BancoUI
{

    class Program { 
    
        static void Main(string[] args)
        {
            List<Cliente> clientesLista = new List<Cliente>();
            List<Cliente> standartsLista = new List<Cliente>();
            List<Cliente> vipsLista = new List<Cliente>();
            bool continua = true;

            Metodos metodos = new Metodos();
            IRepositorio repositorio;

            Console.WriteLine("Deseja salvar os conteúdos em A - arquivo ou em L - lista (se salvo em lista, o conteúdo não será acessível depois do fechamento do programa) ?");
            char salva = Console.ReadKey().KeyChar;
            Console.WriteLine();
            while (true)
            {
                if (char.ToUpper(salva) != 'A' && char.ToUpper(salva) != 'L')
                {
                    Console.WriteLine("Escolha um método de salvamento válido");
                    salva = Console.ReadKey().KeyChar;
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }

            if (char.ToUpper(salva) == 'A')
            {
                repositorio = new FileRepo();
                Console.Clear();
            }

            while (continua)
            {
                Console.WriteLine($"\n" +
                    "   $$\\          $$$$$$$\\                                                 $$$$$$\\  $$\\                                  $$\\    \n" +
                    " $$$$$$\\        $$  __$$\\                                               $$  __$$\\ \\__|                               $$$$$$\\  \n" +
                    "$$  __$$\\       $$ |  $$ | $$$$$$\\  $$$$$$$\\   $$$$$$$\\  $$$$$$\\        $$ /  \\__|$$\\ $$$$$$\\$$$$\\   $$$$$$$\\       $$  __$$\\ \n" +
                    "$$ /  \\__|      $$$$$$$\\ | \\____$$\\ $$  __$$\\ $$  _____|$$  __$$\\       \\$$$$$$\\  $$ |$$  _$$  _$$\\ $$  _____|      $$ /  \\__|\n" +
                    "\\$$$$$$\\        $$  __$$\\  $$$$$$$ |$$ |  $$ |$$ /      $$ /  $$ |       \\____$$\\ $$ |$$ / $$ / $$ |\\$$$$$$\\        \\$$$$$$\\  \n" +
                    " \\___ $$\\       $$ |  $$ |$$  __$$ |$$ |  $$ |$$ |      $$ |  $$ |      $$\\   $$ |$$ |$$ | $$ | $$ | \\____$$\\        \\___ $$\\ \n" +
                    "$$\\  \\$$ |      $$$$$$$  |\\$$$$$$$ |$$ |  $$ |\\$$$$$$$\\ \\$$$$$$  |      \\$$$$$$  |$$ |$$ | $$ | $$ |$$$$$$$  |      $$\\  \\$$ |\n" +
                    "\\$$$$$$  |      \\_______/  \\_______|\\__|  \\__| \\_______| \\______/        \\______/ \\__|\\__| \\__| \\__|\\_______/       \\$$$$$$  |\n" +
                    " \\_$$  _/                                                                                                            \\_$$  _/ \n" +
                    "   \\ _/                                                                                                                \\ _/   \n" +
                    "                                                                                                                              ", Console.ForegroundColor = ConsoleColor.DarkYellow);
                Console.ResetColor();

                Console.WriteLine("||      BEM-VINDO(A)     ||");
                Console.WriteLine("===========================");
                Console.WriteLine("|| 1 - Cadastrar cliente ||");
                Console.WriteLine("|| 2 - Listar clientes   ||");
                Console.WriteLine("|| 3 - Operações         ||");
                Console.Write("|| ");
                Console.Write("4 - Sair              ", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
                Console.Write("||\n");

                char opcao = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.Clear();


                switch (opcao)
                {
                    case '1':
                        Console.WriteLine("CADASTRAR CLIENTE");
                            Cliente cliente = new Cliente();
                            metodos.Cadastrar(cliente);
                            clientesLista.Add(cliente);
                            if (cliente.Evip == true)
                            {
                                vipsLista.Add(cliente);
                            }
                            else
                            {
                                standartsLista.Add(cliente);
                            }
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        
                    case '2':
                        Console.WriteLine("Qual o tipo de conta deseja verificar?");
                        while (true)
                        {
                            Console.WriteLine("S - Standart / V - Vip");
                            Console.WriteLine("X - Voltar", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ResetColor();
                            char tipo = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            if (char.ToUpper(tipo) == 'S')
                            {
                                if (standartsLista.Count == 0)
                                {
                                    Console.WriteLine("Ainda não foram cadastrados clientes desse tipo", Console.ForegroundColor = ConsoleColor.Red);
                                    Console.ResetColor();
                                }

                                for (int i = 0; i < standartsLista.Count; i++)
                                {
                                    Cliente standart = standartsLista[i];
                                    Console.WriteLine(i + 1 + " - " + standart.Nome, Console.ForegroundColor = ConsoleColor.Blue);
                                    Console.ResetColor();
                                }
                            }
                            else if (char.ToUpper(tipo) == 'V')
                            {
                                if (vipsLista.Count == 0)
                                {
                                    Console.WriteLine("Ainda não foram cadastrados clientes desse tipo", Console.ForegroundColor = ConsoleColor.Red);
                                    Console.ResetColor();
                                }

                                for (int i = 0; i < vipsLista.Count; i++)
                                {
                                    Cliente vip = vipsLista[i];
                                    Console.WriteLine("* " + (i + 1) + " - " + vip.Nome, Console.ForegroundColor = ConsoleColor.DarkYellow);
                                    Console.ResetColor();
                                }
                            }
                            else if (char.ToUpper(tipo) == 'X')
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Escolha inválida, tente novamente", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ResetColor();
                            }
                        }
                        break;

                    case '3':
                        Console.WriteLine("Escolha a conta que deseja operar:");

                        if (clientesLista.Count == 0)
                        {
                            Console.WriteLine("Ainda não foram cadastrados clientes para que possam haver operações de conta", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ResetColor();
                        }

                        for (int i = 0; i < clientesLista.Count; i++)
                        {
                            Cliente itemCliente = clientesLista[i];
                            if (itemCliente.Evip == true)
                            {
                                Console.WriteLine("* " + (i + 1) + " - " + itemCliente.Nome, Console.ForegroundColor = ConsoleColor.DarkYellow);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine(i + 1 + " - " + itemCliente.Nome, Console.ForegroundColor = ConsoleColor.Blue);
                                Console.ResetColor();
                            }
                        }

                        int escolhaConta = int.Parse(Console.ReadLine()) - 1;
                        Cliente clienteMain = clientesLista[escolhaConta];

                        Console.WriteLine("OPERAÇÕES");
                        Console.WriteLine("1 - Depositar");
                        Console.WriteLine("2 - Sacar");
                        Console.WriteLine("3 - Pagar");
                        Console.WriteLine("4 - Transferir");
                        Console.WriteLine("5 - Alterar dados cadastrais");
                        Console.WriteLine("6 - Mostrar detalhes de conta");
                        Console.WriteLine("7 - Voltar");

                        char opcao2 = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        switch (opcao2)
                        {
                            case '1':
                                Console.WriteLine(metodos.Depositar(clienteMain));
                                Thread.Sleep(3000);
                                Console.Clear();
                                break;

                            case '2':
                                Console.WriteLine(metodos.Sacar(clienteMain));
                                Thread.Sleep(3000);
                                Console.Clear();
                                break;

                            case '3':
                                Console.WriteLine(metodos.Pagar(clienteMain));
                                Thread.Sleep(3000);
                                Console.Clear();
                                break;

                            case '4':
                                Console.WriteLine("Escolha uma conta para ser o favorecido: ");
                                List<Cliente> favorecidos = new List<Cliente>(clientesLista);
                                favorecidos.Remove(clienteMain);
                                if (favorecidos.Count == 0)
                                {
                                    Console.WriteLine("Ainda não foram cadastrados clientes o suficiente para realização de transferência.", Console.ForegroundColor = ConsoleColor.Red);
                                    Console.ResetColor();
                                    Thread.Sleep (2000);
                                    break;
                                }
                                for (int i = 0; i < favorecidos.Count; i++)
                                {
                                    var opCliente = favorecidos[i];

                                    if (opCliente.Evip == true) 
                                    {
                                        Console.WriteLine("* " + (i + 1) + " - " + opCliente.Nome, Console.ForegroundColor = ConsoleColor.DarkYellow);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine(i + 1 + " - " + opCliente.Nome, Console.ForegroundColor = ConsoleColor.Blue);
                                        Console.ResetColor();
                                    }
                                }

                                int escolhaFavor = int.Parse(Console.ReadLine()) - 1;
                                Cliente clienteFavor = favorecidos[escolhaFavor];

                                Console.WriteLine(metodos.Transferir(clienteMain, clienteFavor));
                                Thread.Sleep(3000);
                                Console.Clear();
                                break;

                            case '5':
                                Console.WriteLine("Qual dado deseja alterar?");
                                Console.WriteLine("1 - Nome");
                                Console.WriteLine("2 - Email");
                                Console.WriteLine("3 - CPF");

                                char dado = Console.ReadKey().KeyChar;
                                Console.WriteLine();

                                switch (dado)
                                {
                                    case '1':
                                        Console.WriteLine("Novo Nome:");
                                        clienteMain.Nome = Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    case '2':
                                        Console.WriteLine("Novo Email:");
                                        clienteMain.Email = Console.ReadLine();
                                        Console.Clear();
                                        break;

                                    case '3':
                                        Console.WriteLine("Novo CPF:");
                                        clienteMain.CPF = long.Parse(Console.ReadLine());
                                        Console.Clear();
                                        break;

                                    default:
                         
                                        Console.WriteLine("Escolha inválida, tente novamente.", Console.ForegroundColor = ConsoleColor.Red);
                                        Console.ResetColor();
                                        break;
                                }
                                break;

                            case '6':
                                Console.WriteLine();
                                Console.WriteLine(clienteMain);
                                Console.Write("Aperte ");
                                Console.Write("E", Console.ForegroundColor = ConsoleColor.Green);
                                Console.ResetColor();
                                Console.Write(" para mostrar o extrato.\n");
                                Console.WriteLine("Aperte X para voltar", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ResetColor();
                                while (true)
                                {
                                    char escolha = Console.ReadKey().KeyChar;
                                    if (char.ToUpper(escolha) == 'E')
                                    {
                                        foreach(Extrato extrato in clienteMain.Extratos) 
                                        {
                                            Console.WriteLine(extrato);
                                            Console.WriteLine("========================================");
                                        }
                                        
                                        Console.WriteLine("Aperte X para voltar", Console.ForegroundColor = ConsoleColor.Red);
                                        Console.ResetColor();
                                        if (char.ToUpper(escolha) == 'X')
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Escolha inválida, tente novamente.");
                                        }
                                    }
                                    else if (char.ToUpper(escolha) == 'X')
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Escolha inválida, tente novamente.");
                                    }
                                    
                                }
                                break;

                            case '7':
                                break;
                        }
                        break;

                    case '4':
                        Console.WriteLine("Obrigado por acessar nosso banco!");
                        Console.WriteLine("Tchau!!!");
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Escolha inválida, tente novamente", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
