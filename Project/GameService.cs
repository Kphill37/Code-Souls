using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    private bool running = true;



    public void GetUserInput()
    {
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {
      CurrentRoom = (Room)CurrentRoom.Go(direction);
    }

    public void Help()
    {
      Console.WriteLine("Typing 'Go Forward' or 'Go Back' will allow you to move between rooms.");
      Console.WriteLine("Typing 'Take itemName' allows you to take items from rooms.  Ex: take key");
      Console.WriteLine("Typing 'Use itemName' allows you to use an item where applicable.");
      Console.WriteLine("Typing 'attack targetName' commences battle with a selected target.");
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup()
    {
      Room RoomA = new Room("RoomA", "You look around the cell.  Skeletons hang cuffed at the wrists.  You're able to peer through the bars on the jail door, and see other people.  You're certain they've already gone hollow.");
      Room RoomB = new Room("RoomB", "To one side there's a long opening that stretches down the length of the hallway like a window.  You see a hellish demon patrolling below, but luckily he can't reach you.  To the other side; several other jail cells.  Other Hollows roam the hallway amongst you, but seem docile despite their terrifying appearance.");
      Room RoomC = new Room("RoomC", "Straight ahead lies a spectacularly tall door.  To a far corner is another pathway.");
      Room RoomD = new Room("RoomD", "The purpose of this room is unclear, but ahead lies a structure embedded into the wall resembling a face.  It looks like something fits where the mouth is...");


      RoomA.Exits.Add("forward", RoomB);
      RoomB.Exits.Add("back", RoomA);

      RoomB.Exits.Add("forward", RoomC);
      RoomC.Exits.Add("back", RoomB);

      RoomC.Exits.Add("forward", RoomD);
      RoomD.Exits.Add("back", RoomC);


      Item jailKey = new Item("Key", "Jail Key");
      Item lockstone = new Item("Pharros Lockstone", "Stone activating a creation of Pharros the Vagabond.");
      Item KnightSet = new Item("Knight Gear", "A sturdy set of armor, a longsword, and a shield baring the crest of Anor Londo.");
      RoomA.Items.Add(jailKey);
      RoomB.Items.Add(lockstone);
      RoomD.Items.Add(KnightSet);

      CurrentRoom = RoomA;

    }
    public void StartGame()
    {
      while (running)
      {
        Console.WriteLine($"You are in room {CurrentRoom.Description}");
        Console.WriteLine("You will . . .");
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
            Go(option);
            break;
          case "help":
            Help();
        }
      }
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public GameService()
    {

    }
  }
}