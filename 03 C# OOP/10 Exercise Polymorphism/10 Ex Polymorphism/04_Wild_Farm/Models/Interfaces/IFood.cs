namespace WildFarm.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFood
    {
        int Quantity { get; }

        //HashSet<string> FoodType { get; }
    }
}
