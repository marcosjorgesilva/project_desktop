using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceVisual.Models
{
    public partial class Produto 
	{
        [Key]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double ValorProduto { get; set; }
        public int Estoque { get; set; }
        public string Tamanho { get; set; }

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public Produto()
        {
        }

        public Produto(int idProduto, string nome, double valorProduto, int estoque, string tamanho)
        {
            IdProduto = idProduto;
            Nome = nome;
            ValorProduto = valorProduto;
            Estoque = estoque;
            Tamanho = tamanho;
        }

    }
    
}
