namespace Formula1.Repositories
{
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public IReadOnlyCollection<IRace> Models
        {
            get { return models.AsReadOnly(); }
        }

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public void Add(IRace race)
        {
            //int index = models.FindIndex(x => x.RaceName == race.RaceName);

            //if(index == -1)
            //{
                models.Add(race);
            //}
        }

        public IRace FindByName(string name)
        {
            IRace ret = models.Find(x => x.RaceName == name);

            return ret;
        }

        public bool Remove(IRace race)
        {
            bool ret = false;
            int index = models.FindIndex(x => x.RaceName == race.RaceName);

            if (index > 0)
            {
                models.RemoveAt(index);
                ret = true;
            }

            return ret;
        }
    }
}
