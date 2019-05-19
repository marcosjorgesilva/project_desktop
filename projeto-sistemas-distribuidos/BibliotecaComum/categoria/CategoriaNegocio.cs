using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.categoria
{
   public class CategoriaNegocio : CategoriaInterface
    {
        public void createCategory(Categoria categoria)
        {
            //Verifica se há tipo de categoria informada.
            isNull(categoria);

            //Verifica se possui algum caractere especial no tipo de categoria informado.
            isEspecialCaracter(categoria);

            new CategoriaDados().insert(categoria);
        }

        #region métodos trazidos da interface
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
        #endregion

        #region metodos de validação dos dados.
        private static bool isNull(Categoria categoria)
        {
            if (String.IsNullOrEmpty(categoria.TipoCategoria))
            {
                throw new Exception("Tipo de categoria não informado!");
            }
            return true;
        }       
        
        private static bool isEspecialCaracter(Categoria categoria)
        {
            string[] simbolosNom =  {"!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "+", "=", "'", "/", ".",
                                     ",", "|", "<", ">", ":", ";", "?", "~", "^", "´", "`", "_", "[", "]", "{",
                                     "}", "ª", "º", "°", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\\"};
            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (categoria.TipoCategoria.Contains(simbolosNom[i]))
                    throw new Exception("Nome do usuário não pode conter numeros e/ou caracteres especiais!");
            }
            return true;
        }
        #endregion

    }
}
