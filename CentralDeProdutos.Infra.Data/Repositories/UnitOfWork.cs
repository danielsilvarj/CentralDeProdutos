﻿using CentralDeProdutos.Domain.Ports.Repositories;
using CentralDeProdutos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeProdutos.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(_dataContext);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_dataContext);

        public void BeginTransaction()
        {
            _transaction = _dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dataContext.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void Rollback()
        {
            _dataContext.Database.RollbackTransaction();
        }
    }
}
