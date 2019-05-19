using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.itens_pedido
{
    public interface ItensPedidoInterface
    {
        void Insert(ItensPedido itensPedido);
        void Update(ItensPedido itensPedido);
        void Delete(ItensPedido itensPedido);
        List<ItensPedido> Select(ItensPedido filtro);
    }
}