using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaIndexador.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Adicionar(T obj);
        T ObterPorId(int? id);
        IEnumerable<T> ObterTodos();
        T Atualizar(T obj);
        void Remover(int id);
        void ExcluirExcel();
        void ObterPorCodigo();
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}