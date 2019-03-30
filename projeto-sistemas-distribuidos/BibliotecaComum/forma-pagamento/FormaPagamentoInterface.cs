using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.forma_pagamento
{
    public interface FormaPagamentoInterface
    {
        void Insert(FormaPagamento formaPagamento);
        void Update(FormaPagamento formaPagamento);
        void Delete(FormaPagamento formaPagamento);
        List<FormaPagamento> Select(FormaPagamento filtro);
    }
}
