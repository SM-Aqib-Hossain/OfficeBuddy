namespace UIPortal.Components.Models
{
    public class CoinTossDto
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string PlayerChoice { get; set; }

        public bool PlayerWin { get; set; }
    }
}
