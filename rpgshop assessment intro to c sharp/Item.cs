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
        private string _description;
        public Item(string name, int cost, string description)
        {
            _name = name;
            _cost = cost;
            _description = description;
        }
        public void printitem()  //
        {
            Console.WriteLine(_name);
            Console.WriteLine(_cost);
            Console.WriteLine(_description);
        }
    }
}
