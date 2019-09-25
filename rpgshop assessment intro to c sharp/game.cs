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
        string playerchoice; //this is reused for the menu functions and other things such as adding gold and removeing gold
        int gold = 0;
        bool validchoice = false; //this is used for the while loops used in the menus to prevent players from picking an invalid chocie
        bool gameisrunning = true;
        public void start()
        {
            Item Empty = new Item("nothing", 0);   //this is used for when you have nothing in your inventory slot
            Item potion = new Potion("Potion", 10, 10);
            Item Mastersword = new Weapon("MasterSword", 999, 999);
            Item superpotion = new Potion("super potion", 20, 30);
            Item Sword = new Weapon("Sword", 10, 10);
            Item[] playerinventory = { Empty, Empty, Empty, Empty, Empty }; //this is the players inventory
            Item[] shopinventory = { Empty, Empty, Empty };  // this is the shops inventory
            Item[] ItemList = { Mastersword, potion, Sword, superpotion }; //this list contains all the items in the game and is iused in the superuser function to give you any item you want
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
                    //Console.WriteLine("484: Superuser menu");
                    playerchoice = Console.ReadLine();
                    if (playerchoice == "1")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    if (playerchoice == "2")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    if (playerchoice == "3")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    if (playerchoice == "4")
                    {
                        Console.WriteLine("feature not implemented");
                    }
                    if (playerchoice == "484") //this takes people to the superuser menu dont tell anyone
                    {
                        Superuser();
                        validchoice = true;
                    }
                }

            }
            

        }
        public void Superuser() //here is the debug tools use this for cheats and doing things such as adding things to player inventory or shop inventory
        {
            
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
                    Console.WriteLine("feature not implemented");
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
        public void Save(string path)
        {
            StreamWriter writer = File.CreateText(path);
            for (int i = 0; i < 10; i++) //placeholder for later
            {
                writer.WriteLine();
            }
            
        }
        public void Load()
        {

        }

    }

}

