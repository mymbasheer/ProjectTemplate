using EM.Domain.Model;

namespace EM.Domain.Services
{
    public interface IDistrict
    {
        Task<IEnumerable<District>> ListDistricts();
        Task AddDistrict(District entity);
        Task UpdateDistrict(District entity);
        Task<bool> DeleteDistrict(District entity);
    }
}
