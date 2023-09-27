namespace CamadaDeNegocios
{
    internal class Extrato : Cliente
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
    }
}
