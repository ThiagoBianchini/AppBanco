using CamadaDeNegocios;
using Newtonsoft.Json;
using System.IO;

namespace CamadaDeDados
{
    public class FileRepo : IRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();
        private string arquivo = @"C:../../../../Files/Clientes.json";

        public void Cadastrar(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public string Depositar(Cliente cliente) { return null; }
        public string Sacar(Cliente cliente) { return null; }
        public string Pagar(Cliente cliente) { return null; }
        public string Transferir(Cliente beneficiado, Cliente favorecido) { return null; }

        private void Lerjson()
        {
            using (var file = File.Open(arquivo, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var stream = new StreamReader(file))
                {
                    var json = stream.ReadToEnd();

                    this.clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                    stream.Close();
                }
            }
            if (this.clientes == null)
            {
                this.clientes = new List<Cliente>();
            }
        }
        public void Escreverjson()
        {
            if (this.clientes == null)
            {
                return;
            }

            using (var file = File.Open(arquivo, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var stream = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this.clientes, Formatting.None);
                    json = json.Replace(Environment.NewLine, "");

                    stream.WriteLine(json);

                    stream.Close();
                }
            }
            if (this.clientes == null)
            {
                this.clientes = new List<Cliente>();
            }
        }

    }

}

