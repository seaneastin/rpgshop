using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Item //this is a base class that item and weapon inherit from
    {
        protected string _name = "";
        protected int _cost = 0;
        protected string _description;



        public Item(string name, int cost, string description)
        {
            _name = name;
            _cost = cost;
            _description = description;
        }



        public void printitem(int i)  //prints items
        {
            Console.Write(i + ": ");
            Console.WriteLine(_name);
            Console.WriteLine( "cost: " + _cost);
            Console.WriteLine("description: " + _description);
            Console.WriteLine();
        }



        public string printname
        {
            get
            {
                return _name;
            }
            
        }



        public int cost
        {
            get
            {
                return _cost;
            }
        }



        public string description
        {
            get
            {
                return _description;
            }
        }



        public virtual string itemtype()
        {
           return "Item";
        }



        public virtual int damage()
        {
            return 0;
        }



        public virtual int healthrestored()
        {
            return 0;
        }

    }
}
