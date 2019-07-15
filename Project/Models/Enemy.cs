using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{

  public class Enemy : IEnemy
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int HP { get; set; }
    public int AtkPower { get; set; }
    public List<Item> Inventory { get; set; }

    public bool AliveStatus { get; set; }



    public Enemy(string name, string description, int hp, int atkpower)
    {
      Name = name;
      Description = description;
      HP = hp;
      AtkPower = atkpower;
      AliveStatus = true;
      Inventory = new List<Item>();
    }
  }
}