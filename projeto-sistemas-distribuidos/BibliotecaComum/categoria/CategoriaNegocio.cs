using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.categoria
{
   public class CategoriaNegocio : CategoriaInterface
    {
        public void delete(Categoria categoria)
        {
            new CategoriaDados().delete(categoria);
        }

        public void insert(Categoria categoria)
        {
            new CategoriaDados().insert(categoria);
        }

        public List<Categoria> list(Categoria categoria)
        {
            return new CategoriaDados().list(categoria);         
        }

        public void update(Categoria categoria)
        {
            new CategoriaDados().update(categoria);
        }
    }
}
