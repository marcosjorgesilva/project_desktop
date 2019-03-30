using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.categoria
{
    public interface CategoriaInterface
    {
        void insert(Categoria categoria);
        void delete(Categoria categoria);
        void update(Categoria categoria);
        List<Categoria> list(Categoria categoria);
    }
}
