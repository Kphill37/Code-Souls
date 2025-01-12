using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public List<Enemy> Enemies { get; set; }

    public bool UnlockedStatus { get; set; }



    public Room Next { get; private set; }

    public Room Previous { get; private set; }


    public void AddNextRoom(Room next)
    {
      Next = next;
      next.AddPreviousRoom(this);
    }

    public void AddPreviousRoom(Room previous)
    {
      Previous = previous;
    }

    public void Print()
    {
      Console.WriteLine($"This is room: {Name}");
    }

    public IRoom Go(string dir)
    {
      if (Exits.ContainsKey(dir))
      {
        return Exits[dir];
      }
      Console.WriteLine("Can't go that way!");
      return this;
    }


    public Room(string name, string description, bool unlockedStatus = true)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Enemies = new List<Enemy>();
      Exits = new Dictionary<string, IRoom>();
      UnlockedStatus = unlockedStatus;
    }


  }
}

