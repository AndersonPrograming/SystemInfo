using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IEnergyMeterService
    {
        Task<List<EnergyMeter>> GetAll();
        Task<EnergyMeter> GetEnergyMeter(int? id);
        Task<EnergyMeter> Create(string energyMeterBrand, DateTime instalationDate);
        Task<EnergyMeter> Update(int id, string energyMeterBrand, DateTime instalationDate);
        Task<EnergyMeter> DeleteEnergyMeter(int id);
    }
    public class EnergyMeterService: IEnergyMeterService
    {
        public readonly IEnergyMeterRepository _energyMeterRepository;

        public EnergyMeterService(IEnergyMeterRepository energyMeterRepository)
        {
            _energyMeterRepository = energyMeterRepository;
        }

        public async Task<EnergyMeter> Create(string energyMeterBrand, DateTime instalationDate)
        {
            return await _energyMeterRepository.Create(energyMeterBrand, instalationDate);
        }

        public async Task<EnergyMeter> DeleteEnergyMeter(int id)
        {
            return await _energyMeterRepository.DeleteEnergyMeter(id);
        }

        public async Task<List<EnergyMeter>> GetAll()
        {
            return await _energyMeterRepository.GetAll();
        }

        public async Task<EnergyMeter> GetEnergyMeter(int? id)
        {
            return await _energyMeterRepository.GetEnergyMeter(id);
        }

        public async Task<EnergyMeter> Update(int id, string energyMeterBrand, DateTime instalationDate)
        {

            return await _energyMeterRepository.Update(id, energyMeterBrand, instalationDate);
            throw new NotImplementedException();
          
        }
    }
}
