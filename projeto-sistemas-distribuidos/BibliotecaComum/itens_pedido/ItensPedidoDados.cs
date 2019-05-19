using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;
using System.Data.SqlClient;
using System.Data;
using BibliotecaComum.forma_pagamento;

namespace BibliotecaComum.itens_pedido
{
    public class ItensPedidoDados : Conexao, ItensPedidoInterface
    {
        #region método Insert
        public void Insert(ItensPedido itensPedido)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "INSERT INTO itensPedido(idPedido,idProduto,quantidade,valorItens,descricaoIp) ";
            sql += "VALUES (@idPedido,@idProduto,@quantidade,@valorItens,@descricaoIp)";

            SqlCommand cmd = new SqlCommand(sql,this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idPedido"].Value = itensPedido.IdPedido;

            cmd.Parameters.Add("@idProduto", SqlDbType.Int);
            cmd.Parameters["@idProduto"].Value = itensPedido.IdProduto;

            cmd.Parameters.Add("@quantidade", SqlDbType.Int);
            cmd.Parameters["@quantidade"].Value = itensPedido.Quantidade;

            cmd.Parameters.Add("@valorItens", SqlDbType.Float);
            cmd.Parameters["@valorItens"].Value = itensPedido.ValorItens;

            cmd.Parameters.Add("@descricaoIp", SqlDbType.VarChar);
            cmd.Parameters["@descricaoIp"].Value = itensPedido.DescricaoIp;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region método Update
        public void Update(ItensPedido itensPedido)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "UPDATE itensPedido SET ";
            sql += "idProduto = @idProduto, ";
            sql += "quantidade = @quantidade, ";
            sql += "valorItens = @valorItens, ";
            sql += "descricaoIp = @descricaoIp, ";
            sql += "WHERE idPedido = @idPedido;";

            //instrução a ser executada
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idPedido"].Value = itensPedido.IdPedido;

            cmd.Parameters.Add("@idProduto", SqlDbType.Int);
            cmd.Parameters["@idProduto"].Value = itensPedido.IdProduto;

            cmd.Parameters.Add("@quantidade", SqlDbType.Int);
            cmd.Parameters["@quantidade"].Value = itensPedido.Quantidade;

            cmd.Parameters.Add("@valorItens", SqlDbType.Float);
            cmd.Parameters["@valorItens"].Value = itensPedido.ValorItens;

            cmd.Parameters.Add("@descricaoIp", SqlDbType.VarChar);
            cmd.Parameters["@descricaoIp"].Value = itensPedido.DescricaoIp;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region método Delete
        public void Delete(ItensPedido itensPedido)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "DELETE FROM itensPedido ";
            sql += "WHERE idPedido = @idPedido";

            //instrução a ser executada
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idPedido"].Value = itensPedido.IdPedido;
            
            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region método Select
        public List<ItensPedido> Select(ItensPedido filtro)
        {
            List<ItensPedido> retorno = new List<ItensPedido>();
            //abrir a conexão
            this.abrirConexao();
            string sql = "SELECT @idPedido, @idProduto, @quantidade, @valorItens, @descricaoIp ";
            sql += "FROM itensPedido ";
            sql += "WHERE idPedido = @idPedido";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            //se foi passada uma ID de pedido válido, este ID entrará como critério de filtro
            if (filtro.IdPedido > 0)
            {
                sql += " and idPedido = @idPedido";
            }

            //se foi passada uma ID de produto válido, este ID entrará como critério de filtro
            if (filtro.IdProduto > 0)
            {
                sql += " and idProduto = @idProduto";
            }

            //se foi passado uma quantidade válida, esta quantidade entrará como critério de filtro
            if (filtro.IdProduto > 0)
            {
                sql += " and quantidade = @quantidade";
            } 

            //se foi passada um valor válido, este valor entrará como critério de filtro
            if (filtro.ValorItens > 0)
            {
                sql += " and valorItens = @valorItens";
            }

            //se foi passado uma descricao válida, esta descricao entrará como critério de filtro
            //if (String.IsNullOrEmpty(filtro.IdProduto) && String.IsNullOrWhiteSpace(filtro.IdProduto))
            //{
            //    sql += " and descricao = @descricao";
            //}    
                                 
            //se foi passada uma ID de pedido válido, este ID entrará como critério de filtro
            if (filtro.IdPedido > 0)
            {
                cmd.Parameters.Add("@idPedido", SqlDbType.Int);
                cmd.Parameters["@idPedido"].Value = filtro.IdPedido;
            }

            //se foi passada uma ID de produto válido, este ID entrará como critério de filtro
            if (filtro.IdProduto > 0)
            {
                cmd.Parameters.Add("@idProduto", SqlDbType.Int);
                cmd.Parameters["@idProduto"].Value = filtro.IdProduto;
            }

            //se foi passado uma quantidade válida, esta quantidade entrará como critério de filtro
            if (filtro.IdProduto > 0)
            {
                cmd.Parameters.Add("@quantidade", SqlDbType.Int);
                cmd.Parameters["@quantidade"].Value = filtro.Quantidade;
            }
        
            //se foi passada um valor de item válido, este valor entrará como critério de filtro
            if (filtro.IdProduto > 0)
            {
                cmd.Parameters.Add("@valorItens", SqlDbType.Float);
                cmd.Parameters["@valorItens"].Value = filtro.ValorItens;
            }

            //se foi passado uma descrição válida, esta descrição entrará como critério de filtro
            //if (String.IsNullOrEmpty(filtro.IdProduto) || String.IsNullOrWhiteSpace(filtro.IdProduto))
            //{
            //    cmd.Parameters.Add("@descricaoIp", SqlDbType.VarChar);
            //    cmd.Parameters["@descricaoIp"].Value = filtro.DescricaoIp;
            //}

            //executando a instrucao e colocando o resultado em um leitor
            SqlDataReader DbReader = cmd.ExecuteReader();

            //lendo o resultado da consulta
            while (DbReader.Read())
            {
                ItensPedido itensPedido = new ItensPedido();
                //acessando os valores das colunas do resultado
                itensPedido.IdPedido = DbReader.GetInt32(DbReader.GetOrdinal("id_pedido"));
                itensPedido.IdPedido = DbReader.GetInt32(DbReader.GetOrdinal("id_produto"));
                itensPedido.Quantidade = DbReader.GetInt32(DbReader.GetOrdinal("quantidade"));
                itensPedido.ValorItens = DbReader.GetFloat(DbReader.GetOrdinal("valor_itens"));
                //itensPedido.DescricaoIp = DbReader.GetString(DbReader.GetString("descricao"));
                retorno.Add(itensPedido);                
            }
            //fechando o leitor de resultados
            DbReader.Close();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();

            return retorno;
        }
        #endregion
        
    }
}