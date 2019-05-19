using System.Collections.Generic;

namespace BibliotecaComum.endereco
{
    class EnderecoNegocio : EnderecoInterface
    {
        public void CreateEndereco(Endereco endereco)
        {
            new EnderecoDados().CreateEndereco(endereco);
        }

        public List<Endereco> DetailEndereco(Endereco filtro)
        {
            return new EnderecoDados().DetailEndereco(filtro);
        }

        public void RemoveEndereco(Endereco endereco)
        {
            new EnderecoDados().RemoveEndereco(endereco);
        }

        public void UpdateEndereco(Endereco endereco)
        {
            new EnderecoDados().UpdateEndereco(endereco);
        }
    }
}
