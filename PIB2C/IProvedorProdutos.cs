using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    public interface IProvedorProdutos
    {
        List<Produto> ObterProdutos(string caminhoArquivo);
        event EventHandler<TotalLinhasEventArgs> TotalLinhasLido;
        event EventHandler ProdutoLido;
    }
}
