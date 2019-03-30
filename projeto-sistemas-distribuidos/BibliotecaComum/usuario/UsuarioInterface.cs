using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.usuario
{
    interface UsuarioInterface
    {
        void Create(Usuario usuario);
        void Remove(Usuario usuario);
        void Update(Usuario usuario);
        List<Usuario> Detail(Usuario filtro);
    }
}
