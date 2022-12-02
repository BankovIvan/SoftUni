namespace Formula1.Repositories
{
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public IReadOnlyCollection<IPilot> Models
        {
            get { return models.AsReadOnly(); }
        }

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public void Add(IPilot pilot)
        {
            //int index = models.FindIndex(x => x.FullName == pilot.FullName);

            //if (index == -1)
            //{
                models.Add(pilot);
            //}
            
        }

        public IPilot FindByName(string name)
        {
            IPilot ret = models.Find(x => x.FullName == name);

            return ret;
        }

        public bool Remove(IPilot pilot)
        {
            bool ret = false;
            int index = models.FindIndex(x => x.FullName == pilot.FullName);

            if (index > 0)
            {
                models.RemoveAt(index);
                ret = true;
            }

            return ret;
        }
    }
}
