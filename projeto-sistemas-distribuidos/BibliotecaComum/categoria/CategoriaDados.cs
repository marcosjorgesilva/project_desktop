using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaComum.categoria
    {

        /*
         1 - abrir conexão;
         2 - inserir a query;
         3 - executar comando da query indicando a string query e o atributo de conexão;
         3 - indicar parametro ADD;
         4 - adicionar o valor do parametro indicado;
         5 - executar query;
         6 - fechar conexão;
         */
        public class CategoriaDados : Conexao, CategoriaInterface
        {
			string query;

        public void delete(Categoria categoria)
        {
            this.abrirConexao();
            query = "DELETE categoria WHERE ID_Categoria = @id_categoria ";
            SqlCommand cmd = new SqlCommand(query, this.sqlConnection);

            cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
            cmd.Parameters["@id_categoria"].Value = categoria.IdCategoria;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();
        }

        public void insert(Categoria categoria)
        {
            this.abrirConexao();
            query = "INSERT INTO categoria (Tipo_Categoria) VALUES (@tipo_categoria)";
            SqlCommand cmd = new SqlCommand(query, this.sqlConnection);

            cmd.Parameters.Add("@tipo_categoria", SqlDbType.VarChar);
            cmd.Parameters["@tipo_categoria"].Value = categoria.TipoCategoria;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();  
        }

        public List<Categoria> list(Categoria categoria)
        {
            List<Categoria> retorno = new List<Categoria>();
            SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
            this.abrirConexao();

            query = "SELECT ID_Categoria, Tipo_Categoria ";
            query += " FROM categoria ";
            query += " WHERE ID_Categoria = ID_Categoria ";

            if (categoria.IdCategoria > 0)
            {
                query += " and ID_Categoria = @id_categoria";
            }

            if (categoria.TipoCategoria != null && categoria.TipoCategoria.Trim().Equals("") == false)
            {
                query += " and Tipo_Categoria like @tipo_categoria";
            }
                
            if (categoria.IdCategoria > 0)
            {
                cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
                cmd.Parameters["@id_categoria"].Value = categoria.IdCategoria;
            }

            if (categoria.TipoCategoria != null && categoria.TipoCategoria.Trim().Equals("") == false)
            {
                cmd.Parameters.Add("@tipo_categoria", SqlDbType.VarChar);
                cmd.Parameters["@tipo_categoria"].Value = "%" + categoria.TipoCategoria + "%";

            }

            SqlDataReader DbReader = cmd.ExecuteReader();
            while (DbReader.Read())
            {               
                categoria.IdCategoria = DbReader.GetInt32(DbReader.GetOrdinal("ID_Categoria"));
                categoria.TipoCategoria = DbReader.GetString(DbReader.GetOrdinal("Tipo_Categoria"));
                retorno.Add(categoria);
            }

            DbReader.Close();
 
            cmd.Dispose();
            this.fecharConexao();

            return retorno;
        }

        public void update(Categoria categoria)
        {
            this.abrirConexao();
            query = "UPDATE categoria SET Tipo_Categoria = @tipo_categoria WHERE ID_Categoria = @id_categoria";
            SqlCommand cmd = new SqlCommand(query,this.sqlConnection);

            cmd.Parameters.Add("@tipo_categoria", SqlDbType.VarChar);
            cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
            cmd.Parameters["tipo_categoria"].Value = categoria.TipoCategoria;
            cmd.Parameters["@id_categoria"].Value = categoria.IdCategoria;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();
        }
    }
}
