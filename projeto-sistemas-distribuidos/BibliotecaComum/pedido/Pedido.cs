using System;
using BibliotecaComum;
using BibliotecaComum.forma_pagamento;

namespace BibliotecaComum.pedido
{
    public class Pedido
    {
        private int idPedido;
        private string usuario;
        private DateTime dataPedido;
        private DateTime dataEntrega;
        private double valorPedido;
        public FormaPagamento formaPagamento { get; set; }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public double ValorPedido { get => valorPedido; set => valorPedido = value; }
    }
}
