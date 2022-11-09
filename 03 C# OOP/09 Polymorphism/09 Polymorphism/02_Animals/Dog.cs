namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dog : Animal
    {
        private string name;
        private string favouriteFood;

        public override string Name { get { return this.name; } }
        public override string FavouriteFood { get { return this.favouriteFood; } }

        public Dog(string name, string food)
        {
            this.name = name;
            this.favouriteFood = food;
        }

        public override string ExplainSelf()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(string.Format("I am {0} and my fovourite food is {1}", this.Name, this.FavouriteFood));
            ret.AppendLine("DJAAF");

            return ret.ToString().Trim();
        }
    }
}
