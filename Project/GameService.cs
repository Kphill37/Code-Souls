using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public Enemy CurrentEnemy { get; set; }

    private bool running = true;

    private bool attacking;


    public void Go(string direction)
    {
      if (CurrentRoom.Name == "RoomB")
      {
        Console.WriteLine("As you walk through the door, you're met with humungous Demon.  What do you do?");
      }
      if (CurrentRoom.UnlockedStatus == false)
      {
        Console.WriteLine("You push on the door.  Locked.");
      }
      else
      {
        CurrentRoom = (Room)CurrentRoom.Go(direction);
        // Console.Clear();
        Console.WriteLine(CurrentRoom.Description);
      }
    }


    public void Help()
    {
      Console.WriteLine(@"Controls: 'Go Forward' or 'Go Back' will allow you to move between rooms.
      
'Take itemName' allows you to take items from rooms.  Ex: take key

'Use itemName' allows you to use an item where applicable.

'attack targetName' commences battle with a selected target.




");

    }

    public void Inventory()
    {

      if (CurrentPlayer.Inventory != null)
      {
        foreach (var item in CurrentPlayer.Inventory)
        {
          Console.WriteLine(@"{0} 
          ", item.Name);
          break;
        }
      }
      else
      {
        Console.WriteLine("Nothing in inventory!");
      }

    }

    public void Look()
    {
      Console.WriteLine(CurrentRoom.Description);
    }

    public void Quit()
    {
      running = false;
    }

    public void Reset()
    {
      Setup();
    }

    public void Setup()
    {
      Console.Clear();
      Room RoomA = new Room("RoomA", "You look around the cell.  Skeletons hang cuffed at the wrists.  You're able to peer through the bars on the jail door, and see other Undead.  You're certain they've already gone insane.  Luckily you still have your wits about you.", false);
      Room RoomB = new Room("RoomB", "To one side there's a long opening that stretches down the length of the hallway like a window.  You see a hellish demon patrolling below, but luckily he can't reach you.  To the other side; several other jail cells.  Other Hollows roam the hallway amongst you, but seem docile despite their terrifying appearance.", true);
      Room RoomC = new Room("RoomC", "Straight ahead lies a spectacularly tall door.  To a far corner is another pathway.", true);
      Room RoomD = new Room("RoomD", "The purpose of this room is unclear, but ahead lies a structure embedded into the wall resembling a face.  It looks like something fits where the mouth is...", false);


      RoomA.Exits.Add("forward", RoomB);
      RoomB.Exits.Add("back", RoomA);

      RoomB.Exits.Add("forward", RoomC);
      RoomC.Exits.Add("back", RoomB);

      RoomC.Exits.Add("forward", RoomD);
      RoomD.Exits.Add("back", RoomC);


      Item jailKey = new Item("key", "Jail Key");
      Item lockstone = new Item("pharros", "Stone activating a creation of Pharros the Vagabond.");
      Item KnightSet = new Item("gear", "A sturdy set of armor, a longsword, and a shield baring the crest of Anor Londo.");
      RoomA.Items.Add(jailKey);
      RoomB.Items.Add(lockstone);
      RoomD.Items.Add(KnightSet);

      Random rnd = new Random();


      CurrentRoom = RoomA;
      CurrentPlayer = new Player("Chosen Undead", 100, rnd.Next(10, 20));
      Enemy Hollow1 = new Enemy("hollow1", "Another soul that's gone hollow, like yourself.  They're terribly skinny, and remain propped up against the wall; indifferent to the world around them.", 15, rnd.Next(1, 3));
      Enemy Hollow2 = new Enemy("hollow2", "Another hollow.  You can hear him sobbing in the back of his cell.  The door is locked.", 15, 0);
      Enemy Hollow3 = new Enemy("hollow3", "You look and see a figure equipped from head to toe in Balder gear; Balder being the motherland of the Balder Knights who were fierce duelists.  He lies motionless, but his eyes barely glow red with life.  He seems to be clutching a stone block; smooth and frayed at the top, and covered in moss.  A key or treasure perhaps?", 40, rnd.Next(1, 10));
      Enemy AsylumDemon = new Enemy("demon", "The large demon found in the Northern Undead Asylum assigned to keep Undead under lock and key.", 100, rnd.Next(20, 30));
      RoomB.Enemies.Add(Hollow1);
      RoomB.Enemies.Add(Hollow2);
      RoomB.Enemies.Add(Hollow3);
      RoomC.Enemies.Add(AsylumDemon);

      Console.WriteLine(@" 
 _______  _______  ______   _______    _______  _______           _        _______ 
(  ____ \(  ___  )(  __  \ (  ____ \  (  ____ \(  ___  )|\     /|( \      (  ____ \
| (    \/| (   ) || (  \  )| (    \/  | (    \/| (   ) || )   ( || (      | (    \/
| |      | |   | || |   ) || (__      | (_____ | |   | || |   | || |      | (_____ 
| |      | |   | || |   | ||  __)     (_____  )| |   | || |   | || |      (_____  )
| |      | |   | || |   ) || (              ) || |   | || |   | || |            ) |
| (____/\| (___) || (__/  )| (____/\  /\____) || (___) || (___) || (____/\/\____) |
(_______/(_______)(______/ (_______/  \_______)(_______)(_______)(_______/\_______)
                                                                                   
                                                                                   
                                                                                   
                                                                                   ");

      Console.WriteLine(@"As you sit alone in your cell, you're certain you'll be stuck here for the rest of your days.  Undead from across the land were rounded up, and locked away in attempts to save Lordran from the Undead Curse.
      
Tally marks fill the entire wall behind you.  Too many to count.  
      
Suddenly, you hear movement from above for the first time in days.  Just as you look up in curiosity, a corpse falls from the ceiling, and slams down just in front of you.  He has a Key on him.  A way out?
      
You look back up at the hole in the ceiling of your cell, and see an Elite Knight.  You gaze at each other for a moment in complete silence, before he walks away.


");

    }
    public void StartGame()
    {
      while (running)
      {

        Console.Write("You will: ");
        string choice = Console.ReadLine().ToLower();

        string[] choices = choice.Split(' ');
        string command = choices[0];

        string option = " ";

        if (choices.Length > 1)
        {
          option = choices[1];
        }

        switch (command)
        {
          case "go":
            Console.Clear();
            Go(option);
            break;
          case "take":
            TakeItem(option);
            break;
          case "use":
            UseItem(option);
            break;
          case "attack":
            attackState(option);
            break;
          case "help":
            Help();
            break;
          case "inventory":
            Inventory();
            break;
          case "look":
            Look();
            break;
          case "quit":
            Console.Clear();
            Quit();
            break;
          case "reset":
            Console.Clear();
            Reset();
            break;
          default:
            Console.WriteLine("Invalid Input");
            break;
        }
      }
    }

    public void TakeItem(string itemName)
    {
      if (CurrentRoom.Name == "RoomD" && CurrentRoom.UnlockedStatus == false)
      {
        Console.WriteLine($@"{itemName} does not exist, or is already in inventory
        ");
      }


      Item foundItem = CurrentRoom.Items.Find(i => i.Name == itemName);
      if (foundItem != null)
      {
        CurrentRoom.Items.Remove(foundItem);
        CurrentPlayer.Inventory.Add(foundItem);
        Console.WriteLine(@"Added to inventory
        ");
      }
      else
      {
        Console.WriteLine($@"{itemName} does not exist, or is already in inventory
        ");
      }
      if (itemName == "gear")
      {
        CurrentPlayer.AtkPower += 30;
        Console.WriteLine("You reach out, and grab at the Hollow and begin looting.  You stand tall, covered from head to toe in armor; also equipping their Long Sword and shield.  Now, about that Demon . . .");
      }
    }

    public void attackState(string attackTarget)
    {
      Enemy enemy = CurrentRoom.Enemies.Find(e =>
      { Console.WriteLine(e.Name); return e.Name == attackTarget; });

      if (enemy != null && enemy.AliveStatus == true)
      {
        attacking = true;
        while (attacking)
        {
          Console.Clear();
          Console.WriteLine("Attacking . . .");
          enemy.HP -= CurrentPlayer.AtkPower;
          CurrentPlayer.HP -= enemy.AtkPower;
          Thread.Sleep(1000);
          Console.WriteLine($@"{CurrentPlayer.PlayerName} strikes {enemy.Name} for {CurrentPlayer.AtkPower}! 
{enemy.Name} strikes {CurrentPlayer.PlayerName} for {enemy.AtkPower}!

 {CurrentPlayer.PlayerName}       -       {enemy.Name}
      {CurrentPlayer.HP}          -          {enemy.HP}

                                                                                                              ");
          Thread.Sleep(3000);

          if (CurrentPlayer.HP <= 0 && enemy.HP > 1)
          {
            Console.Clear();
            Console.WriteLine("YOU DIED");
            Console.WriteLine("Restart?  Y/N");
            string resetChoice = Console.ReadLine().ToLower();
            if (resetChoice == "y")
            {
              Reset();
              break;
            }
            else
            {
              Quit();
              break;
            }

          }
          else if (CurrentPlayer.HP > 1 && enemy.HP <= 0)
          {
            attacking = false;
            enemy.AliveStatus = false;
            Console.WriteLine(@"YOU DEFEATED
                                                                                              ");
            Thread.Sleep(1000);
            if (enemy.Name == "demon" && enemy.AliveStatus == false)
            {
              Console.Clear();
              Console.WriteLine("You slay the Asylum Demon, and find a key on him that leads through the double doors behind him.  You leave this place, and venture out into the world in search of your life purpose, or risk going completely Hollow forever.  YOU WIN?");
              Console.WriteLine("Restart?  Y/N");
              string resetChoice = Console.ReadLine().ToLower();
              if (resetChoice == "y")
              {
                Reset();
                break;
              }
              else
              {
                Quit();
                break;
              }
            }
            Console.WriteLine($"{CurrentRoom.Description}");
            break;
          }
        }
      }
    }

    public void UseItem(string itemName)
    {
      Item discardItem = CurrentPlayer.Inventory.Find(i => i.Name == itemName);

      if (CurrentRoom.Name == "RoomA" && itemName == "key")
      {
        CurrentRoom.UnlockedStatus = true;
        Console.WriteLine($"{CurrentPlayer.PlayerName} uses {itemName}");
        Console.WriteLine($"No use for {itemName} anymore.  Discard?  Y/N");
        string itemDecision = Console.ReadLine().ToLower();

        if (itemDecision == "y")
        {
          CurrentPlayer.Inventory.Remove(discardItem);
          Console.WriteLine("Discarded!");
        }

      }
      if (CurrentRoom.Name == "RoomD" && itemName == "pharros")
      {
        CurrentRoom.UnlockedStatus = true;
        Console.WriteLine($"{CurrentPlayer.PlayerName} uses {itemName}");
        Console.WriteLine(@"You insert the block into the mouth.  It slides in suprisingly easy, and the whole room lights up with a brilliant blue aura.  The contraption lifts up, and reveals a long since passed Hollow; equipped head to toe in armor and weapons.
                                                                                    ");

        Console.WriteLine($"No use for {itemName} anymore.  Discard?  Y/N");
        string itemDecision = Console.ReadLine().ToLower();

        if (itemDecision == "y")
        {
          CurrentPlayer.Inventory.Remove(discardItem);
          Console.WriteLine("Discarded!");
        }

      }
    }

    public void GetUserInput()
    {
      throw new NotImplementedException();
    }
  }
}