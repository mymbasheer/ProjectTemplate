using Microsoft.EntityFrameworkCore.Storage;

namespace EM.Domain.Services.Common
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
