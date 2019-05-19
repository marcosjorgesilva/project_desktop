using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.itens_pedido
{
    public class ItensPedido
    {
        private int idPedido;
        private int idProduto;
        private int quantidade;
        private float valorItens;
        private string descricaoIp;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public int IdProduto { get => idProduto; set => idProduto = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public float ValorItens { get => valorItens; set => valorItens = value; }
        public string DescricaoIp { get => descricaoIp; set => descricaoIp = value; }
    }
}