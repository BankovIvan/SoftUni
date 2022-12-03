namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using System;
    using System.Collections.Generic;

    public class VesselRepository : IRepository<IVessel>
    {
        Dictionary<string, IVessel> models;

        public IReadOnlyCollection<IVessel> Models
        {
            get { return (new List<IVessel>(models.Values)).AsReadOnly(); }
        }

        public VesselRepository()
        {
            this.models = new Dictionary<string, IVessel>();
        }

        public void Add(IVessel model)
        {
            this.models.Add(model.Name, model);
        }

        public IVessel FindByName(string name)
        {
            IVessel ret = null;

            if(models.ContainsKey(name))
            {
                ret = models[name];
            }

            return ret;
        }

        public bool Remove(IVessel model)
        {
            bool ret = false;

            if (models.ContainsKey(model.Name))
            {
               this.models.Remove(model.Name);
                ret = true;
            }

            return ret;
        }
    }
}
