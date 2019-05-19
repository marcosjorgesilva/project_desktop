using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceVisual.Models
{
    public partial class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
		public string Cidade { get; set; }
        public string Bairro { get; set; }
		public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        public Endereco()
        {
        }

        public Endereco(int idEndereco, string logradouro, int numero, string cidade, string bairro, string estado, string cep, string complemento, string referencia)
        {
            IdEndereco = idEndereco;
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Bairro = bairro;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
            Referencia = referencia;
        }
    }
}