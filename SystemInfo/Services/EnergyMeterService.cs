using SystemInfo.Models;
using SystemInfo.Repositories;

namespace SystemInfo.Services
{
    // create interface
    public interface IEnergyMeterServiceRepository
    {
        Task<List<EnergyMeter>> GetAll();
        Task<EnergyMeter> GetEnergyMeter(int id);
        Task<EnergyMeter> Create(EnergyMeter energyMeter);
        Task<EnergyMeter> Update(EnergyMeter energyMeter);
        Task<EnergyMeter> DeleteEnergyMeter(int id);
    }
    public class EnergyMeterService: IEnergyMeterServiceRepository
    {
        public readonly EnergyMeterRepository _energyMeterRepository;

        public EnergyMeterService(EnergyMeterRepository energyMeterRepository)
        {
            _energyMeterRepository = energyMeterRepository;
        }

        public async Task<EnergyMeter> Create(EnergyMeter energyMeter)
        {
            EnergyMeter newEnergyMeter = new EnergyMeter
            {
                EnergyMeterBrand = energyMeter.EnergyMeterBrand,
                InstalationDate = energyMeter.InstalationDate,

            };
            return await _energyMeterRepository.Create(newEnergyMeter);
        }

        public async Task<EnergyMeter> DeleteEnergyMeter(int id)
        {
            EnergyMeter newEnergyMeter = await GetEnergyMeter(id);
            return await _energyMeterRepository.DeleteEnergyMeter(newEnergyMeter);
        }

        public async Task<List<EnergyMeter>> GetAll()
        {
            return await _energyMeterRepository.GetAll();
        }

        public async Task<EnergyMeter> GetEnergyMeter(int id)
        {
            return await _energyMeterRepository.GetEnergyMeter(id);
        }

        public async Task<EnergyMeter> Update(EnergyMeter energyMeter)
        {
            EnergyMeter newEnergyMeter = await GetEnergyMeter(energyMeter.EnergyMeterId);
            if (newEnergyMeter != null)
            {
                if (energyMeter.EnergyMeterBrand != null)
                {
                    newEnergyMeter.EnergyMeterBrand = energyMeter.EnergyMeterBrand;
                }
                if (energyMeter.InstalationDate != null)
                {
                    newEnergyMeter.InstalationDate = (DateTime)energyMeter.InstalationDate;
                }


                return await _energyMeterRepository.Update(newEnergyMeter);
            }
            throw new NotImplementedException();
          
        }
    }
}
