using System.Collections.Generic;

namespace BibliotecaComum.usuario
{
    interface UsuarioInterface
    {
        void CreateUsuario(Usuario usuario);
        void RemoveUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        List<Usuario> DetailUsuario(Usuario filtro);
    }
}
