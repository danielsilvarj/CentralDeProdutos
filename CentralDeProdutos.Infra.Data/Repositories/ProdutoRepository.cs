using CentralDeProdutos.Domain.Models;
using CentralDeProdutos.Domain.Ports.Repositories;
using CentralDeProdutos.Infra.Data.Contexts;
using CentralDeProdutos.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProdutoRepository : BaseRepository<Produto, Guid>, IProdutoRepository
{
    private readonly DataContext? _dataContext;

    public ProdutoRepository(DataContext? dataContext)
        : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Produto> GetByCategoria(Guid categoriaId)
    {
        return _dataContext.Produtos
            .Where(p => p.CategoriaId == categoriaId)
            .ToList();
    }
}




