namespace ChristmasPastryShop.Repositories
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> models;

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return models.AsReadOnly(); }
        }

        public CocktailRepository()
        {
            models = new List<ICocktail>();
        }

        public void AddModel(ICocktail model)
        {
            this.models.Add(model);
        }

    }
}
