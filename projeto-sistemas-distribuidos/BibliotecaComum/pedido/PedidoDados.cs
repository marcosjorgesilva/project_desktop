using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComum.conexao;
using System.Data.SqlClient;

namespace BibliotecaComum.pedido
{
    public class PedidoDados : Conexao, PedidoInterface
    {
        #region Insert

        public void Create(Pedido pedido)
        {
            this.abrirConexao();
            string sqlQuery = "INSERT INTO PEDIDO (idpedido, datapedido, dataentrega, valorpedido)";
            sqlQuery += "VALUES (@idpedido, @datapedido, @dataentrega, @valorpedido)";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idpedido"].Value = pedido.IdPedido;

            //cmd.Parameters.Add("@usuario", SqlDbType.Usuario);
            //cmd.Parameters["@usuario"].Value = pedido.Usuario;

            //cmd.Parameters.Add("@formapagamento", SqlDbType.FormaPagamento);
            //cmd.Parameters["@formapagamento"].Value = pedido.FormaPagamento;

            cmd.Parameters.Add("@datapedido", SqlDbType.DateTime);
            cmd.Parameters["@datapedido"].Value = pedido.DataPedido;

            cmd.Parameters.Add("@dataentrega", SqlDbType.DateTime);
            cmd.Parameters["@dataentrega"].Value = pedido.DataEntrega;

            cmd.Parameters.Add("@valorpedido", SqlDbType.Decimal);
            cmd.Parameters["@valorpedido"].Value = pedido.ValorPedido;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            this.fecharConexao();
        }
        #endregion
        #region Remove
        public void Remove(Pedido pedido)
        {
            this.abrirConexao();
            string sqlQuery = "delete from pedido";
            sqlQuery += "where idpedido = @idpedido";

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idpedido"].Value = pedido.IdPedido;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            this.fecharConexao();
        }
        #endregion
        #region Update
        public void Update(Pedido pedido)
        {
            this.abrirConexao();
            string sqlQuery = "update pedido set";
            sqlQuery += "usuario = @usuario";
            sqlQuery += "where idpedido = @idpedido";
            

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            cmd.Parameters.Add("@idPedido", SqlDbType.Int);
            cmd.Parameters["@idpedido"].Value = pedido.IdPedido;

            //cmd.Parameters.Add("@usuario", SqlDbType.Usuario);
            //cmd.Parameters["@usuario"].Value = pedido.Usuario;

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            this.fecharConexao();
        }
        #endregion
        #region Select
        public List<Pedido> Select(Pedido filtro)
        {
            List<Pedido> retorno = new List<Pedido>();
            this.abrirConexao();
            string sqlQuery = "SELECT (idpedido, usuario)";
            sqlQuery += "FROM Pedido";
            sqlQuery += "Where pedido = @idpedido";

            if (filtro.IdPedido > 0)
            {
                sqlQuery += " and idpedido = @idpedido";
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

            if (filtro.IdPedido > 0)
            {
                cmd.Parameters.Add("@idpedido", SqlDbType.Int);
                cmd.Parameters["@idpedido"].Value = filtro.IdPedido;
            }
   
            if (filtro.Usuario != null && filtro.Usuario.Trim().Equals("") == false)
            {
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar);
                cmd.Parameters["@usuario"].Value = "%" + filtro.Usuario + "%";

            }

            SqlDataReader DbReader = cmd.ExecuteReader();
            
            while (DbReader.Read())
            {
                Pedido pedido = new Pedido();
                
                pedido.IdPedido = DbReader.GetInt32(DbReader.GetOrdinal("idpedido"));
                pedido.Usuario = DbReader.GetString(DbReader.GetOrdinal("usuario"));
                retorno.Add(pedido);
            }
            
            DbReader.Close();

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            return retorno;

            this.fecharConexao();
        }
        #endregion

    }
}
