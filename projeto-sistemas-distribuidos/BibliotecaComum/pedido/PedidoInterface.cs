using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.pedido
{
    public interface PedidoInterface
    {
        void Create(Pedido pedido);
        void Remove(Pedido pedido);
        void Update(Pedido pedido);
        List <Pedido> Select(Pedido filtro);
    }
}
