using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Takeable { get; set; }

    // Constructor with wait.
    public Item(string name, string description, bool takeable = true)
    {
      Name = name;
      Description = description;
      Takeable = takeable;
    }
    public virtual void use(Room room, Planet planet, Player player, GameService game)
    {
      Console.WriteLine("\n\tThat was pretty neat.");
    }

  }

}