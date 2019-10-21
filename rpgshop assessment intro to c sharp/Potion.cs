using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Potion : Item
    {
        private int _healthrestored;



        public Potion(string name, int cost, string description , int healthrestored) : base(name,cost, description)
        {
            _name = name;
            _cost = cost;
            _healthrestored = healthrestored;
            
        }



        public override string itemtype()
        {
            return "potion";
        }



        public override int healthrestored()
        {
            return _healthrestored;
        }

    }
}
