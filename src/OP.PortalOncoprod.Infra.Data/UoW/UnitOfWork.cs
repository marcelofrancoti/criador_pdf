﻿using System;
using SistemaIndexador.Infra.Data.Context;
using SistemaIndexador.Infra.Data.Interfaces;

namespace SistemaIndexador.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalOncoprodContext _context;
        private bool _disposed;

        public UnitOfWork(PortalOncoprodContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}