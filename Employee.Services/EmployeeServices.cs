using EM.Domain.Model;
using EM.Domain.Services;
using EM.Domain.Services.Common;

namespace EM.Services
{
    public class EmployeeServices(IUnitOfWork unitOfWork, IDataServices<Employee> dataServices) : IEmployee
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDataServices<Employee> _dataServices = dataServices;

        // List all employees
        public async Task<IEnumerable<Employee>> ListEmployees()
        {
            try
            {
                // Fetch all employees
                return await _dataServices.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the list of employees.", ex);
            }
        }

        // Add a new employee
        public async Task AddEmployee(Employee entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Perform the operation - Adding the employee
                var addedEmployee = await _dataServices.Create(entity);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                try
                {
                    await _unitOfWork.RollbackTransactionAsync();
                }
                catch (Exception rollbackEx)
                {
                    // Log or handle the rollback exception if necessary
                    // Avoid throwing a rollback exception since the original exception is more critical
                    throw new ApplicationException("An error occurred during transaction rollback.", rollbackEx);
                }

                throw new ApplicationException("An error occurred while adding the employee.", ex);
            }
        }

        // Update an existing employee
        public async Task UpdateEmployee(Employee entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Fetch the existing employee
                var existingEmployee = await _dataServices.Get(entity.Id) ?? throw new KeyNotFoundException($"Employee with ID {entity.Id} not found.");

                // Update the existing employee with the new data
                existingEmployee.Name = entity.Name;
                existingEmployee.Dob = entity.Dob;
                existingEmployee.DistrictId = entity.DistrictId;

                // Update the employee in the data service
                await _dataServices.Update(existingEmployee);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while updating the employee.", ex);
            }
        }

        // Delete an employee
        public async Task<bool> DeleteEmployee(Employee entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Delete the employee
                var result = await _dataServices.Delete(entity.Id);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();

                return result;
            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while deleting the employee.", ex);
            }
        }
    }
}
