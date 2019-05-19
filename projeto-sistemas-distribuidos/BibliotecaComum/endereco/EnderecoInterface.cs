using System.Collections.Generic;

namespace BibliotecaComum.endereco
{
    interface EnderecoInterface
    {
        void CreateEndereco(Endereco endereco);
        void RemoveEndereco(Endereco endereco);
        void UpdateEndereco(Endereco endereco);
        List<Endereco> DetailEndereco(Endereco filtro);
    }
}
