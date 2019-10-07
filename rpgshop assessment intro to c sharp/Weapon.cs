﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Weapon : Item
    {
        private string _name = "";
        private int _cost = 0;
        private int _damage = 0;
        public Weapon(string name, int cost, string description , int damage) : base(name,cost, description)
        {
            _name = name;
            _cost = cost;
            _damage = damage;
        }
        public override string itemtype()
        {
            return "weapon";
        }
        public int damage()
        {
            return _damage;
        }
    }
}
