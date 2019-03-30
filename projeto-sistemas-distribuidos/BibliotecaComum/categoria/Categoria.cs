using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.categoria
{
    public class Categoria
    {
        private int idCategoria;
        private string tipoCategoria;

        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string TipoCategoria { get => tipoCategoria; set => tipoCategoria = value; }
    }
}
