using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.produto
{
    public class ProdutoNegocio : ProdutoInterface
    {

        public void createProduct(Produto produto)
        {
            //Formata o valor inserido
            formatValor(produto.ValorProduto);

            //Verifica se há algum campo não informado.
            isNullField(produto);

            //Verifica se possui algum caractere especial no nome de produto informado.
            isSpecialCaracter(produto);

            //Verifica se o valor digitado é valido.
            isValidValor(produto);

            //Verifica se o tamamnho inserido é valido
            isValidSize(produto);

            new ProdutoDados().insert(produto);
        }

        #region metodos de validação e formatação dos dados.
        private static bool isValidValor(Produto produto)
        {
            double valor = formatValor(produto.ValorProduto);
            if (valor.ToString().Trim() == "" || valor.ToString().Trim() == null || valor < 1)
            {
                throw new Exception("Valor não informado!");
            }
            return true;
        }

        private static bool isValidStock(Produto produto)
        {

            return true;
        }

        private static bool isValidSize(Produto produto)
        {
            string[] simbolosNom = { "P", "M", "G", "GG" };
            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (!produto.Tamanho.ToString().Trim().Contains(simbolosNom[i]))
                {
                    throw new Exception("Tamanho não valido!");
                }
            }
            return true;
        }

        private static bool isSpecialCaracter(Produto produto)
        {
            string[] simbolosNom =  {"!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "+", "=", "'", "/", ".",
                                     ",", "|", "<", ">", ":", ";", "?", "~", "^", "´", "`", "_", "[", "]", "{",
                                     "}", "ª", "º", "°", "\\"};
            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (produto.Nome.Contains(simbolosNom[i]))
                    throw new Exception("Nome do usuário não pode conter numeros e/ou caracteres especiais!");
            }
            return true;
        }

        private static bool isNullField(Produto produto)
        {
            if (String.IsNullOrEmpty(produto.Nome.Trim()))
            {
                throw new Exception("Nome não informado!");
            }
            if (String.IsNullOrEmpty(produto.Tamanho.ToString().Trim()))
            {
                throw new Exception("Tamanho não informado!");
            }
            if (String.IsNullOrEmpty(produto.Estoque.ToString().Trim()))
            {
                throw new Exception("Estoque não informado!");
            }
            if (String.IsNullOrEmpty(produto.ValorProduto.ToString().Trim()))
            {
                throw new Exception("Valor de Produto não informado!");
            }
            return true;
        }

        private static double formatValor(double valor)
        {
            try
            {
                string valorformatado;
                valorformatado = (String.Format("{0:0.00}", valor));
                return double.Parse(valorformatado);
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao converter o valor informado: ", e);
            }
        }
        #endregion

        #region metodos trazidos da interface
        public void delete(Produto produto)
        {
            new ProdutoDados().delete(produto);
        }

        public void insert(Produto produto)
        {
            throw new NotImplementedException();
        }

        public List<Produto> list(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void update(Produto produto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
