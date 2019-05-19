using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BibliotecaComum.conexao;

namespace BibliotecaComum.endereco
{
    public class EnderecoDados : Conexao, EnderecoInterface
    {
        public void CreateEndereco(Endereco endereco)  // logradouro, numero, bairro, cep, complemento, referencia
        {
            this.abrirConexao();
            string sqlQuery = "INSERT INTO endereco logradouro, numero, bairro, cep, complemento, referencia) ";
            sqlQuery += "VALUES (@logradouro, @numero, @bairro, @cep, @complemento, @referencia)";
            
            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            // execução da query
            cmd.ExecuteNonQuery();

            // liberação de memória alocada para o objeto SqlCommand
            cmd.Dispose();

            // fechamento de conexão com base de dados
            this.fecharConexao();
        }

      
        public void RemoveEndereco(Endereco endereco)
        {
            // lógica que acessa a base de dados e realiza instrução DELETE baseado no idEndereco do usuário
            try
            {
                this.abrirConexao();
                #region query SQL
                string sqlQuery = "DELETE FROM endereco WHERE idEndereco = @idEndereco ";

                SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

                cmd.Parameters.Add("@idEndereco", SqlDbType.VarChar);
                cmd.Parameters["@idEndereco"].Value = endereco.IdEndereco;

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                #endregion
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new NotImplementedException();
        }

        public void UpdateEndereco(Endereco endereco)
        {
            this.abrirConexao();
            string sqlQuery = "UPADATE endereco";
            sqlQuery += "SET logradouro = @logradouro, numero = @numero, bairro = @bairro, cep = @cep, complemento = @complemento, referencia = @referencia ";






          
            throw new NotImplementedException();
        }

        public List<Endereco> DetailEndereco(Endereco endereco)
        {
            throw new NotImplementedException();

        }
    }
}
