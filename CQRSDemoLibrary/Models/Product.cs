namespace CQRSDemoLibrary.Models
{
    public class Product
    {
        private static decimal _euroExchangeRate { get; set; } = 99.99m;
        public string Name { get; set; } = "";
        public decimal PriceInPounds { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.MinValue;

        public decimal? PriceInEuros
        {
            get
            {
                return Math.Round(PriceInPounds * _euroExchangeRate, 2);
            }
        }

        public static void SetEuroExchangeRate(Decimal rate)
        {
            _euroExchangeRate = rate;
        }
    }
}