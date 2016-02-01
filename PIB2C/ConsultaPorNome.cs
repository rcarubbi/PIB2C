using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    class ConsultaPorNome : IEqualityComparer<Produto>
    {
        public bool Equals(Produto x, Produto y)
        {
            return x.Nome == y.Nome;
        }

        public int GetHashCode(Produto obj)
        {
            return obj.Nome.GetHashCode();
        }
    }
}
