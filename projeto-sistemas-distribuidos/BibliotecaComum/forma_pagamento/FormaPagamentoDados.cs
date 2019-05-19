using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaComum.forma_pagamento
{
    public class FormaPagamentoDados : Conexao, FormaPagamentoInterface
    {
        #region método insert
        public void Insert(FormaPagamento formaPagamento)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "insert into formaPagamento(id_formaPagamento,descricao_fp,tipo_fp)";
            sql += "values (@id_formaPagamento,@descricao_fp,@tipo_fp)";
            
            //instrução a ser executada
            SqlCommand cmd = new SqlCommand(sql,this.sqlConnection);

            cmd.Parameters.Add("@id_formaPagamento", SqlDbType.Int);
            cmd.Parameters["@id_formaPagamento"].Value = formaPagamento.IdFormaPagamento;

            cmd.Parameters.Add("@descricao_fp", SqlDbType.VarChar);
            cmd.Parameters["@descricao_fp"].Value = formaPagamento.DescricaoFp;

            cmd.Parameters.Add("@tipo_fp", SqlDbType.Char);
            cmd.Parameters["@tipo_fp"].Value = formaPagamento.TipoFp;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region método update
        public void Update(FormaPagamento formaPagamento)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "update formaPagamento set ";
            sql += "descricao_fp = @descricao_fp, ";
            sql += "tipo_fp = @tipo_fp ";
            sql += "where id_formaPagamento = @id_formaPagamento ";

            //instrução a ser executada
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@id_formaPagamento", SqlDbType.Int);
            cmd.Parameters["@id_formaPagamento"].Value = formaPagamento.IdFormaPagamento;

            cmd.Parameters.Add("@descricao_fp", SqlDbType.VarChar);
            cmd.Parameters["@descricao_fp"].Value = formaPagamento.DescricaoFp;

            cmd.Parameters.Add("@tipo_fp", SqlDbType.Char);
            cmd.Parameters["@tipo_fp"].Value = formaPagamento.TipoFp;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();                       
        }
        #endregion

        #region método delete
        public void Delete(FormaPagamento formaPagamento)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "delete from formaPagamento";
            sql += "where id_formaPagamento = @id_formaPagamento";

            //instrução a ser executada
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@id_formaPagamento", SqlDbType.Int);
            cmd.Parameters["@id_formaPagamento"].Value = formaPagamento.IdFormaPagamento;
            
            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region método select
        public List<FormaPagamento> Select(FormaPagamento filtro)
        {
            List<FormaPagamento> retorno = new List<FormaPagamento>();
            //abrir a conexão
            this.abrirConexao();
            string sql = "SELECT @id_formaPagamento, @descricao_fp, @tipo_fp";
            sql += "FROM formaPagamento";
            sql += "WHERE id_formaPagamento = id_formaPagamento";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
            if (filtro.IdFormaPagamento > 0)
            {
                sql += " and id_formaPagamento = @id_formaPagamento";
            }

            //se foi passada uma descrição válida, esta descrição entrará como critério de filtro
            if (filtro.DescricaoFp != null && filtro.DescricaoFp.Trim().Equals("") == false)
            {
                sql += " and nome like @descricao_fp";
            }

            //se foi passado um tipo válido, este tipo entrará como critério de filtro
            if (filtro.TipoFp != null && filtro.TipoFp.Trim().Equals("") == false)
            {
                sql += " and nome like @tipo_fp";
            }
                                   
            //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
            if (filtro.IdFormaPagamento > 0)
            {
                cmd.Parameters.Add("@id_formaPagamento", SqlDbType.Int);
                cmd.Parameters["@id_formaPagamento"].Value = filtro.IdFormaPagamento;
            }

            //se foi passada uma descrição válida, esta descrição entrará como critério de filtro
            if (filtro.DescricaoFp != null && filtro.DescricaoFp.Trim().Equals("") == false)
            {
                cmd.Parameters.Add("@descricao_fp", SqlDbType.VarChar);
                cmd.Parameters["@descricao_fp"].Value = "%" + filtro.DescricaoFp + "%";
            }

            //se foi passado um tipo válido, este tipo entrará como critério de filtro
            if (filtro.TipoFp != null && filtro.TipoFp.Trim().Equals("") == false)
            {
                cmd.Parameters.Add("@tipo_fp", SqlDbType.VarChar);
                cmd.Parameters["@tipo_fp"].Value = "%" + filtro.TipoFp + "%";
            }
                                                                             
            //executando a instrucao e colocando o resultado em um leitor
            SqlDataReader DbReader = cmd.ExecuteReader();

            //lendo o resultado da consulta
            while (DbReader.Read())
            {
                FormaPagamento formaPagamento = new FormaPagamento();
                //acessando os valores das colunas do resultado
                formaPagamento.IdFormaPagamento = DbReader.GetInt32(DbReader.GetOrdinal("id_formaPagamento"));
                formaPagamento.DescricaoFp = DbReader.GetString(DbReader.GetOrdinal("descricao_fp"));
                formaPagamento.TipoFp = DbReader.GetString(DbReader.GetOrdinal("tipo_fp"));
                retorno.Add(formaPagamento);
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