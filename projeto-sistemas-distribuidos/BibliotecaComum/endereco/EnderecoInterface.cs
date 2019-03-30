using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.endereco
{
    interface EnderecoInterface
    {
        void Create(Endereco endereco);
        void Remove(Endereco endereco);
        void Update(Endereco endereco);
        List<Endereco> Detail(Endereco endereco);

    }
}
