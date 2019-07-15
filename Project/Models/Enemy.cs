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
    public int atkPower { get; set; }
    public List<Item> Inventory { get; set; }

    public bool aliveStatus { get; set; }



    public Enemy(string name, string description, int hp, int atkpower, bool aliveStatus)
    {
      Name = Name;
      Description = description;
      HP = hp;
      atkPower = atkpower;
      aliveStatus = true;
      Inventory = new List<Item>();
    }
  }
}