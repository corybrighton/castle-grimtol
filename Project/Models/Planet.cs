using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project.Models
{
  public class Planet : Room
  {
    Dictionary<string, Room> Rooms;
    public Planet(string name, string description) : base(name, description, false)
    {
      Rooms = new Dictionary<string, Room>();
    }
    public virtual bool GoodMove(Player player, string room)
    {
      player.Move++;
      return true;
    }

  }
}