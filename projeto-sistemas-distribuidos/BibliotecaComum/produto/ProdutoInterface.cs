using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.produto
{
    interface ProdutoInterface
    {
        void insert(Produto produto);
        void delete(Produto produto);
        void update(Produto produto);
        List<Produto> list(Produto produto);
    }
}
