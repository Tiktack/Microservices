using Tiktack.Web.DataLayer.Entities;

namespace Tiktack.Web.DataLayer
{
    public interface IUnitOfWork
    {
        IGenericRepository<Post> PostRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
    }
}
