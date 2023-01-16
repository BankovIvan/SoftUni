namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> models;

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return models.AsReadOnly(); }
        }

        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }

        public void AddModel(IDelicacy model)
        {
            this.models.Add(model);
        }
    }
}
