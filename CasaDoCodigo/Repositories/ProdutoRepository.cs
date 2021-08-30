using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private ICategoriaRepository _categoriaRepository;
        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.Include(p => p.Categoria).ToList();
        }
        public async Task<IList<Produto>> GetProdutos(string TextoPesquisa)
        {
            if (TextoPesquisa == null)
            {
                TextoPesquisa = "";
            }
            return await dbSet
                    .Include(p => p.Categoria)
                    .Where(p => p.Nome.Contains(TextoPesquisa) || p.Categoria.Nome.Contains(TextoPesquisa))
                    .ToListAsync();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!_categoriaRepository.CategoriaJaExiste(livro.Categoria))
                {
                    await _categoriaRepository.SalvarCategoria(livro.Categoria);
                }
                Categoria categoria = _categoriaRepository.GetCategoria(livro.Categoria);

                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, categoria, livro.Preco));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
