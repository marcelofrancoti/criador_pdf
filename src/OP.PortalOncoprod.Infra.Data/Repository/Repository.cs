using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SistemaIndexador.Domain.Interfaces.Repository;
using SistemaIndexador.Infra.Data.Context;

namespace SistemaIndexador.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected PortalOncoprodContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(PortalOncoprodContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()//(int s, int t)
        {
            return DbSet.ToList(); //Take(t).Skip(s).ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ExcluirExcel()
        {
            throw new NotImplementedException();
        }

        public void ObterPorCodigo()
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(int? id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            {

                var teste = ex;

                throw;
            }
         
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}