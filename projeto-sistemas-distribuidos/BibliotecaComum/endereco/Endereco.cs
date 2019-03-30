using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.usuario;

namespace BibliotecaComum.endereco
{
     public class Endereco
    {
        private int idEndereco;
        private Usuario usuario;
        private String logradouro;
        private int numero;
        private String bairro;
        private String cep;
        private String complemento;
        private String referencia;

        public int IdEndereco { get => idEndereco; set => idEndereco = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Completo { get => complemento; set => complemento = value; }
        public string Referencia { get => referencia; set => referencia = value; }
    }
}
