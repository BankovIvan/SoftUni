namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Animal
    {
        public abstract string Name { get; }
        public abstract string FavouriteFood { get; }

        public abstract string ExplainSelf();

    }
}
