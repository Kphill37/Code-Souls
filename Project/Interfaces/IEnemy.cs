using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces
{

  public interface IEnemy
  {

    string Name { get; set; }

    string Description { get; set; }

    int HP { get; set; }

    List<Item> Inventory { get; set; }
  }
}