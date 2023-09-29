namespace CamadaDeNegocios
{
    public class Extrato : Cliente
    {
        private DateTime horario;
        private double valor;
        private string descricao;
        private string tipo;

        public Extrato(DateTime horario, double valor, string descricao, string tipo)
        {
            this.horario = horario;
            this.valor = valor;
            this.descricao = descricao;
            this.tipo = tipo;
        }

        public static readonly string DOURADO = "\u001b[33m";
        public static readonly string VERMELHO = "\u001B[31m";
        public static readonly string RESETCOR = "\u001B[0m";
        public static readonly string VERDE = "\u001B[32m";
        public override string ToString() 
        {
            return $"{DOURADO}{tipo.ToUpper()}{RESETCOR}\nDescrição: {descricao}\nHorário: {horario}\nValor: {valor}";
        }
    }
}
