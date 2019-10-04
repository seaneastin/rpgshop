﻿using System;
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
        Inventory playerinv = new Inventory();
        Inventory shopinv = new Inventory();
        public void start() //uses this to set evrything up before the game starts
        {
            Item potion = new Potion("Potion", 10, "please replace me", 10);
            Item Mastersword = new Weapon("MasterSword", 999, "please replace me", 999);
            Item superpotion = new Potion("super potion", 20, "please replace me", 30);
            Item Sword = new Weapon("Sword", 10, "please replace me", 10); 
            Item[] ItemList = { Mastersword, potion, Sword, superpotion }; //item list for super user allows superuser to look at itemlist

            //shop setup
            shopinv.Add(potion);
            shopinv.Add(Sword);
            shopinv.Add(potion);
            shopinv.Add(superpotion);
            menu(); //goes to the menu


        }
        public void printinventory() //prints the players inventory
        {
            for (int i = 0; i < playerinv.Length; i++)
            {
                playerinv[i].printitem(i);
            }
        }
        public void printshopinventory() //prints the shops inventorty
        {
            for (int i = 0; i < shopinv.Length; i++)
            {
                shopinv[i].printitem(i);
            }
        }

        public void menu() //
        {
            while (gameisrunning)
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
                   // Console.WriteLine("484: Superuser menu"); //use this to access the superuser menu
                    playerchoice = Console.ReadLine();
                    if (playerchoice == "1")
                    {
                        printinventory();
                    }
                    else if (playerchoice == "2")
                    {
                        shop();
                    }
                    else if (playerchoice == "3")
                    {
                        Save("invtest.txt");
                        Console.WriteLine("save complete");
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

                    Console.WriteLine("please type how much gold you want to add");
                    goldaddremove = Convert.ToInt32(Console.ReadLine()); //has been made much better than the old function this uses a property instead
                    //addgold(goldaddremove);
                    Gold += goldaddremove;
                    validchoice = true;
                    return;
                }
                if (playerchoice == "2")
                {
                    Console.WriteLine("please type how much gold you want");
                    goldaddremove = Convert.ToInt32(Console.ReadLine());
                    Gold -= goldaddremove; //has been made much better than the old function this uses a property instead
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
        public int Gold //a property that allows you to change the gold value
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }
        public void Save(string path) //saving is not yet fininished
        {
            StreamWriter writer = File.CreateText(path);
            if (playerinv.Length > 0)
            {
                for (int i = 0; i < playerinv.Length; i++) //placeholder for later
                {
                    writer.WriteLine(playerinv[i].printname);
                }
                
                
            }
            if (shopinv.Length > 0)
            {
                for (int i = 0; i < shopinv.Length; i++) //placeholder for later
                {
                    writer.WriteLine(shopinv[i].printname);
                }

            }
            writer.Close();
        }
        public void Load(string path) //cant make a load function untill i write a save function
        {
            if (File.Exists(path))
            {
                StreamReader reader = File.OpenText(path);
               // putsomethinghere = Convert.ToInt32(reader.ReadLine) //placeholder for now
            }
        }
        public void shop() //may move shop somewhere else dont know yet.
        {
            validchoice = false;
            Console.WriteLine("Welcome to the shop");
            Console.WriteLine("Would you like to buy or sell items");
            while (!validchoice)
            {
                Console.WriteLine("Choose an option");
                Console.WriteLine("1: Buy");
                Console.WriteLine("2: Sell");
                Console.WriteLine("3: go back");
                playerchoice = Console.ReadLine();
                if (playerchoice == "1")
                {
                    buy();
                    validchoice = true;
                }
                else if (playerchoice == "2")
                {
                    sell();
                    validchoice = true;
                }
                else if (playerchoice == "3")
                {
                    validchoice = true;
                }
            }


        }
        public void buy() //this is where a player buys things from the shop
        {
            validchoice = false;
            int i = 0;
            if (shopinv.Length > 0)
            {
                while (!validchoice)
                {
                    for (i = 0; i < shopinv.Length; i++)
                    {
                        shopinv[i].printitem(i);
                    }
                    Console.WriteLine("choose an item to buy");
                    playerchoice = Console.ReadLine();
                    if (Convert.ToInt32(playerchoice) < shopinv.Length)
                    {
                        Item Temp = shopinv.GetItem(Convert.ToInt32(playerchoice));
                        if (gold >= Temp.cost)
                        {
                            shopinv.remove(Convert.ToInt32(playerchoice));
                            playerinv.Add(Temp);
                            //add gold property here
                            validchoice = true;
                            
                        }
                     else
                        {
                            Console.WriteLine("you dont have enough money to buy this");
                            Console.ReadKey();
                            validchoice = true;
                        }
                    }

                    else
                    {
                        Console.WriteLine("this is not a valid choice");
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    }
                }
                

            }
            else
            {
                Console.WriteLine("the shop has no items");
            }

        }
        public void sell()
        {
            validchoice = false;
            int i = 0;
            if (playerinv.Length > 0)
            {
                while (!validchoice)
                {
                    for (i = 0; i < playerinv.Length; i++)
                    {
                        playerinv[i].printitem(i);
                    }
                    Console.WriteLine("choose an item to sell");
                    playerchoice = Console.ReadLine();
                    if (Convert.ToInt32(playerchoice) < playerinv.Length)
                    {
                        Item Temp = playerinv.GetItem(Convert.ToInt32(playerchoice));
                            playerinv.remove(Convert.ToInt32(playerchoice));
                            shopinv.Add(Temp);
                        //add gold property here
                        validchoice = true;
                    }

                    else
                    {
                        Console.WriteLine("this is not a valid choice");
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    }
                }


            }
            else
            {
                Console.WriteLine("the player has no items");
            }

        }
    }

}

