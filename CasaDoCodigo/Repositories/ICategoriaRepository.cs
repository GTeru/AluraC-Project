using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria GetCategoria(string NomeCategoria);
        IList<Categoria> GetCategorias();
        Task SalvarCategoria(string nomeCategoria);
        bool CategoriaJaExiste(string nomeCategoria);
    }
}
