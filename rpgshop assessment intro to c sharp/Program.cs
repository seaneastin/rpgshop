using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold = 0;
            Item nothing = new Item("nothing", 0);   //this is used for when you have nothing in your inventory slot
            Item potion = new Potion("Potion", 10, 10);
            Item Mastersword = new Weapon("MasterSword", 999, 1);
            Item superpotion = new Potion("super potion", 20, 30);
            Item[] playerinventory = { nothing , nothing , nothing, nothing, nothing}; //this is the players inventory
            Item[] shopinventory = { nothing, nothing, nothing};  // this is the shops inventory
            Item[] ItemList = { Mastersword, potion };
        }
        public void printinventory() //
        {

        }

        public void printshopinventory() //
        {

        }
        public void printitem()  //
        {

        }
        public void menu() //
        {

        }
        public void superuser() //here is the debug tools use this for cheats and doing things such as adding things to player inventory or shop inventory
        {
            Console.WriteLine("what do you want to do");
            Console.WriteLine("1: add gold");
            Console.WriteLine("2: remove gold");
            Console.WriteLine("3: add or remove items from shop/player inventory");
            Console.WriteLine("4: go back to game");
            Console.WriteLine("");
        }

    }

}
