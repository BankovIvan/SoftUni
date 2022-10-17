namespace StockMarket
{
    using System;
    using System.Text;

    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        //private decimal marketCapitalization;

        public string CompanyName { get { return companyName; } set { companyName = value; } }
        public string Director { get { return director; } set { director = value; } }
        public decimal PricePerShare { get { return pricePerShare; } set { pricePerShare = value; } }
        public int TotalNumberOfShares { get { return totalNumberOfShares; } set {  totalNumberOfShares = value; } }
        public decimal MarketCapitalization { get { return this.PricePerShare * (decimal)this.TotalNumberOfShares; } }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Company: {0}", this.CompanyName));
            ret.AppendLine(String.Format("Director: {0}", this.Director));
            ret.AppendLine(String.Format("Price per share: ${0}", this.PricePerShare));
            ret.Append(String.Format("Market capitalization: ${0}", this.MarketCapitalization));

            return ret.ToString().Trim();
        }

    }
}
