using CamadaDeNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
