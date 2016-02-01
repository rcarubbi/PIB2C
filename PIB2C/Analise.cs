using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PIB2C
{
    public class Par
    {
        public Perfil P1 { get; set; }
        public Perfil P2 { get; set; }
    }

    public class PesquisaPorCodPedido : IEqualityComparer<Produto>
    {
        public bool Equals(Produto x, Produto y)
        {
            return x.CodPedido == y.CodPedido;
        }

        public int GetHashCode(Produto obj)
        {
            return obj.CodPedido.GetHashCode();
        }
    }

    public class Analise
    {

        decimal bestScore = 0;
        protected List<Perfil> _cromossomos;
        protected List<Produto> _dadosBrutos;
        protected int qtdTotalPedidos;

        public event EventHandler EtapaConcluida;
        public event EventHandler<BestScoreEventArgs> BestScoreBeated;
        int countSame = 0;
        int quantidadeInicialPerfis = 0;
        public List<Perfil> Run(List<Produto> produtos)
        {
            _dadosBrutos = produtos;

            _cromossomos = CriarPerfis(produtos);

            quantidadeInicialPerfis = _cromossomos.Count;

            if (EtapaConcluida != null)
                EtapaConcluida(this, EventArgs.Empty);

            // G0
            qtdTotalPedidos = produtos.Select(p => p.CodPedido).Distinct().Count();

            GerarNovaGeracao();
            
            do
            {
                if (_cromossomos.Count < 2)
                {
                    break;
                }
                

                if (EtapaConcluida != null)
                    EtapaConcluida(this, EventArgs.Empty);

                var pais = SelecaoNatural();
                if (EtapaConcluida != null)
                    EtapaConcluida(this, EventArgs.Empty);

               

                var filhinhos = Crossover(pais.P1, pais.P2);

                if (EtapaConcluida != null)
                    EtapaConcluida(this, EventArgs.Empty);


                var paisMutados = Mutacao(pais.P1, pais.P2);
                if (EtapaConcluida != null)
                    EtapaConcluida(this, EventArgs.Empty);

                _cromossomos.Add(paisMutados.P1);
                _cromossomos.Add(paisMutados.P2);



                GerarNovaGeracao();
              

                countSame++;

            } while (countSame < 150);

            return _cromossomos;
        }

        private Par Crossover(Perfil pai, Perfil mae)
        {
            Perfil filho1 = new Perfil();
            Perfil filho2 = new Perfil();

            filho1.AdicionarProduto(pai.Produtos[0]);
            filho1.AdicionarProduto(mae.Produtos[1]);
            filho1.AdicionarProduto(pai.Produtos[2]);

            filho2.AdicionarProduto(mae.Produtos[0]);
            filho2.AdicionarProduto(pai.Produtos[1]);
            filho2.AdicionarProduto(mae.Produtos[2]);

            return new Par
            {
                P1 = filho1,
                P2 = filho2
            };

        }

        private Par Mutacao(Perfil pai, Perfil mae)
        {
            Produto produtoAleatorio1, produtoAleatorio2;
            Random rnd = new Random();

            do
            {
                var indice1 = rnd.Next(_dadosBrutos.Count - 1);

                produtoAleatorio1 = _dadosBrutos[indice1];



            } while (produtoAleatorio1.Nome == pai.Produtos[0].Nome && produtoAleatorio1.Nome == pai.Produtos[2].Nome);


            do
            {
                var indice2 = rnd.Next(_dadosBrutos.Count - 1);
                produtoAleatorio2 = _dadosBrutos[indice2];
            } while (produtoAleatorio2.Nome == mae.Produtos[0].Nome && produtoAleatorio2.Nome == mae.Produtos[2].Nome);

            Perfil filho3 = new Perfil();
            filho3.AdicionarProduto(pai.Produtos[0]);
            filho3.AdicionarProduto(produtoAleatorio1);
            filho3.AdicionarProduto(pai.Produtos[2]);

            Perfil filho4 = new Perfil();
            filho4.AdicionarProduto(mae.Produtos[0]);
            filho4.AdicionarProduto(produtoAleatorio2);
            filho4.AdicionarProduto(mae.Produtos[2]);

            return new Par
            {
                P1 = filho3,
                P2 = filho4
            };
        }

        private Par SelecaoNatural()
        {
            if (_cromossomos.Count > 1)
            {
                return new Par
                {
                    P1 = _cromossomos[0],
                    P2 = _cromossomos[1]
                };
            }
            else
                return null;

        }

        private void GerarNovaGeracao()
        {

            // selecao de acordo com a nota obtida a partir da consulta dos cromossomos na planilha



            foreach (var cromossomo in _cromossomos)
            {
                cromossomo.Nota = CalcularNota(cromossomo.Produtos, qtdTotalPedidos);
            }

            // ordenar por nota
            _cromossomos = _cromossomos.OrderByDescending(c => c.Nota).ToList();
            // filtrar dois tercos

            var score = _cromossomos.First().Nota;
            if (score > bestScore)
            {
                bestScore = score;

                if (BestScoreBeated != null)
                {
                    BestScoreBeated(this, new BestScoreEventArgs { NewRecord = bestScore });
                }
                countSame = 0;
            }

            _cromossomos = _cromossomos.Where(c => c.Nota > 0).Distinct(new ConsultaPorProdutos()).Take(quantidadeInicialPerfis).ToList();
        }

        

        private decimal CalcularNota(List<Produto> produtos, int qtdTotalPedidos)
        {



            var produto1 = produtos[0];
            var produto2 = produtos[1];
            var produto3 = produtos[2];
            
            if (produto1.Nome == produto2.Nome ||
                produto1.Nome == produto3.Nome ||
                produto2.Nome == produto3.Nome)
            {
                return 0;
            }


          
            var query1 = from result1 in _dadosBrutos
                         where result1.Nome == produto1.Nome
                         select result1;

            var query2 = from result2 in _dadosBrutos
                         where result2.Nome == produto2.Nome
                         select result2;

            var query3 = from result3 in _dadosBrutos
                         where result3.Nome == produto3.Nome
                         select result3;



            var produtos1e2 = query1.Intersect(query2, new PesquisaPorCodPedido());

            var produtosEncontrados = produtos1e2.Intersect(query3, new PesquisaPorCodPedido());

            var totalPedidosEncontrados = produtosEncontrados.Select(p => p.CodPedido).Distinct().Count();

            return Convert.ToDecimal(totalPedidosEncontrados * 100) / Convert.ToDecimal(qtdTotalPedidos);
        }

        #region Criação de Perfis

        private List<Perfil> CriarPerfis(List<Produto> produtos)
        {
            int indiceElementoInicial = 0;

            List<Perfil> perfis = new List<Perfil>();

            var produtosDistinct = produtos.Distinct(new ConsultaPorNome()).ToList();

            var produtosCount = from p in produtosDistinct
                        select new { Produto = p, Count = produtos.Count(pr => pr.Nome == p.Nome) };


            var top10 = (from p in produtosCount
                        orderby p.Count descending
                            select p.Produto).Take(10);



            foreach (var produto in top10)
            {
                List<Produto> produtosRemanescentes = AllExcept(top10.ToList(), indiceElementoInicial);

                foreach (Perfil perfil in Permutar(produtosRemanescentes, 2))
                {
                    var produtosAAdicionar = Concatenar(produto, perfil);
                    if (!perfis.Any(p => p.Produtos.Intersect(produtosAAdicionar.Produtos, new ConsultaPorNome()).Count() == 3))
                        perfis.Add(produtosAAdicionar);
                }
                indiceElementoInicial++;
            }

            return perfis.Distinct(new ConsultaPorProdutos()).ToList();
        }


        private IEnumerable<Perfil> Permutar(List<Produto> produtos, int count)
        {

            if (count > 0)
            {

                int indiceElementoInicial = 0;
                foreach (var produto in produtos)
                {
                    List<Produto> produtosRemanescentes = AllExcept(produtos, indiceElementoInicial);

                    foreach (var permutacaoRemanescentes in Permutar(produtosRemanescentes, count - 1))
                    {
                        yield return Concatenar(produto, permutacaoRemanescentes);
                    }
                    indiceElementoInicial++;
                }
            }
            else
            {
                yield return new Perfil();
            }
        }

        private Perfil Concatenar(Produto produto, Perfil permutacaoRemanescentes)
        {
            Perfil retorno = new Perfil();

            retorno.AdicionarProduto(produto);

            foreach (var item in permutacaoRemanescentes.Produtos)
            {
                retorno.AdicionarProduto(item);
            }

            
            return retorno;
        }

        private List<Produto> AllExcept(List<Produto> produtos, int indiceElementoInicial)
        {
            List<Produto> produtosRetorno = new List<Produto>();
            int index = 0;
            foreach (var produto in produtos)
            {
                if (index != indiceElementoInicial)
                {
                    produtosRetorno.Add(produto);
                }
                index++;
            }

            return produtosRetorno;
        }

        #endregion

    }
}
