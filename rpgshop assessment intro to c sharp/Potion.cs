using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Potion : Item
    {
        private string _name = "";
        private int _cost = 0;

        public Potion(string name, int cost, int healthrestored) : base(name,cost)
        {
            _name = name;
            _cost = cost;

        }
    }
}
