using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class FoodModel
    {
        public string name;
        public int cost;

        public FoodModel(string foodName, int foodCost)
        {
            name = foodName;
            cost = foodCost;
        }
    }
}
