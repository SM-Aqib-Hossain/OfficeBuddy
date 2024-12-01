using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    internal class CoinToss
    {
        public int Id { get; set; }
        public string playerId { get; set; }
        public string playerChoice { get; set; }
        public string computerResult { get; set; }
        public bool playerWin { get; set; }
    }
}
