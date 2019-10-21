using System;
using System.IO;

namespace rpgshop_assessment_intro_to_c_sharp
{
    class Game
    {
        string playerchoice; //this is used by many functions in the program
        string playerchoice2; //this is used by many functions in the program
       

        int playergold = 500;
        int shopgold = 500;
        bool validchoice = false; //this is used for the while loops used in the menus to prevent players from picking an invalid chocie
        bool gameisrunning = true; //tells the program if the game is currently running
        int shopchoice = 0; //the players choice when they are buying an item
        Inventory playerinv = new Inventory(); //the players inventory 
        Inventory shopinv = new Inventory(); //the shops inventory



        public void start() //uses this to set evrything up before the game starts
        {
            if (File.Exists("playerinv.txt") && File.Exists("shopinv.txt"))  //checks to see if a save file exists
            {
                Load("playerinv.txt"); //it will load the save files for the player
                Load("shopinv.txt");
            }
            else //if a save file is deleted manulaly by the user the game will load this instead to prevent crashing
            {


                //these items are used if a player does not have a save file
                Item potion = new Potion("Potion", 10, "this will heal you 10HP", 10);
                Item superpotion = new Potion("super potion", 20, "this is better than the potion", 30);
                Item Sword = new Weapon("Sword", 10, "its a regular sword", 10);


                //these will add items to the shop
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

            Console.Clear(); //these will wipe the screen whenever any function or menu is called
            Console.WriteLine("gold: " + playergold);
            for (int i = 0; i < playerinv.Length; i++)
            {
                playerinv[i].printitem(i);
            }
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
        public void printshopinventory() //prints the shops inventorty
        {
            for (int i = 0; i < shopinv.Length; i++)
            {
                shopinv[i].printitem(i);
            }
        }





        public void menu() //the menu for the game
        {
            while (gameisrunning)
            {
                validchoice = false;
                while (!validchoice)
                {
                    Console.Clear();
                    Console.WriteLine("pick an option");
                    Console.WriteLine("1: player inventory");
                    Console.WriteLine("2: enter shop");
                    Console.WriteLine("3: save");
                    Console.WriteLine("4: load");
                    Console.WriteLine("5: quit");
                    Console.WriteLine("the game will autosave if you close the game using the menu");
                   //Console.WriteLine("484: Superuser menu"); //use this to access the superuser menu
                    playerchoice = Console.ReadLine();
                    if (playerchoice == "1") //prints the inventory
                    {
                        printinventory();
                    }
                    else if (playerchoice == "2") //enters the shop
                    {
                        shop();
                    }
                    else if (playerchoice == "3") //saves the game if player wants to without exiting
                    {
                        Save("playerinv.txt");
                        Save("shopinv.txt");
                        Console.WriteLine("save complete");
                    }
                    else if (playerchoice == "4") //allows you to load a save file
                    {

                        Load("playerinv.txt");
                        Load("shopinv.txt");
                        Console.WriteLine("Load Complete");
                    }
                    else if (playerchoice == "5") //quits the game and saves it
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
            Console.Clear();
            Console.WriteLine("welcome to the secret superuser menu dont tell anyone how you got here");
            
            int goldaddremove = 0;
            validchoice = false;
            while (!validchoice)
            {

                Console.WriteLine("what do you want to do");
                Console.WriteLine("1: add gold");
                Console.WriteLine("2: remove gold");
                Console.WriteLine("3: add item to shop/player inventory");
                Console.WriteLine("4: go back to game");
                Console.WriteLine("type a number and press enter");
                playerchoice = Console.ReadLine();







                if (playerchoice == "1") //this is for adding gold
                {
                    Console.Clear();
                    Console.WriteLine("please type how much gold you want to add");
                    if (Int32.TryParse(Console.ReadLine(), out goldaddremove )) //this will check to see if you enter a valid number into the console in order to prevent crashing
                    {
                        playerGold += goldaddremove;
                    }
                    else
                    {
                        Console.WriteLine("you did not put in a valid number");
                    }
                    
                    validchoice = true;
                    return;
                }






                if (playerchoice == "2") //this is for removeing gold
                {
                    Console.Clear();
                    Console.WriteLine("please type how much gold you want to remove");

                    if (Int32.TryParse(Console.ReadLine(), out goldaddremove))
                    {
                        playerGold-= goldaddremove;
                    }
                    else
                    {
                        Console.WriteLine("you did not put in a valid number");
                    }
                    validchoice = true;
                    return;
                }




                if (playerchoice == "3") //this allows you to create your own items
                {
                    superuseradditems();
                    
                    validchoice = true;
                    return;
                }
                if (playerchoice == "4") //this is for returning to the menu
                {
                    validchoice = true;
                    return;
                }
            }

        }




        public void superuseradditems() //will allow anyone to create an item in the game
        {
            string itemname = "";
            int itemcost = 0;
            string itemdescript = "";
            int itemdamageorheal = 0;
            validchoice = false;
            while (!validchoice)
            {
                Console.Clear();
                Console.WriteLine("what do you want to do");
                Console.WriteLine("1: add item to playerinventory");
                Console.WriteLine("2: add item to shopinventory");
                playerchoice = Console.ReadLine(); //playerchoice 1 is used here for telling which inventory to add the custom item
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
                    playerchoice2 = Console.ReadLine(); //playerchoice 2 is used for telling the item type

                    if (playerchoice2 == "1")
                    {
                        validchoice = true;
                    }
                    if (playerchoice2 == "2")
                    {
                        
                        validchoice = true;
                    }
                }
                Console.WriteLine("name the item");
                itemname = Console.ReadLine();
            validchoice = false;
            while (!validchoice)
            {
                Console.WriteLine("how much does it cost to buy this item");
                if (Int32.TryParse(Console.ReadLine(), out itemcost))
                {
                    validchoice = true;
                }

                
            }
                Console.WriteLine("write a description");
                itemdescript = Console.ReadLine();
                if (playerchoice2 == "1") //this is for item type weapon
                {
                validchoice = false;
                while (!validchoice)
                {
                    Console.WriteLine("how much damage does the weapon do");
                    if (Int32.TryParse(Console.ReadLine(), out itemdamageorheal))
                    {
                        validchoice = true;
                    }
                }
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





                if (playerchoice2 == "2") //this is for item type potion
                {
                validchoice = false;
                while (!validchoice)
                {
                    Console.WriteLine("how much health does the potion heal");

                    if (Int32.TryParse(Console.ReadLine(), out itemdamageorheal))
                    {
                        validchoice = true;
                    }
                }
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




        public void Save(string path) //this is the saving function
        {
            //this if statement is used to tell whic inventory is currently saving
            if (path == "playerinv.txt")
            {

                StreamWriter writer = File.CreateText(path);
                writer.WriteLine(playerGold);
                if (playerinv.Length > 0)
                {

                    
                    for (int i = 0; i < playerinv.Length; i++) 
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
                    
                    
                    for (int i = 0; i < shopinv.Length; i++) 
                    {
                        writer.WriteLine(shopinv[i].itemtype());
                        writer.WriteLine(shopinv[i].printname);
                        writer.WriteLine(shopinv[i].cost);
                        writer.WriteLine(shopinv[i].description);
                        writer.WriteLine(shopinv[i].damage()); //writes 0 if the item is not a weapon
                        writer.WriteLine(shopinv[i].healthrestored()); //writes 0 if the item is not a potion
                    }
                    writer.Close();
                    Console.Clear();
                    Console.WriteLine("save file saved");
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }
            }

        }





        public void Load(string path) 
        {
            if (File.Exists(path))
            {

                bool loading = true; //used to make a while loop

                //these are used for loading stuff when the game is reading the save file these values are then used later
                string type;
                string name;
                int cost;
                int damage;
                int heal;
                string description;
                

                //used to tell which file is loading
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
                    Console.Clear();
                    Console.WriteLine("save file loaded");
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("no save file present \n press any key to continue");
                Console.ReadKey();
            }
        }





        public void shop() //the shop
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
                    Console.Clear();
                    buy();
                    validchoice = true;
                }
                else if (playerchoice == "2")
                {
                    Console.Clear();
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
                    if (Int32.TryParse((playerchoice), out shopchoice))
                    {
                        if (shopchoice < shopinv.Length)
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
                            Console.WriteLine("press any key to continue");
                            validchoice = true;
                            Console.ReadKey();
                        }
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
                    Console.WriteLine("choose an item to sell or enter a number not on the list to go back");

                    
                        playerchoice = Console.ReadLine();

                    if (Int32.TryParse(playerchoice, out shopchoice))
                    {
                        if (shopchoice < playerinv.Length)
                        {


                            Item Temp = playerinv.GetItem(Convert.ToInt32(playerchoice));
                            if (playergold >= Temp.cost)
                            {
                                playerinv.remove(Convert.ToInt32(playerchoice));
                                shopinv.Add(Temp);

                                validchoice = true;
                            }
                            else
                            {
                                Console.WriteLine("shop does not have enough gold");
                            }
                        }
                        else
                        {
                            validchoice = true;
                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                        }
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

