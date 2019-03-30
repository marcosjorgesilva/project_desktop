using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaComum.produto
{
    class ProdutoDados : Conexao, ProdutoInterface
    {
        string query;

        public void delete(Produto produto)
        {
            this.abrirConexao();
            query = "DELETE produto WHERE ID_Produto = @id_produto ";
            SqlCommand cmd = new SqlCommand(query,this.sqlConnection);

            cmd.Parameters.Add("@id_produto", SqlDbType.Int);
            cmd.Parameters["@id_produto"].Value = produto.IdProduto;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();
        }

        public void insert(Produto produto)
        {
            this.abrirConexao();
            query = "INSERT INTO produto(ID_Categoria,Nome,Valor_Produto,Estoque,Tamanho) ";
            query += "VALUES (@id_categoria, @nome, @valor_produto, @estoque, @tamanho)";
            SqlCommand cmd = new SqlCommand(query, this.sqlConnection);

            cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
            cmd.Parameters["@id_produto"].Value = produto.Categoria;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters["@nome"].Value = produto.Nome;
            cmd.Parameters.Add("@valor_produto", SqlDbType.Decimal);
            cmd.Parameters["@valor_produto"].Value = produto.ValorProduto;
            cmd.Parameters.Add("@estoque", SqlDbType.Int);
            cmd.Parameters["@estoque"].Value = produto.Estoque;
            cmd.Parameters.Add("@tamanho", SqlDbType.Char);
            cmd.Parameters["@tamanho"].Value = produto.Tamanho;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();
        }

        public List<Produto> list(Produto produto)
        {
            List<Produto> retorno = new List<Produto>();
            SqlCommand cmd = new SqlCommand(query,this.sqlConnection);
            this.abrirConexao();

            query =  "SELECT ID_Produto, ID_Categoria, Nome, Valor_Produto, Estoque, Tamanho ";
            query += "FROM produto ";
            query += "WHERE ID_Produto = ID_Produto ";

            if (produto.IdProduto > 0)
            {
                query += "and ID_Produto = @id_produto ";
            }
            if (produto.IdProduto > 0)
            {
                cmd.Parameters.Add("@id_produto", SqlDbType.Int);
                cmd.Parameters["@id_produto"].Value = produto.IdProduto;
            }

            if (produto.Categoria.IdCategoria > 0)
            {
                query += "AND ID_Categoria = @id_categoria ";
            }
            if (produto.Categoria.IdCategoria > 0)
            {
                cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
                cmd.Parameters["@id_categoria"].Value = produto.Categoria.IdCategoria;
            }

            if (produto.Nome != null && produto.Nome.Trim().Equals("") == false)
            {
                query += "AND Nome = @nome ";
            }
            if (produto.Nome != null && produto.Nome.Trim().Equals("") == false)
            {
                cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                cmd.Parameters["@nome"].Value = "%"+produto.Nome+"%";
            }

            if (produto.ValorProduto > 0)
            {
                query += "AND Valor_Produto = @valor_produto ";
            }
            if (produto.ValorProduto > 0)
            {
                cmd.Parameters.Add("@valor_produto", SqlDbType.Decimal);
                cmd.Parameters["@valor_produto"].Value = produto.ValorProduto;
            }

            if (produto.Estoque > 0)
            {
                query += "AND Estoque = @estoque ";
            }
            if (produto.Estoque > 0)
            {
                cmd.Parameters.Add("@estoque", SqlDbType.Int);
                cmd.Parameters["@estoque"].Value = produto.Estoque;
            }

            if (produto.Tamanho.Equals("") == false)
            {
                query += "AND Tamanho =  @tamanho ";
            }
            if (produto.Tamanho.Equals("") == false)
            {
                cmd.Parameters.Add("@tamanho", SqlDbType.Char);
                cmd.Parameters["@tamanho"].Value = "%" + produto.Tamanho + "%";
            }

            SqlDataReader DbReader = cmd.ExecuteReader();
            while (DbReader.Read())
            {
                produto.IdProduto = DbReader.GetInt32(DbReader.GetOrdinal("ID_Produto"));
                produto.Categoria.IdCategoria = DbReader.GetInt32(DbReader.GetOrdinal("ID_Categoria"));
                produto.Nome = DbReader.GetString(DbReader.GetOrdinal("Nome"));
                produto.ValorProduto = DbReader.GetFloat(DbReader.GetOrdinal("Valor_Produto"));
                produto.Estoque = DbReader.GetInt32(DbReader.GetOrdinal("Estoque"));
                produto.Tamanho = DbReader.GetChar(DbReader.GetOrdinal("Tamanho"));
                retorno.Add(produto);
            }

            DbReader.Close();

            cmd.Dispose();
            this.fecharConexao();

            return retorno;
        }

        public void update(Produto produto)
        {
            this.abrirConexao();
            query = "UPDATE produto SET ID_Categoria = @id_categoria, Nome = @nome, Valor_Produto = @valor_produto = @valor_produto, Estoque = @estoque, Tamanho = @tamanho ";
            query += "WHERE ID_Produto = @id_produto ";
            SqlCommand cmd = new SqlCommand(query, this.sqlConnection);

            cmd.Parameters.Add("@id_categoria", SqlDbType.Int);
            cmd.Parameters["@id_produto"].Value = produto.Categoria;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            cmd.Parameters["@nome"].Value = produto.Nome;
            cmd.Parameters.Add("@valor_produto", SqlDbType.Decimal);
            cmd.Parameters["@valor_produto"].Value = produto.ValorProduto;
            cmd.Parameters.Add("@estoque", SqlDbType.Int);
            cmd.Parameters["@estoque"].Value = produto.Estoque;
            cmd.Parameters.Add("@tamanho", SqlDbType.Char);
            cmd.Parameters["@tamanho"].Value = produto.Tamanho;

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            this.fecharConexao();
        }
    }
}
