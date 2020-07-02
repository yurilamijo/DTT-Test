using System;
using DTT_Test.Models;

namespace DTT_Test.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private DTTContext _context = new DTTContext();
        private ArticleRepository articleRepository;

        public ArticleRepository ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(_context);
                }
                return articleRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
