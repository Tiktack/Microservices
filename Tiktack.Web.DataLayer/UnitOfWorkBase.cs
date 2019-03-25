using System;
using Tiktack.Web.DataLayer.Entities;

namespace Tiktack.Web.DataLayer
{
    public class UnitOfWorkBase : IUnitOfWork, IDisposable
    {
        private readonly BaseDbContext _context;
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IGenericRepository<Comment> _commentRepository;
        private bool _disposed;

        public UnitOfWorkBase(BaseDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Post> PostRepository => _postRepository ?? new GenericRepository<Post>(_context);
        public IGenericRepository<Comment> CommentRepository => _commentRepository ?? new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) _context.Dispose();

            _disposed = true;
        }
    }
}
