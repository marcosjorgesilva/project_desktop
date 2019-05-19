using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceVisual.Models
{
    public partial class Categoria
    {	
        [Key]
        public int IdCategoria { get; set; }
        public string TipoCategoria { get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Categoria()
        {
        }

        public Categoria(int idCategoria, string tipoCategoria)
        {
            IdCategoria = idCategoria;
            TipoCategoria = tipoCategoria;
        }

        public void AddProduto(Produto p)
        {
            Produtos.Add(p);
        }

        public void RemoveProduto(Produto p)
        {
            Produtos.Remove(p);
        }
    }
}
