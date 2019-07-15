using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public int HP { get; set; }
    public int atkPower { get; set; }

    public Player(string playerName, int hp, int atkpower)
    {
      PlayerName = playerName;
      HP = hp;
      atkPower = atkpower;
      Inventory = new List<Item>();
    }
  }
}