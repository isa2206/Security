using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task<Hospital> GetOne(Guid id);
        Task<Hospital> CreateHospital(CreateHospitalDto dto);

        Task<Hospital?> UpdateHospital(UpdateHospitalDto dto);
        Task<bool> DeleteHospital(Guid id);
        Task<IEnumerable<Hospital>> GetAllByTypes(IEnumerable<int> types);
    }
}