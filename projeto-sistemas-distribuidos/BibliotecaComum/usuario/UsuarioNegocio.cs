using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.usuario
{
    public class UsuarioNegocio : UsuarioInterface
    {
        public void Create(Usuario usuario)
        {
            string[] simbolosNom =  {"!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "+", "=", "'", "/", ".",
                                     ",", "|", "<", ">", ":", ";", "?", "~", "^", "´", "`", "_", "[", "]", "{",
                                     "}", "ª", "º", "°", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\\"};
            #region validações
            #region validação de objeto
            isUsuarioValid(usuario);
            #endregion

            #region validações de nome
            isNomeValid(usuario, simbolosNom);
            #endregion

            #region validações de CPF
            isCpfValid(usuario);
            #endregion

            #region validações de login
            isLoginValid(usuario, simbolosNom);
            #endregion

            #region validações de email
            isEmailValid(usuario);
            #endregion

            #region formatação de CPF e telefones
            usuario.Cpf = formatCpf(usuario.Cpf);
            usuario.TelefoneCelular = formatTelefone(usuario.TelefoneCelular);
            usuario.TelefoneFixo = formatTelefone(usuario.TelefoneFixo);
            #endregion

            #region validações de telefone
            isTelefoneValid(usuario);
            #endregion
            #endregion

            // falta validaçao de data de nascimento e endereço

            // chamada ao DAO
            new UsuarioDados().Create(usuario);
        }

        public void Remove(Usuario usuario)
        {
            usuario.Cpf = formatCpf(usuario.Cpf);

            new UsuarioDados().Remove(usuario);
        }

        public void Update(Usuario usuario)
        {
            new UsuarioDados().Update(usuario);
        }

        public List<Usuario> Detail(Usuario filtro)
        {
            return new UsuarioDados().Detail(filtro);
        }

        #region métodos para uso interno da classe
        private static string formatTelefone(String telefone)
        {
            telefone = telefone.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");
            telefone = telefone.Replace(" ", "");
            telefone = telefone.Trim();
            return telefone;
        }

        private static string formatCpf(String cpf)
        {
            cpf = cpf.Replace("-", "");
            cpf = cpf.Replace(".", "");
            cpf = cpf.Trim();
            return cpf;
        }

        private static bool isUsuarioValid(Usuario usuario)
        {
            if (usuario.Equals(null))
                throw new Exception("Nulo: instanciar o usuário!");
            return true;
        }

        private static bool isNomeValid(Usuario usuario, string[] simbolosNom)
        {
            if (usuario.NomeUsuario == null)
                throw new Exception("Nulo: instanciar o nome do usuário!");

            if (usuario.NomeUsuario.Trim().Equals(""))
                throw new Exception("Nome do usuário deve ser inserido!");

            if (usuario.NomeUsuario.Length > 150)
                throw new Exception("Nome do usuário não pode exceder 150 caracteres!");

            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (usuario.NomeUsuario.Contains(simbolosNom[i]))
                    throw new Exception("Nome do usuário não pode conter símbolos especiais!");
            }

            return true;
        }

        private static bool isCpfValid(Usuario usuario)
        {
            if (usuario.Cpf == null)
                throw new Exception("Nulo: instanciar o CPF do usuário!");

            if (usuario.Cpf.Replace(" ", "").Equals("..-"))
                throw new Exception("Informar o CPF do usuário!");

            if (usuario.Cpf.Length != 14)
                throw new Exception("Informar o CPF completo do usuário!");

            if (usuario.Cpf.Contains(" "))
                throw new Exception("CPF não deve conter espaços em branco!");

            return true;
        }

        private static bool isLoginValid(Usuario usuario, string[] simbolosNom)
        {
            if (usuario.Login == null)
                throw new Exception("Nulo: instanciar o login do usuário!");

            if (usuario.Login.Trim().Equals(""))
                throw new Exception("Login do usuário deve ser inserido!");

            if (usuario.Login.Length > 50)
                throw new Exception("Login do usuário não pode exceder 150 caracteres!");
            /*
            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (usuario.Login.Contains(simbolosNom[i]))
                    throw new Exception("Login do usuário não pode conter símbolos especiais!");
            }
            */
            return true;
        }

        private static bool isEmailValid(Usuario usuario)
        {
            if (usuario.Email == null)
                throw new Exception("Nulo: Informar o email do usuário!");
            if (usuario.Email.Length > 50)
                throw new Exception("Email do usuário não pode exceder 150 caracteres");

            return true;
        }

        private static bool isTelefoneValid(Usuario usuario)
        {
            if (usuario.TelefoneFixo.Length > 10)
                throw new Exception("Telefone fixo do usuário não pode exceder 12 caracteres!");

            if (usuario.TelefoneCelular.Length > 11)
                throw new Exception("Telefone celular do usuário não pode exceder 12 caracteres!");

            return true;
        }
        #endregion
    }
}
