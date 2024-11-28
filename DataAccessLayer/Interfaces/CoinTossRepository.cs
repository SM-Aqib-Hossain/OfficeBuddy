using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class CoinTossRepository : ICoinTossRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoinTossRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CoinToss> AddCoinTossDataAsync(CoinToss coinToss)
        {
            _dbContext.CoinTosses.Add(coinToss);
            await _dbContext.SaveChangesAsync();
            return coinToss;
        }

        public async Task DeleteCoinTossDataByIdAsync(int id)
        {
            var coinToss = await _dbContext.CoinTosses.FindAsync(id);
            if (coinToss != null)
            {
                _dbContext.CoinTosses.Remove(coinToss);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("CoinToss Not found ");
            }
        }

        public async Task<List<CoinToss>> GetAllCoinTossDataAsync()
        {
            return await _dbContext.CoinTosses.ToListAsync();
        }

        public async Task<CoinToss> GetCoinTossByIdAsync(int id)
        {
            var coinToss = await _dbContext.CoinTosses.FindAsync(id);
            return coinToss;
        }

        public async Task<CoinToss> UpdateCoinTossDataAsync(int id, CoinToss coinToss)
        {
            var coinToss_var = await _dbContext.CoinTosses.FindAsync(id);
            if (coinToss != null)
            {
                coinToss_var.PlayerId = coinToss.PlayerId;
                coinToss_var.PlayerChoice = coinToss.PlayerChoice;
                
                coinToss_var.PlayerWin = coinToss.PlayerWin;
                await _dbContext.SaveChangesAsync();
                return coinToss_var;
            }
            else
            {
                throw new KeyNotFoundException("CoinToss Not found ");
            }
        }
    }
}
