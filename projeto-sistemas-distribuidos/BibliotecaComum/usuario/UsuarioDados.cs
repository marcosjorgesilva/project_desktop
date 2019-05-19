using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BibliotecaComum.conexao;
using BibliotecaComum.endereco;

namespace BibliotecaComum.usuario
{
    class UsuarioDados : Conexao, UsuarioInterface
    {
        public void CreateUsuario(Usuario usuario) // 75%, falta endereço
        {
            // lógica que acessa a base de dados e realiza instrução INSERT
            this.abrirConexao();

            string sqlQuery = "INSERT INTO usuario (nome, cpf, tel_celular, tel_fixo, tipo_usuario, email, login, senha, data_nascimento) ";
            sqlQuery += "VALUES (@nome, @cpf, @tel_celular, @tel_fixo, @tipo_usuario, @email, @login, @senha, @data_nascimento)";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            #region atribuição de valores na query
            setNomeInSqlQuery(usuario, cmd);

            setCpfInSqlQuery(usuario, cmd);

            setEmailInSqlQuery(usuario, cmd);

            setLoginInSqlQuery(usuario, cmd);

            setSenhaInSqlQuery(usuario, cmd);

            setDataNascimentoInSqlQuery(usuario, cmd);

            setTipoUsuarioInSqlQuery(usuario, cmd);

            setTelefoneFixoInUsuario(usuario, cmd);

            setTelefoneCelularInUsuario(usuario, cmd);
            #endregion

            // execução da query
            cmd.ExecuteNonQuery();

            // liberação de memória alocada para o objeto SqlCommand
            cmd.Dispose();

            // lógica que executa a inserção do endereço desse cliente
            /*
             * 1 - checar se existe endereco 
             * 2 - enviar endereço que vem no parametro de usuário para a classe responsável pelo cadastro
             */

            foreach (Endereco end in usuario.Enderecos)
                new EnderecoNegocio().CreateEndereco(end);

            // fechamento de conexão com base de dados
            this.fecharConexao();
        }

        public void RemoveUsuario(Usuario usuario) // 100%
        {
            // lógica que acessa a base de dados e realiza instrução DELETE baseado no CPF do usuário
            this.abrirConexao();
            #region query SQL
            string sqlQuery = "DELETE FROM usuario WHERE cpf = @cpf ";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            cmd.Parameters.Add("@cpf", SqlDbType.VarChar);
            cmd.Parameters["@cpf"].Value = usuario.Cpf;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            #endregion
            this.fecharConexao();
        }

        public void UpdateUsuario(Usuario usuario) // 50% falta definir o que pode ser editado e endreço
        {
            // lógica que acessa a base de dados e realiza instrução UPDATE
            // os campos atualizados podem ser senha, email, endereço, telefones
            // ainda falta edição de endereço
            this.abrirConexao();

            string sqlQuery = "UPDATE usuario ";
            sqlQuery += "SET senha = @senha ";

            if (string.IsNullOrEmpty(usuario.Email))
                sqlQuery += ", email = @email ";

            if (string.IsNullOrEmpty(usuario.TelefoneFixo))
                sqlQuery += ", tel_fixo = @tel_fixo ";

            if (string.IsNullOrEmpty(usuario.TelefoneCelular))
                sqlQuery += ", tel_celular = @tel_celular ";

            sqlQuery += "WHERE cpf = @cpf ";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            if (string.IsNullOrEmpty(usuario.TelefoneCelular) == false)
                setTelefoneCelularInUsuario(usuario, cmd);

            if (string.IsNullOrEmpty(usuario.TelefoneFixo) == false)
                setTelefoneFixoInUsuario(usuario, cmd);

            if (string.IsNullOrEmpty(usuario.Email) == false)
                setEmailInSqlQuery(usuario, cmd);

            setSenhaInSqlQuery(usuario, cmd);
            setCpfInSqlQuery(usuario, cmd);

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            this.fecharConexao();
        }

        public List<Usuario> DetailUsuario(Usuario filtro) // 75% falta definir o que será exibido
        {
            // lógica que acessa a base de dados e realiza instrução SELECT
            this.abrirConexao();

            string sqlQuery = "SELECT nome, cpf, data_nascimento, email, login, tel_celular, tel_fixo ";
            sqlQuery += "FROM usuario WHERE nome = nome ";

            // caso haja parâmetros como filtro para a busca, são adicionados na query
            #region atribuição de filtros na query
            if (string.IsNullOrEmpty(filtro.NomeUsuario) == false)
                sqlQuery += "AND nome = @nome ";

            if (string.IsNullOrEmpty(filtro.Cpf) == false)
                sqlQuery = "AND cpf = @cpf ";

            if (string.IsNullOrEmpty(filtro.Email) == false)
                sqlQuery += "AND email = @email ";

            if (string.IsNullOrEmpty(filtro.DataNascimento.ToString("dd-MM-yyyy")) == false)
                sqlQuery += "AND data_nascimento = @data_nascimento ";

            if (string.IsNullOrEmpty(filtro.Login) == false)
                sqlQuery += "AND login = @login ";

            if (string.IsNullOrEmpty(filtro.TelefoneCelular) == false)
                sqlQuery += "AND tel_celular = @tel_celular ";

            if (string.IsNullOrEmpty(filtro.TelefoneFixo) == false)
                sqlQuery += "AND tel_fixo = @tel_fixo ";
            #endregion

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            #region atribuindo valores aos filtros da query
            if (string.IsNullOrEmpty(filtro.NomeUsuario) == false)
                setNomeInSqlQuery(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.Cpf) == false)
                setCpfInSqlQuery(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.Email) == false)
                setEmailInSqlQuery(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.DataNascimento.ToString("dd-MM-yyyy")) == false)
                setDataNascimentoInSqlQuery(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.Login) == false)
                setLoginInSqlQuery(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.TelefoneCelular) == false)
                setTelefoneCelularInUsuario(filtro, cmd);

            if (string.IsNullOrEmpty(filtro.TelefoneFixo) == false)
                setTelefoneFixoInUsuario(filtro, cmd);
            #endregion

            // leitura dos dados vindos da base e alocação em lista
            #region processando retorno
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<Usuario> retorno = new List<Usuario>();

            while (dataReader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.NomeUsuario = dataReader.GetString(dataReader.GetOrdinal("nome"));
                usuario.Cpf = dataReader.GetString(dataReader.GetOrdinal("cpf"));
                usuario.DataNascimento = dataReader.GetDateTime(dataReader.GetOrdinal("data_nascimento"));
                usuario.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                usuario.Login = dataReader.GetString(dataReader.GetOrdinal("login"));
                usuario.TelefoneCelular = dataReader.GetString(dataReader.GetOrdinal("tel_celular"));
                usuario.TelefoneFixo = dataReader.GetString(dataReader.GetOrdinal("tel_fixo"));
                retorno.Add(usuario);
            }

            cmd.Dispose();

            this.fecharConexao();
            #endregion

            return retorno;
        }

        #region métodos para uso interno da classe
        private static void setTelefoneCelularInUsuario(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@tel_celular", SqlDbType.VarChar);
            cmd.Parameters["@tel_celular"].Value = usuario.TelefoneCelular;
        }

        private static void setTelefoneFixoInUsuario(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@tel_fixo", SqlDbType.VarChar);
            cmd.Parameters["@tel_fixo"].Value = usuario.TelefoneFixo;
        }

        private static void setTipoUsuarioInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@tipo_usuario", SqlDbType.Char);
            cmd.Parameters["@tipo_usuario"].Value = usuario.TipoUsuario;
        }

        private static void setDataNascimentoInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@data_nascimento", SqlDbType.Date);
            cmd.Parameters["@data_nascimento"].Value = usuario.DataNascimento;
        }

        private static void setSenhaInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@senha", SqlDbType.VarChar);
            cmd.Parameters["@senha"].Value = usuario.Senha;
        }

        private static void setLoginInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@login", SqlDbType.VarChar);
            cmd.Parameters["@login"].Value = usuario.Login;
        }

        private static void setEmailInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters["@email"].Value = usuario.Email;
        }

        private static void setCpfInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@cpf", SqlDbType.VarChar);
            cmd.Parameters["@cpf"].Value = usuario.Cpf;
        }

        private static void setNomeInSqlQuery(Usuario usuario, SqlCommand cmd)
        {
            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters["@nome"].Value = usuario.NomeUsuario;
        }
        #endregion
    }
}
