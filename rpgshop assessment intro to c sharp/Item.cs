using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Item
    {
        private string _name = "";
        private int _cost = 0;
        public Item(string name, int cost)
        {
            _name = name;
            _cost = cost;
        }
    }
}
