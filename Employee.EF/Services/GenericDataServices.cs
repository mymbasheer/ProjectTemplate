using EM.Domain.Services.Common;
using EM.EF;
using EM.EF.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericDataServices<T> : IDataServices<T> where T : class
{
    private readonly EMDBContext _context;

    public GenericDataServices(EMDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<T> Create(T entity)
    {
        try
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }
        catch (Exception ex)
        {
            // Handle or log exception as necessary
            throw new DataAccessException("An error occurred while creating the entity.", ex);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            T? entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
            _context.Set<T>().Remove(entity);  // Stage the delete
            return true;  // Return true, changes will be saved later
        }
        catch (Exception ex)
        {
            throw new DataAccessException($"An error occurred while deleting the entity with ID {id}.", ex);
        }

    }

    public async Task<T> Get(int id)
    {
        try
        {
            var entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
            return entity;  // Return the entity, but don't save anything yet
        }
        catch (Exception ex)
        {
            throw new DataAccessException($"An error occurred while retrieving the entity with ID {id}.", ex);
        }

    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> match)
    {
        try
        {
            return _context.Set<T>().Where(match);  // Retrieve data, no need for saving yet
        }
        catch (Exception ex)
        {
            throw new DataAccessException("An error occurred while retrieving filtered data.", ex);
        }
    }

    public async Task<ICollection<T>> GetAll()
    {
        try
        {
            return await _context.Set<T>().ToListAsync();  // Get all data, but no saving yet
        }
        catch (Exception ex)
        {
            throw new DataAccessException("An error occurred while retrieving all data.", ex);
        }
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            var existingEntity = await _context.Set<T>().FindAsync(entity) ?? throw new KeyNotFoundException("Entity to update not found.");
            _context.Set<T>().Update(entity);  // Stage the update
            return entity;  // Return the updated entity without saving immediately
        }
        catch (Exception ex)
        {
            throw new DataAccessException("An error occurred while updating the entity.", ex);
        }
    }
}
