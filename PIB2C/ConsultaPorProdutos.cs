using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    class ConsultaPorProdutos : IEqualityComparer<Perfil>
    {
        public bool Equals(Perfil x, Perfil y)
        {
            return x.Produtos.Intersect(y.Produtos, new ConsultaPorNome()).Count() == 3;
        }

        public int GetHashCode(Perfil obj)
        {
            return String.Join("|", obj.Produtos.Select(p => p.Nome).ToArray()).GetHashCode();
        }
    }
}
