using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext context) : base(context)
        {

        }
        public IList<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }
        public Categoria GetCategoria(string NomeCategoria)
        {
            return dbSet.Where(c => c.Nome == NomeCategoria).First();
        }
        public async Task SalvarCategoria(string nomeCategoria)
        {
            dbSet.Add(new Categoria { Nome = nomeCategoria });
            await contexto.SaveChangesAsync();

        }
        public bool CategoriaJaExiste(string nomeCategoria)
        {
            return dbSet.Where(c => c.Nome == nomeCategoria).Any();
        }
    }
}
