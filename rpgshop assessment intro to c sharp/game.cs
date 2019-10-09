using System;
using System.IO;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Game
    {
        string playerchoice; //this is used by many functions in the program
        string playerchoice2; //this is used by many functions in the program

        int playergold = 0;
        int shopgold = 999;
        bool validchoice = false; //this is used for the while loops used in the menus to prevent players from picking an invalid chocie
        bool gameisrunning = true;
        Inventory playerinv = new Inventory();
        Inventory shopinv = new Inventory();
        public void start() //uses this to set evrything up before the game starts
        {
            if (File.Exists("playerinv.txt") && File.Exists("shopinv.txt"))
            {
                Load("playerinv.txt");
                Load("shopinv.txt");
            }
            else
            {
                Item potion = new Potion("Potion", 10, "this will heal you 10HP", 10);
                Item Mastersword = new Weapon("MasterSword", 999, "cant even get this item in the game", 999);
                Item superpotion = new Potion("super potion", 20, "this is better than the potion", 30);
                Item Sword = new Weapon("Sword", 10, "its a regular sword", 10);
                Item[] ItemList = { Mastersword, potion, Sword, superpotion }; //item list for super user allows superuser to look at itemlist

                //shop setup
                shopinv.Add(potion);
                shopinv.Add(Sword);
                shopinv.Add(potion);
                shopinv.Add(superpotion);
                playerinv.Add(potion);
            }
            
            menu(); //goes to the menu


        }
        public void printinventory() //prints the players inventory
        {
            Console.WriteLine("gold: " + playergold);
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
                   //Console.WriteLine("484: Superuser menu"); //use this to access the superuser menu
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
                        Save("playerinv.txt");
                        Save("shopinv.txt");
                        Console.WriteLine("save complete");
                    }
                    else if (playerchoice == "4")
                    {

                        Load("playerinv.txt");
                        Load("shopinv.txt");
                        Console.WriteLine("Load Complete");
                    }
                    else if (playerchoice == "5")
                    {
                        Save("playerinv.txt");
                        Save("shopinv.txt");
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
                    playerGold += goldaddremove;
                    validchoice = true;
                    return;
                }
                if (playerchoice == "2")
                {
                    Console.WriteLine("please type how much gold you want");
                    goldaddremove = Convert.ToInt32(Console.ReadLine());
                    playerGold -= goldaddremove; //has been made much better than the old function this uses a property instead
                    validchoice = true;
                    return;
                }
                if (playerchoice == "3")
                {
                    superuseraddremoveitems();
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
        public void superuseraddremoveitems()
        {
            string itemtype = "";
            string itemname = "";
            string itemcost = "";
            string itemdescript = "";
            string itemdamageorheal = "";
            validchoice = false;
            while (!validchoice)
            {
                Console.WriteLine("what do you want to do");
                Console.WriteLine("1: add item to playerinventory");
                Console.WriteLine("2: add item to shopinventory");
                playerchoice = Console.ReadLine();
                if (playerchoice == "1" || playerchoice == "2")
                {
                    
                    validchoice = true;
                }
                
            }
            validchoice = false;
                while (!validchoice)
                {
                    Console.WriteLine("choose item type");
                    Console.WriteLine("1: Weapon");
                    Console.WriteLine("2: Potion");
                    playerchoice2 = Console.ReadLine();

                    if (playerchoice2 == "1")
                    {
                        itemtype = "weapon";
                        validchoice = true;
                    }
                    if (playerchoice2 == "2")
                    {
                        itemtype = "potion";
                        validchoice = true;
                    }
                }
                Console.WriteLine("name the item");
                itemname = Console.ReadLine();
                Console.WriteLine("how much does it cost to buy this item");
                itemcost = Console.ReadLine();
                Console.WriteLine("write a description");
                itemdescript = Console.ReadLine();
                if (playerchoice2 == "1")
                {
                    Console.WriteLine("how much damage does the weapon do");
                    itemdamageorheal = Console.ReadLine();
                    Item weapon = new Weapon(itemname, Convert.ToInt32(itemcost) , itemdescript, Convert.ToInt32(itemdamageorheal));
                    if (playerchoice == "1")
                    {
                        playerinv.Add(weapon);
                    }
                    if (playerchoice == "2")
                    {
                        shopinv.Add(weapon);
                    }
                }
                if (playerchoice2 == "2")
                {
                    Console.WriteLine("how much health does the potion heal");
                    itemdamageorheal = Console.ReadLine();
                    Item potion = new Potion(itemname, Convert.ToInt32(itemcost), itemdescript, Convert.ToInt32(itemdamageorheal));
                    if (playerchoice == "1")
                    {
                        playerinv.Add(potion);
                    }
                    if (playerchoice == "2")
                    {
                        shopinv.Add(potion);
                    }
                }
                
            
        }

        public int playerGold //a property that allows you to change the gold value
        {
            get
            {
                return playergold;
            }
            set
            {
                playergold = value;
            }
        }
        public int ShopGold //a property that allows you to change the gold value
        {
            get
            {
                return shopgold;
            }
            set
            {
                shopgold = value;
            }
        }
        public void Save(string path) //saving is not yet fininished
        {
            
            if (path == "playerinv.txt")
            {

                StreamWriter writer = File.CreateText(path);
                writer.WriteLine(playerGold);
                if (playerinv.Length > 0)
                {

                    
                    for (int i = 0; i < playerinv.Length; i++) //placeholder for later
                    {
                        writer.WriteLine(playerinv[i].itemtype());
                        writer.WriteLine(playerinv[i].printname);
                        writer.WriteLine(playerinv[i].cost);
                        writer.WriteLine(playerinv[i].description);
                        writer.WriteLine(playerinv[i].damage());
                        writer.WriteLine(playerinv[i].healthrestored());

                    }

                    writer.Close();
                }
            }
            if (path == "shopinv.txt")
            {
                StreamWriter writer = File.CreateText(path);
                writer.WriteLine(ShopGold);
                if (shopinv.Length > 0)
                {
                    
                    
                    for (int i = 0; i < shopinv.Length; i++) //placeholder for later
                    {
                        writer.WriteLine(shopinv[i].itemtype());
                        writer.WriteLine(shopinv[i].printname);
                        writer.WriteLine(shopinv[i].cost);
                        writer.WriteLine(shopinv[i].description);
                        writer.WriteLine(shopinv[i].damage()); //writes 0 if the item is not a weapon
                        writer.WriteLine(shopinv[i].healthrestored()); //writes 0 if the item is not a potion
                    }
                    writer.Close();
                }
            }
            
        }
        public void Load(string path) //cant make a load function untill i write a save function
        {
            if (File.Exists(path))
            {

                bool loading = true;
                string type;
                string name;
                int cost;
                int damage;
                int heal;
                string description;
                
                if (path == "playerinv.txt") 

                {
                    playerinv.Clear();
                    StreamReader reader = File.OpenText(path);
                    playergold = Convert.ToInt32(reader.ReadLine());
                    while (loading)
                    {
                        type = reader.ReadLine();
                        name = reader.ReadLine();
                        cost = Convert.ToInt32(reader.ReadLine());
                        description = reader.ReadLine();
                        damage = Convert.ToInt32(reader.ReadLine()); //although it will read the 0 even if its a potion this value does nothing after the if statements
                        heal = Convert.ToInt32(reader.ReadLine());  //although it will read the 0 even if its a weapon this value does nothing after the if statements
                        if (type == "weapon")
                        {
                            Item weapon = new Weapon(name, cost, description, damage);
                            playerinv.Add(weapon);
                        }
                        if (type == "potion")
                        {
                            Item potion = new Potion(name, cost, description, heal);
                            playerinv.Add(potion);
                        }
                        if (type == null)
                        {
                            loading = false;
                        }
                    }
                    reader.Close();
                }
                if (path == "shopinv.txt")
                {
                    shopinv.Clear();
                    StreamReader reader = File.OpenText(path);
                    shopgold = Convert.ToInt32(reader.ReadLine());
                    while (loading)
                    {
                        type = reader.ReadLine();
                        name = reader.ReadLine();
                        cost = Convert.ToInt32(reader.ReadLine());
                        description = reader.ReadLine();
                        damage = Convert.ToInt32(reader.ReadLine());
                        heal = Convert.ToInt32(reader.ReadLine());
                        if (type == "weapon")
                        {
                            Item weapon = new Weapon(name, cost, description, damage);
                            shopinv.Add(weapon);
                        }
                        if (type == "potion")
                        {
                            Item potion = new Potion(name, cost, description, heal);
                            shopinv.Add(potion);
                        }
                        if (type == null)
                        {
                            loading = false;
                        }
                        
                    }
                    reader.Close();
                }
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
                    Console.WriteLine("choose an item to buy type a number that is not on the list to go back");
                    playerchoice = Console.ReadLine();
                    if (Convert.ToInt32(playerchoice) < shopinv.Length)
                    {
                        Item Temp = shopinv.GetItem(Convert.ToInt32(playerchoice));
                        if (playergold >= Temp.cost)
                        {
                            shopinv.remove(Convert.ToInt32(playerchoice));
                            playerinv.Add(Temp);
                            playerGold -= Temp.cost;
                            ShopGold += Temp.cost;
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
                        validchoice = true;
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

