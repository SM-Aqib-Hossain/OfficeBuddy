using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Entities; 

namespace DataAccessLayer.Interfaces
{
    public interface ICoinTossRepository
    {
        Task<CoinToss> GetCoinTossByIdAsync(int id);
        Task<List<CoinToss>> GetAllCoinTossDataAsync();
        Task<CoinToss> AddCoinTossDataAsync(CoinToss coinToss);
        Task<CoinToss> UpdateCoinTossDataAsync(int id, CoinToss coinToss);
        Task DeleteCoinTossDataByIdAsync(int id);
    }
}
