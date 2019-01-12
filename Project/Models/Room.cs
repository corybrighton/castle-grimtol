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

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }

    public void AddExit(string name, Room room)
    {
      Exits.Add(name, room);
    }
    public void AddItem(Item item)
    {
      Items.Add(item);
    }

    public virtual void FirePlasmaCannon()
    {
      Console.WriteLine("\n\tThat was pretty neat!");
    }
  }
}