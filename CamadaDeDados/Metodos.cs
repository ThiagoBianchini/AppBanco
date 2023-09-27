using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class Metodos : IRepositorio
    {
        public static readonly string VERMELHO = "\u001B[31m";
        public static readonly string RESETCOR = "\u001B[0m";
        public static readonly string VERDE = "\u001B[32m";

        public Cliente Cadastrar()
        {
            Console.WriteLine("Digite os dados:");
            Console.WriteLine("Nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Email: ");
            Email = Console.ReadLine();
            Console.WriteLine("CPF (sem - ou .): ");
            CPF = long.Parse(Console.ReadLine());
            Console.WriteLine("Deseja adicionar saldo à conta? S - Sim / N - Não");
            char escolha;
            while (!char.TryParse(Console.ReadLine(), out escolha) || (char.ToUpper(escolha) != 'S' && char.ToUpper(escolha) != 'N'))
            {
                Console.WriteLine($"Escolha inválida, tente novamente", Console.ForegroundColor = ConsoleColor.Red);
                Console.ResetColor();
            }

            if (char.ToUpper(escolha) == 'S')
            {
                Console.WriteLine(Depositar());
            }

            return new Cliente();
        }

        public string Depositar()
        {
            Console.WriteLine("Digite o valor que deseja depositar: ");
            double deposito;
            while (!double.TryParse(Console.ReadLine(), out deposito) || deposito <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de depósito, por favor, digite o valor novamente.");
            }
            saldo += deposito;
            extratos.Add(new Extrato(DateTime.Now, deposito, $"Depósito de {deposito}$", "Depósito"));
            if (saldo > 0)
            {
                return $"Foram depositados {VERDE}{deposito}{RESETCOR} Bits na conta de {nome}\nSaldo total: {VERDE}{saldo}${RESETCOR}";
            }
            else
            {
                return $"Foram depositados {VERDE}{deposito}{RESETCOR} Bits na conta de {nome}\nSaldo total: {VERMELHO}{saldo}${RESETCOR}";
            }
        }

        public string Sacar()
        {
            Console.WriteLine("Digite o valor que deseja sacar: ");
            double saque = double.Parse(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out saque) || saque <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de saque, por favor, digite o valor novamente.");
            }

            if (saque > saldo)
            {
                return "O valor a ser sacado é maior que o possuído na conta, portanto não é possível sacar essa quantia";
            }
            else
            {
                saldo -= saque;
                extratos.Add(new Extrato(DateTime.Now, saque, $"Saque de {saque}$", "Saque"));
                return $"Foram sacados {VERMELHO}{saque}{RESETCOR} Simoleons na conta de {nome}.\nResta agora {VERDE}{saldo}${RESETCOR} na conta de {nome}.";
            }
        }

        public string Pagar()
        {
            Console.WriteLine("Digite o valor do pagamento: ");
            double pagamento = double.Parse(Console.ReadLine());
            Console.WriteLine("Dê uma descrição para o pagamento.");
            string descricao = Console.ReadLine();
            while (!double.TryParse(Console.ReadLine(), out pagamento) || pagamento <= 0)
            {
                Console.WriteLine("Valor não suportado para a operação de saque, por favor, digite o valor novamente.");
            }

            saldo -= pagamento;
            extratos.Add(new Extrato(DateTime.Now, pagamento, descricao, "Pagamento"));
            if (pagamento > saldo)
            {
                return $"O pagamento de {VERMELHO}{pagamento}{RESETCOR} pela conta de {nome} foi efetuado. Dívida de {VERMELHO}{saldo}${RESETCOR}";
            }
            else
            {
                return $"O pagamento de {VERMELHO}{pagamento}{RESETCOR} pela conta de {nome} foi efetuado. Saldo restante: {VERDE}{saldo}${RESETCOR}";
            }
        }

        public string Transferir(Cliente beneficiario, Cliente favorecido)
        {
            Console.WriteLine("Digite o valor da transferência: ");
            double transferencia = double.Parse(Console.ReadLine());
            while (!double.TryParse(Console.ReadLine(), out transferencia) || transferencia <= 0)
            {
                Console.WriteLine("Valor não suportado para transferência, por favor, digite o valor novamente.");
            }

            beneficiario.saldo -= transferencia;
            favorecido.saldo += transferencia;
            beneficiario.extratos.Add(new Extrato(DateTime.Now, -transferencia, $"Tranferência feita para {favorecido.nome}", "Transferência"));
            favorecido.extratos.Add(new Extrato(DateTime.Now, transferencia, $"Transferência recebida de {beneficiario.nome}", "Transferência"));

            return $"Transferência de {beneficiario.nome} para {favorecido.nome} no valor de {transferencia} feita com sucesso.";
        }

        public bool ValidarNome(string novoNome)
        {
            string nomeRgx = "[a-zA-Z]+";
            return Regex.IsMatch(novoNome, nomeRgx);
        }

        public bool ValidarEmail(string email)
        {
            string emailRgx = "^(?=.{1,64}@)[A-Za-z0-9_-]+(\\.[A-Za-z0-9_-]+)*@" + "[^-][A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,})$";
            return Regex.IsMatch(email, emailRgx);
        }

        public bool ValidarCPF(long cpf)
        {
            string cpfRgx = "^\\d{11}$";
            string cpfStr = cpf.ToString();
            return Regex.IsMatch(cpfStr, cpfRgx);
        }
    }
}
    }
}
