using CamadaDeNegocios;

namespace CamadaDeDados
{
    public class Metodos : Cliente
    {
        public static readonly string VERMELHO = "\u001B[31m";
        public static readonly string RESETCOR = "\u001B[0m";
        public static readonly string VERDE = "\u001B[32m";
        public static readonly string DOURADO = "\u001b[33m";
        public static readonly string AZUL = "\033[0;34m";

        public void Cadastrar(Cliente cliente)
        {
            Console.WriteLine("Digite os dados:");
            Console.WriteLine("Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            cliente.Email = Console.ReadLine();
            Console.WriteLine("CPF (sem - ou .): ");
            cliente.CPF = long.Parse(Console.ReadLine());
            Console.WriteLine("A conta é vip? S - Sim / N - Não");
            char escolha;
            while (!char.TryParse(Console.ReadLine(), out escolha) || (char.ToUpper(escolha) != 'S' && char.ToUpper(escolha) != 'N'))
            {
                Console.WriteLine($"Escolha inválida, tente novamente", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }

            if (char.ToUpper(escolha) == 'S')
            {
                cliente.Evip = true;
            }
            Console.WriteLine("Deseja adicionar saldo à conta? S - Sim / N - Não");
            char escolha2;
            while (!char.TryParse(Console.ReadLine(), out escolha2) || (char.ToUpper(escolha2) != 'S' && char.ToUpper(escolha2) != 'N'))
            {
                Console.WriteLine($"Escolha inválida, tente novamente", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }

            if (char.ToUpper(escolha2) == 'S')
            {
                Console.WriteLine(Depositar(cliente));
            }
        }


        public string Depositar(Cliente cliente)
        {
            Console.WriteLine("Digite o valor que deseja depositar: ");
            double deposito;
            while (!double.TryParse(Console.ReadLine(), out deposito) || deposito <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de depósito, por favor, digite o valor novamente.");
            }
            cliente.Saldo += deposito;
            cliente.Extratos.Add(new Extrato(DateTime.Now, deposito, $"Depósito de {deposito}$", "Depósito"));
            if (cliente.Saldo > 0)
            {
                return $"Foram depositados {VERDE}{deposito}${RESETCOR} na conta de {cliente.Nome}\nSaldo total: {VERDE}{cliente.Saldo}${RESETCOR}";
            }
            else
            {
                return $"Foram depositados {VERDE}{deposito}${RESETCOR} na conta de {cliente.Nome}\nSaldo total: {VERMELHO}{cliente.Saldo}${RESETCOR}";
            }
        }

        public string Sacar(Cliente cliente)
        {
            Console.WriteLine("Digite o valor que deseja sacar: ");
            double saque = double.Parse(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out saque) || saque <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de saque, por favor, digite o valor novamente.");
            }

            if (saque > cliente.Saldo)
            {
                return "O valor a ser sacado é maior que o possuído na conta, portanto não é possível sacar essa quantia";
            }
            else
            {
                cliente.Saldo -= saque;
                cliente.Extratos.Add(new Extrato(DateTime.Now, saque, $"Saque de {saque}$", "Saque"));
                return $"Foram sacados {VERMELHO}{saque}{RESETCOR} Simoleons na conta de {cliente.Nome}.\nResta agora {VERDE}{cliente.Saldo}${RESETCOR} na conta de {cliente.Nome}.";
            }
        }

        public string Pagar(Cliente cliente)
        {
            Console.WriteLine("Digite o valor do pagamento: ");
            double pagamento = double.Parse(Console.ReadLine());
            Console.WriteLine("Dê uma descrição para o pagamento.");
            string descricao = Console.ReadLine();
            while (!double.TryParse(Console.ReadLine(), out pagamento) || pagamento <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de saque, por favor, digite o valor novamente.");
            }

            cliente.Saldo -= pagamento;
            cliente.Extratos.Add(new Extrato(DateTime.Now, pagamento, descricao, "Pagamento"));
            if (pagamento > cliente.Saldo)
            {
                return $"O pagamento de {VERMELHO}{pagamento}{RESETCOR} pela conta de {cliente.Nome} foi efetuado. Dívida de {VERMELHO}{cliente.Saldo}${RESETCOR}";
            }
            else
            {
                return $"O pagamento de {VERMELHO}{pagamento}{RESETCOR} pela conta de {cliente.Nome} foi efetuado. Saldo restante: {VERDE}{cliente.Saldo}${RESETCOR}";
            }
        }

        public string Transferir(Cliente beneficiario, Cliente favorecido)
        {

            Console.WriteLine("Digite o valor da transferência: ");
            double transferencia;
            while (!double.TryParse(Console.ReadLine(), out transferencia) || transferencia <= 0)
            {
                Console.WriteLine("Valor não suportado para transferência, por favor, digite o valor novamente.");
            }

            beneficiario.Saldo -= transferencia;
            favorecido.Saldo += transferencia;
            beneficiario.Extratos.Add(new Extrato(DateTime.Now, -transferencia, $"Tranferência feita para {favorecido.Nome}", "Transferência"));
            favorecido.Extratos.Add(new Extrato(DateTime.Now, transferencia, $"Transferência recebida de {beneficiario.Nome}", "Transferência"));
            return $"Transferência de {beneficiario.Nome} para {favorecido.Nome} no valor de {VERDE}{transferencia}${RESETCOR} feita com sucesso.";
        }

     

        }
    }
}