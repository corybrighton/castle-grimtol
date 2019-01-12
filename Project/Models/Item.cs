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

    // Constructor default wait to be able to take item
    public Item(string name, string description)
    {
      Name = name;
      Description = description;
      Takeable = true;
    }
    // Constructor with wait.
    public Item(string name, string description, bool takeable)
    {
      Name = name;
      Description = description;
      Takeable = takeable;
    }
    public virtual void use(Room planet)
    {
      Console.WriteLine("\n\tThat was pretty neat.");
    }
  }

}