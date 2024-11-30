using EM.Domain.Services.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace EM.EF.Services
{
    public class UnitOfWork(EMDBContext context) : IUnitOfWork, IDisposable
    {
        private readonly EMDBContext _context = context;
        private IDbContextTransaction? _transaction;

        // Begin a new database transaction
        public IDbContextTransaction BeginTransaction()
        {
            // If there's already an ongoing transaction, throw an exception
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            // Begin a new transaction
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }

        // Commit changes to the database
        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_transaction == null)
                    throw new InvalidOperationException("No transaction in progress.");

                // Save changes before committing
                await _context.SaveChangesAsync();  // This is where the changes are saved to the database

                // Commit the transaction
                await _transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new InvalidOperationException("An error occurred while saving changes.", ex);
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        // Rollback the transaction
        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        // Dispose of the transaction when done
        public void Dispose()
        {
            _transaction?.Dispose();
            GC.SuppressFinalize(this); // Suppress finalization if done correctly
        }
    }
}
