using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaComum.forma_pagamento
{
    public class FormaPagamentoNegocio : FormaPagamentoInterface
    {
        FormaPagamentoDados formaPagamentoDados = new FormaPagamentoDados();
        public void Delete(FormaPagamento formaPagamento)
        {
            formaPagamentoDados.Delete(formaPagamento);
        }

        public void Insert(FormaPagamento formaPagamento)
        {
            

        }

        public List<FormaPagamento> Select(FormaPagamento filtro)
        {
           return formaPagamentoDados.Select(filtro);

        }

        public void Update(FormaPagamento formaPagamento)
        {
            

        }
    }
}
