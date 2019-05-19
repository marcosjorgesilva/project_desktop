using BibliotecaComum.usuario;

namespace BibliotecaComum.endereco
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public Usuario Usuario { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public Endereco() { }

        public Endereco(Usuario usuario, string logradouro, int numero, string bairro, string cep, string complemento, string referencia)
        {
            Usuario = usuario;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Complemento = complemento;
            Referencia = referencia;
        }
    }
}