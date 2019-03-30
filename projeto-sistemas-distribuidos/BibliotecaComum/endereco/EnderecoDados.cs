using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;

namespace BibliotecaComum.endereco
{
    public class EnderecoDados : Conexao, EnderecoInterface
    {
        public void Create(Endereco endereco)
        {
            this.abrirConexao();
            string sqlQuery = "INSERT INTO endereco (idEndereco, usuario, logradouro, numero ,bairro, cep, complemento ,referencia) ";
            sqlQuery += "VALUES (@idEndereco, @usuario, @logradouro, @numero, @bairro, @cep, @complemento, @referencia)";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            // execução da query
            cmd.ExecuteNonQuery();

            // liberação de memória alocada para o objeto SqlCommand
            cmd.Dispose();

            // fechamento de conexão com base de dados
            this.fecharConexao();

        }

      
        public void Remove(Endereco endereco)
        {
            // lógica que acessa a base de dados e realiza instrução DELETE baseado no idEndereco do usuário
            try
            {
                this.abrirConexao();
                #region query SQL
                string sqlQuery = "DELETE FROM endereco WHERE idEndereco = @idEndereco ";

                SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

                cmd.Parameters.Add("@idEnderecof", SqlDbType.VarChar);
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

        public void Update(Endereco endereco)
        {
            this.abrirConexao();
            string sqlQuery = "UPADATE endereco";
            sqlQuery += "SET logradouro=@logradouro, numero=@numero, bairro=@bairro, cep=@cep, complemento=@complemento, referencia=@referencia ";






          
            throw new NotImplementedException();
        }

        public List<Endereco> Detail(Endereco endereco)
        {
            throw new NotImplementedException();

        }
    }
}
