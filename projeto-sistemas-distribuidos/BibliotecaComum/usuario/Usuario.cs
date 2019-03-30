using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.usuario
{
    public class Usuario
    {
        private int idUsuario;
        private String tipoUsuario;
        private String nomeUsuario;
        private String login;
        private String senha;
        private String cpf;
        private String email;
        private String dataNascimento;
        private String telefoneFixo;
        private String telefoneCelular;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string DataNascimento { get => dataNascimento; set => dataNascimento = value; }
        public string TelefoneFixo { get => telefoneFixo; set => telefoneFixo = value; }
        public string TelefoneCelular { get => telefoneCelular; set => telefoneCelular = value; }
    }
}
