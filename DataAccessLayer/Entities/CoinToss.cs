﻿namespace DataAccessLayer.Entities
{
    public class CoinToss 
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string PlayerChoice { get; set; }

        public bool PlayerWin { get; set; }
    }
}
