using EM.Domain.Model;
using EM.Domain.Services;
using EM.Domain.Services.Common;

namespace EM.Services
{
    public class DistrictServices(IUnitOfWork unitOfWork, IDataServices<District> dataServices) : IDistrict
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDataServices<District> _dataServices = dataServices;

        // Add a new district and handle the transaction
        public async Task AddDistrict(District entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Perform the operation - Adding
                await _dataServices.Create(entity);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while creating the district.", ex);
            }
        }

        // Delete a district
        public async Task<bool> DeleteDistrict(District entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Delete the district
                var result = await _dataServices.Delete(entity.ID);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();
                return result;
            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while deleting the district.", ex);
            }
        }

        // List all districts
        public async Task<IEnumerable<District>> ListDistricts()
        {
            try
            {
                return await _dataServices.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the list of districts.", ex);
            }
        }

        // Update an existing district
        public async Task UpdateDistrict(District entity)
        {
            try
            {
                // Start the transaction
                _unitOfWork.BeginTransaction();

                // Fetch the existing district
                var existingDistrict = await _dataServices.Get(entity.ID) ?? throw new KeyNotFoundException($"District with ID {entity.ID} not found.");

                // Update the existing district with the new data
                existingDistrict.Name = entity.Name;  // Update Name (add more fields if needed)
                // You can update other properties as needed

                // Update the district in the data service
                await _dataServices.Update(existingDistrict);

                // Commit the transaction after the operation
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                // If something goes wrong, rollback the transaction
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while updating the district.", ex);
            }
        }
    }
}
