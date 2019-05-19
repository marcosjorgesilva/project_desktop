using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.itens_pedido
{
    class ItensPedidoNegocio : ItensPedidoInterface
    {
        public void Delete(ItensPedido itensPedido)
        {
            new ItensPedidoDados().Delete(itensPedido);
        }

        public void Insert(ItensPedido itensPedido)
        {
            new ItensPedidoDados().Insert(itensPedido);
        }

        public List<ItensPedido> Select(ItensPedido filtro)
        {
            return new ItensPedidoDados().Select(filtro);
        }

        public void Update(ItensPedido itensPedido)
        {
            new ItensPedidoDados().Update(itensPedido);
        }
    }
}