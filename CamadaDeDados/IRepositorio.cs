using CamadaDeNegocios;

namespace CamadaDeDados
{
    public interface IRepositorio
    {
        void Cadastrar(Cliente cliente);
        string Depositar(Cliente cliente);
        string Sacar(Cliente cliente);
        string Pagar(Cliente cliente);
        string Transferir(Cliente beneficiado, Cliente favorecido);
    }
}
