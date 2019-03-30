using BibliotecaComum.categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.produto
{
    class Produto
    {
        private int idProduto;
        private Categoria categoria;
        private string nome;
        private double valorProduto;
        private int estoque;
        private char tamanho;

        public int IdProduto { get => idProduto; set => idProduto = value; }
        public Categoria Categoria { get => categoria; set => categoria = value; }
        public string Nome { get => nome; set => nome = value; }
        public double ValorProduto { get => valorProduto; set => valorProduto = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public char Tamanho { get => tamanho; set => tamanho = value; }
    }
}
