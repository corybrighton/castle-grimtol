using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public int Move { get; set; }
    public List<Item> Inventory { get; set; }
    public Player()
    {
      PlayerName = "Goerge Antilles";
      Inventory = new List<Item>();
      Item Blaster = new Item("E-11 Blaster", "Lazer Gun");
      Move = 0;
    }

    public void MoveIncrementer()
    {
      Move++;
    }
  }
}