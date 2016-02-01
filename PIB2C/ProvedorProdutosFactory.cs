using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    public class ProvedorProdutosFactory
    {
        public static IProvedorProdutos CreateProvedor()
        {
            //return new ProvedorProdutosRamdom();
            return new ProvedorProdutosCSV();
        }
    }
}
