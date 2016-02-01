using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    public class Perfil
    {
        public List<Produto> Produtos { get; set; }

        public Perfil() 
        {
            Produtos = new List<Produto>(3);
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
            Produtos = Produtos.OrderBy(p => p.Nome).ToList();
        }

        public decimal Nota { get; set; }
    }
}
