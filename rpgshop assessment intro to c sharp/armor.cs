﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Armor : Item
    {
        private string _name = "";
        private int _cost = 0;
        public Armor(string name, int cost, string description, int defenseadded) : base(name, cost, description)
        {
            _name = name;
            _cost = cost;

        }
    }
}