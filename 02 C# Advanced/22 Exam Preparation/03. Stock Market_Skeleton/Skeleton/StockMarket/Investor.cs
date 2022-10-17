namespace StockMarket
{
    using System.Collections.Generic;
    using System.Text;

    public class Investor
    {
        public Dictionary<string, Stock> Portfolio { get; set; }

        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public string FullName { get { return fullName; } set { fullName = value; } }
        public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
        public decimal MoneyToInvest { get { return moneyToInvest; } set { moneyToInvest = value; } }
        public string BrokerName { get { return brokerName; } set { brokerName = value; } }

        public int Count { get { return this.Portfolio.Count; } }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new Dictionary<string, Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization > 10000.0M)
            {
                if (stock.PricePerShare <= this.MoneyToInvest)
                {
                    this.Portfolio.Add(stock.CompanyName, stock);
                    this.MoneyToInvest -= stock.PricePerShare;
                }
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            string ret = null;

            if (!this.Portfolio.ContainsKey(companyName))
            {
                ret = string.Format("{0} does not exist.", companyName);
            }
            else if(sellPrice < this.Portfolio[companyName].PricePerShare)
            {
                ret = string.Format("Cannot sell {0}.", companyName);
            }
            else
            {
                this.MoneyToInvest += sellPrice;
                this.Portfolio.Remove(companyName);
                ret = string.Format("{0} was sold.", companyName);
            }

            return ret;
        }

        public Stock FindStock(string companyName)
        {
            Stock ret = null;

            if(this.Portfolio.ContainsKey(companyName))
            {
                ret = this.Portfolio[companyName];
            }

            return ret;

        }

        public Stock FindBiggestCompany()
        {
            Stock ret = null;

            foreach(var v in this.Portfolio)
            {
                if(ret != null)
                {
                    if(v.Value.MarketCapitalization > ret.MarketCapitalization)
                    {
                        ret = v.Value;
                    }
                }
                else
                {
                    ret = v.Value;
                }
            }

            return ret;

        }

        public string InvestorInformation()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("The investor {0} with a broker {1} has stocks:", this.FullName, this.BrokerName));
            foreach(var v in this.Portfolio)
            {
                ret.AppendLine(v.Value.ToString());
            }

            return ret.ToString().Trim();

        }

    }
}
