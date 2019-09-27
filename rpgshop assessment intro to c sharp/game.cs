using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Game
    {
        string playerchoice; //this is used by many functions in the program
        int gold = 0;
        bool validchoice = false; //this is used for the while loops used in the menus to prevent players from picking an invalid chocie
        bool gameisrunning = true;
        public void start()
        {
            Item Empty = new Item("nothing", 0, "please replace me");   //this is used for when you have nothing in your inventory slot this may be replaced later as with the dynamic array it will serve no purpose
            Item potion = new Potion("Potion", 10, "please replace me", 10);
            Item Mastersword = new Weapon("MasterSword", 999, "please replace me", 999);
            Item superpotion = new Potion("super potion", 20, "please replace me", 30);
            Item Sword = new Weapon("Sword", 10, "please replace me", 10);
            //Item[] playerinventory = { Empty, Empty, Empty, Empty, Empty }; //this is the players inventory i no longer need these
            //Item[] shopinventory = { Empty, Empty, Empty };  // this is the shops inventory i no longer need this
            Item[] ItemList = { Mastersword, potion, Sword, superpotion}; //this list contains all the items in the game and is iused in the superuser function to give you any item you want this is used rather than a dynamic array as there is no need for this to be bigger
            Inventory player = new Inventory();
            Inventory shop = new Inventory();
            menu(); //goes to the menu

        }
        public void printinventory() //
        {

        }
        public void printshopinventory() //
        {

        }

        public void menu() //
        {
            while(gameisrunning)
            {
                validchoice = false;
                while (!validchoice)
                {
                    Console.WriteLine("pick an option");
                    Console.WriteLine("1:player inventory");
                    Console.WriteLine("2: enter shop");
                    Console.WriteLine("3: save");
                    Console.WriteLine("4: load");
                    Console.WriteLine("5: quit");
                    //Console.WriteLine("484: Superuser menu"); use this to access the superuser menu
                    playerchoice = Console.ReadLine();
                    if (playerchoice == "1")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    else if (playerchoice == "2")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    else if (playerchoice == "3")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    else if (playerchoice == "4")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    else if (playerchoice == "5")
                    {
                        gameisrunning = false;
                        validchoice = true;
                    }
                    else if (playerchoice == "484") //this takes people to the superuser menu dont tell anyone
                    {
                        Superuser();
                        validchoice = true;
                    }
                }

            }
            

        }
        public void Superuser() //here is the debug tools use this for cheats and doing things such as adding things to player inventory or shop inventory
        {
            Console.WriteLine("welcome to the secret superuser menu dont tell anyone how you got here");
            int goldaddremove = 0;
            validchoice = false;
            while (!validchoice)
            {
                
                Console.WriteLine("what do you want to do");
                Console.WriteLine("1: add gold");
                Console.WriteLine("2: remove gold");
                Console.WriteLine("3: add or remove items from shop/player inventory");
                Console.WriteLine("4: go back to game");
                Console.WriteLine("type a number and press enter");
                playerchoice = Console.ReadLine();

                if (playerchoice == "1")
                {

                    Console.WriteLine("please type how much gold you want");
                    goldaddremove = Convert.ToInt32(Console.ReadLine()); //reuses the add gold function but it allows user to set the value of gold
                    addgold(goldaddremove);
                    validchoice = true;
                    return;
                }
                if (playerchoice == "2")
                {
                    Console.WriteLine("please type how much gold you want");
                    goldaddremove = Convert.ToInt32(Console.ReadLine());
                    removegold(goldaddremove); //reuses the remove gold function but it allows user to set the value of gold
                    validchoice = true;
                    return;
                }
                if (playerchoice == "3")
                {
                    Console.WriteLine("feature not implemented");
                    validchoice = true;
                    return;
                }
                if (playerchoice == "4")
                {
                    Console.WriteLine("feature not implemented");
                    validchoice = true;
                    return;
                }
            }

        }
        public void addgold(int addammount) 
        {
            gold = gold + addammount;
        }
        public void removegold(int removeammount)
        {
            gold = gold - removeammount;
        }
        public void Save(string path) //saving is not yet fininished
        {
            StreamWriter writer = File.CreateText(path);
            for (int i = 0; i < 10; i++) //placeholder for later
            {
                writer.WriteLine();
            }
            
        }
        public void Load() //cant make a load function untill i write a save function
        {

        }
        public void shop() //may move shop somewhere else dont know yet.
        {
            Console.WriteLine("Welcome to the shop");
            Console.WriteLine("");
        }
    }

}

