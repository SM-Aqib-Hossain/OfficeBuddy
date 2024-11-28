using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
namespace BusinessLogicLayer
{
    public class CoinTossService : ICoinTossService
    {
        private readonly ICoinTossRepository _coinTossRepository;
        public CoinTossService(ICoinTossRepository coinTossRepository)
        {
            _coinTossRepository = coinTossRepository;
        }

        public async Task<CoinToss> AddCoinTossDataAsync(CoinToss coinToss)
        {
            return await _coinTossRepository.AddCoinTossDataAsync(coinToss);

        }

        public async Task DeleteCoinTossDataByIdAsync(int id)
        {
             await _coinTossRepository.DeleteCoinTossDataByIdAsync(id);
        }

        public async Task<List<CoinToss>> GetAllCoinTossDataAsync()
        {
            return await _coinTossRepository.GetAllCoinTossDataAsync();
        }

        public async Task<CoinToss> GetCoinTossByIdAsync(int id)
        {
            return await _coinTossRepository.GetCoinTossByIdAsync(id);
        }

        public async Task<CoinToss> UpdateCoinTossDataAsync(int id, CoinToss coinToss)
        {
            return await _coinTossRepository.UpdateCoinTossDataAsync(id, coinToss);
        }
    }
}
