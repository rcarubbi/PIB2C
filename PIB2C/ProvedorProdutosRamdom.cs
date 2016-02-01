using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    public class ProvedorProdutosRamdom : IProvedorProdutos
    {
        private List<Produto> ObterProdutos()
        {
            var produtos = new List<Produto>();

            var qtdProdutos = 7;
            var qtdPedidos = 10000;

            if (TotalLinhasLido != null)
                TotalLinhasLido(this, new TotalLinhasEventArgs { TotalLinhas = qtdPedidos });

            Random rnd = new Random();

            for (int i = 0; i < qtdPedidos; i++)
            {

                var indiceProduto1 = rnd.Next(qtdProdutos - 1);
                Produto p1 = new Produto() { CodPedido = (i + 1).ToString(), Categoria = "Teste", Nome = string.Format("Produto {0}", indiceProduto1 + 1) };
                produtos.Add(p1);
                if (ProdutoLido != null)
                    ProdutoLido(this, EventArgs.Empty);
                int indiceProduto2 = 0;

                Produto p2 = null;

                do
                {
                    indiceProduto2 = rnd.Next(qtdProdutos - 1);
                    p2 = new Produto() { CodPedido = (i + 1).ToString(), Categoria = "Teste", Nome = string.Format("Produto {0}", indiceProduto2 + 1) };

                } while (indiceProduto2 == indiceProduto1);

                produtos.Add(p2);
                if (ProdutoLido != null)
                    ProdutoLido(this, EventArgs.Empty);
                int indiceProduto3 = 0;

                Produto p3 = null;

                do
                {
                    indiceProduto3 = rnd.Next(qtdProdutos - 1);
                    p3 = new Produto() { CodPedido = (i + 1).ToString(), Categoria = "Teste", Nome = string.Format("Produto {0}", indiceProduto3 + 1) };
                } while (indiceProduto1 == indiceProduto3 || indiceProduto2 == indiceProduto3);

                produtos.Add(p3);
                if (ProdutoLido != null)
                    ProdutoLido(this, EventArgs.Empty);
            }

            return produtos;
        }

        public List<Produto> ObterProdutos(string caminhoArquivo)
        {
            return ObterProdutos();
        }


        public event EventHandler ProdutoLido;


        public event EventHandler<TotalLinhasEventArgs> TotalLinhasLido;
    }
}
