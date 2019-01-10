using System.Collections.Generic;

namespace CastleGrimtol.Project.Models
{
  class Planet : Room
  {
    Dictionary<string, Room> Rooms;
    public Planet(string name, string description) : base(name, description)
    {
      Rooms = new Dictionary<string, Room>();
    }
  }
}