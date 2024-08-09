using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using SistemaIndexador.Infra.CrossCutting.Logging.Model;

namespace SistemaIndexador.Infra.CrossCutting.Logging.Helpers
{
    public interface ILogAuditoria : IDisposable
    {
        void RegistrarLog(ActionExecutedContext filterContext);
        IEnumerable<Auditoria> ObterLogs();
        IEnumerable<Auditoria> Buscar(Expression<Func<Auditoria, bool>> predicate);
    }
}