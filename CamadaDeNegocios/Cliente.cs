﻿using System.Text.RegularExpressions;

namespace CamadaDeNegocios
{
    public class Cliente
    {
        private string? nome;
        private string email;
        private long cpf;
        private bool evip = false;
        private double saldo = 0;
        private List<Extrato> extratos = new List<Extrato>();



        public static readonly string VERMELHO = "\u001B[31m";
        public static readonly string RESETCOR = "\u001B[0m";
        public static readonly string VERDE = "\u001B[32m";
        public static readonly string DOURADO = "\u001b[33m";
        public static readonly string AZUL = "\u001b[34m";
        public string Nome
        {
            get { return nome; }
            set
            {
                while (!ValidarNome(value))
                {
                    Console.WriteLine("Nome inválido, digite novamente");
                    value = Console.ReadLine();
                }
                nome = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                while (!ValidarEmail(value))
                {
                    Console.WriteLine("Email inválido, digite novamente");
                    value = Console.ReadLine();
                }
                email = value;
            }
        }

        public long CPF
        {
            get { return cpf; }
            set
            {
                while (!ValidarCPF(value))
                {
                    Console.WriteLine("CPF inválido, digite apenas os 11 números sem - ou .");
                    long.TryParse(Console.ReadLine(), out value);
                }
                cpf = value;
            }
        }

        public bool Evip { get; set; }

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public List<Extrato> Extratos
        {
            get { return extratos; }
            set { extratos = value; }
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

        public override string ToString()
        {
            if (Evip == true)
            {
                if (Saldo > 0)
                {
                    return $"Nome: {DOURADO}{Nome}   *VIP{RESETCOR}\nEmail: {Email}\nCPF: {CPF}\nSaldo: {VERDE}{Saldo}{RESETCOR}";
                }
                else
                {
                    return $"Nome: {DOURADO}{Nome}   *VIP{RESETCOR}\nEmail: {Email}\nCPF: {CPF}\nSaldo: {VERMELHO}{Saldo}{RESETCOR}";
                }
            }
            else
            {
                if (Saldo > 0)
                {
                    return $"Nome: {AZUL}{Nome}{RESETCOR}\nEmail: {Email}\nCPF: {CPF}\nSaldo: {VERDE}{Saldo}{RESETCOR}";
                }
                else
                {
                    return $"Nome: {AZUL}{Nome}{RESETCOR}\nEmail: {Email}\nCPF: {CPF}\nSaldo: {VERMELHO}{Saldo}{RESETCOR}";
                }
            }
        }
    }
}
    

