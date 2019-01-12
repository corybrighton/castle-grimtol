using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public int Move { get; set; }
    public List<Item> Inventory { get; set; }
    public bool hasSTuniformOn { get; set; }
    public Player()
    {
      PlayerName = "Goerge Antilles";
      Inventory = new List<Item>();
      Blaster blaster = new Blaster("Blaster", "E-11 Lazer Gun");
      Inventory.Add(blaster);
      Move = 0;
      hasSTuniformOn = false;
    }
  }
}