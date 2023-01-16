namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> models;

        public IReadOnlyCollection<IBooth> Models
        {
            get { return models.AsReadOnly(); }
        }

        public BoothRepository()
        {
            models = new List<IBooth>();
        }

        public void AddModel(IBooth model)
        {
            this.models.Add(model);
        }
    }
}
