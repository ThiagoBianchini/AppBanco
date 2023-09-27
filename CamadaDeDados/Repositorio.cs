using CamadaDeNegocios;

namespace CamadaDeDados
{
    public interface IRepositorio : Cliente
    {
        Cliente Cadastrar();
        string Depositar();
        string Sacar();
        string Pagar();
        string Transferir(Cliente beneficiado, Cliente favorecido);
    }
}
