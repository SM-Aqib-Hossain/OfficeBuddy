using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICoinTossService
    {
        Task<CoinToss> GetCoinTossByIdAsync(int id);
        Task<List<CoinToss>> GetAllCoinTossDataAsync();
        Task<CoinToss> AddCoinTossDataAsync(CoinToss coinToss);
        Task<CoinToss> UpdateCoinTossDataAsync(int id, CoinToss coinToss);
        Task DeleteCoinTossDataByIdAsync(int id);
    }
}
