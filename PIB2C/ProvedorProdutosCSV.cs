using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace PIB2C
{
    public class ProvedorProdutosCSV : IProvedorProdutos
    {

        private static Produto ParseProduto(string[] campos)
        {
            return new Produto
            {
                CodPedido = campos[0].ToString(),
                Nome = campos[1].ToString(),
                Categoria = campos[2].ToString()
            };
        }



        public List<Produto> ObterProdutos(string caminhoArquivo)
        {
            List<Produto> produtos = new List<Produto>();
            var linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("ISO-8859-1"));

            if (TotalLinhasLido != null)
                TotalLinhasLido(this, new TotalLinhasEventArgs { TotalLinhas = linhas.Length });
            var cabecalhoLido = false;
            foreach (var linha in linhas)
            {
                if (!cabecalhoLido)
                {
                    cabecalhoLido = true;
                    continue;
                }
                var campos = linha.Split(';');
                produtos.Add(ParseProduto(campos));
                if (ProdutoLido != null)
                    ProdutoLido(this, EventArgs.Empty);
            }

            return produtos;
        }


        public event EventHandler ProdutoLido;


        public event EventHandler<TotalLinhasEventArgs> TotalLinhasLido;
    }
}

