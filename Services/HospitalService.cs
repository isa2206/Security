using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repo;
        public HospitalService(IHospitalRepository repo)
        {
            _repo = repo;
        }
        public async Task<Hospital> CreateHospital(CreateHospitalDto dto)
        {
            var hospital = new Hospital
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Type = dto.Type
            };
            await _repo.Add(hospital);
            return hospital;
        }

        public async Task<IEnumerable<Hospital>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Hospital> GetOne(Guid id)
        {
            return await _repo.GetOne(id);
        }

        public async Task<Hospital?> UpdateHospital(UpdateHospitalDto dto)
        {
            var hospital = await _repo.GetOne(dto.Id);
            if (hospital == null) return null;


            if (dto.Name != null) hospital.Name = dto.Name;
            if (dto.Address != null) hospital.Address = dto.Address;
            if (dto.Type.HasValue) hospital.Type = dto.Type.Value;


            await _repo.Update(hospital);
            return hospital;
        }

        public async Task<bool> DeleteHospital(Guid id)
        {
            var hospital = await _repo.GetOne(id);
            if (hospital == null) return false;

            await _repo.Delete(hospital);
            return true;
        }

        public async Task<IEnumerable<Hospital>> GetAllByTypes(IEnumerable<int> types)
        {
            return await _repo.GetAllByTypes(types);
        }
    }
}