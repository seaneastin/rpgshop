| Sean Eastin
:-
| s18013
| Introduction to C# aassesssment
|RPG SHop

## I. Requirements

1. Description of Problem
- **Name**: Number Guessing Game
- **Problme Statement**:

- **Problem Specifications**:

2. Input Information
-

3. Output Information
-

4. User Interface Information

## II. Design

1. System Architecture

|Game Diagram
|:-
![Game diagram](rpgshop diagram)


### Object Information

**File**: program.cs


**File**: game.cs

Description: where most of the game is run
**Atrributes**

Name: playerchoice
description: mainly used when the player needs to choose an option.
type : string

Name: playerchoice2
description: same as above but is used in the superuser function because i need to store playerchoice without changing it.
type : string

Name : playergold
Description : holds the players gold
Type: int

Name : shopgold
Description : holds the shops gold
Type: int

Name : validchoice
Description : used in almost all while loops to prevent the person from entering in something that is not an option in the menus
type : bool

Name : gameisrunning
Description : used to keep the game running.
type : bool

Name : playerinv
Description : holds the players inventory.
type: inventory

Name : shopinv
Description : holds the players inventory.
type: inventory

Name: Start
Description where the game starts. if there is no save file present it will create weapons and set up the game.
otherwise it will load the save file.
type: function

Name : Printinventory
Description : prints the players inventory and gold
type : function

Name : Printshopinventory
Description : prints the shop inventory
type : function

Name: Menu
Description : the main menu for the program from here evrything else can be accessed also on the menu type 484 to go to the superuser menu.
type : function

Name : Superuser
description: the superuser menu used to add gold or even add custom items into the game.
type: function

Name : superuseradditems
Description : this allows the player to make custom items and add them to either the shop or player inventory.
type: function

Name : planyergold
Description : propertyu to change the players gold
type : property

Name : shopGold
Description : same as above but for shop gold instead

Name : Save
description : saves the game this is also run when you exit the game
type : function

Name : Load
description : loads the game this is also run at the start of the game if there is a save file present
type : function

Name : shop
description : this opens up the shop menu from there you can buy items from the shop or sell to the shop
type : function

Name : buy
description : this option allows the user to buy items from the shop inventory.
type : function

Name : sell
description : this option allows the user to sell items to the shop inventory
type : function
