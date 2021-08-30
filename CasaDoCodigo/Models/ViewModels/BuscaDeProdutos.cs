using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutos
    {
        public Dictionary<Categoria, IList<Produto>> ProdutosPorCategoria;
        public string TextoPesquisa;
        public BuscaDeProdutos(IList<Produto> produtos, string textoPesquisa)
        {
            ProdutosPorCategoria = new Dictionary<Categoria, IList<Produto>>();
            TextoPesquisa = textoPesquisa;
            foreach (var produto in produtos)
            {
                if (ProdutosPorCategoria.ContainsKey(produto.Categoria))
                {
                    ProdutosPorCategoria[produto.Categoria].Add(produto);
                }
                else
                {
                    var novaCategoria = new List<Produto>();
                    novaCategoria.Add(produto);
                    ProdutosPorCategoria.Add(produto.Categoria, novaCategoria);
                }
            }
        }
    }
}
