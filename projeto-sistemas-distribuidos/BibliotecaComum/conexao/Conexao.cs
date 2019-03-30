using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.conexao
{
    public class Conexao
    {
        #region declaração de variáveis
        private const string local = "localhost";
        private const string bancoDeDados = "MELOCHICOUT";
        private const string usuario = "melochicout";
        private const string senha = "123";
        // constante local deve ser alterada para a instância local do banco(cada máquina tem a sua)
        #endregion

        // string usada para estabelecer conexão com base de dados
        string stringConexaoSqlServer = @"Data Source=" + local + ";Initial Catalog=" + bancoDeDados +
                                        ";UId=" + usuario + ";Password=" + senha + ";";

        // classe responsável por lidar com a base de dados, uma espécie de Driver nativo da linguagem
        public SqlConnection sqlConnection;

        public void abrirConexao()
        {
            // instanciando uma conexão usando a string como parâmetro
            this.sqlConnection = new SqlConnection(stringConexaoSqlServer);

            // abrindo conexão com base de dados
            this.sqlConnection.Open();
        }

        public void fecharConexao()
        {
            // fechando conexão
            this.sqlConnection.Close();

            // liberando memória alocada anteriormente
            this.sqlConnection.Dispose();
        }
    }
}
