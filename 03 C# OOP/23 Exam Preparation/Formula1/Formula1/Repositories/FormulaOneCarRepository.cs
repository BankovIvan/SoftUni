namespace Formula1.Repositories
{
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public IReadOnlyCollection<IFormulaOneCar> Models 
        {
            get { return models.AsReadOnly(); }
        }

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public void Add(IFormulaOneCar model)
        {
            //int index = models.FindIndex(x => x.Model == model.Model);
            //if(index == -1)
            //{
                models.Add(model);
            //}
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar ret = models.Find(x => x.Model == name);

            return ret;
        }

        public bool Remove(IFormulaOneCar model)
        {
            bool ret = false;
            int index = models.FindIndex(x => x.Model == model.Model);

            if (index >= 0)
            {
                models.RemoveAt(index);
                ret = true;
            }

            return ret;
        }
    }
}
