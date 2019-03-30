using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.pedido
{
    class Pedido
    {
        private int idPedido;
        private string usuario;
        private formadePagamento formadePagamento;
        private DateTime dataPedido;
        private DateTime dataEntrega;
        private double valorPedido;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public formadePagamento FormadePagamento { get => formadePagamento; set => formadePagamento = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public double ValorPedido { get => valorPedido; set => valorPedido = value; }
    }
}
