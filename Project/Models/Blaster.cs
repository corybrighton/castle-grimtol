using System;

namespace CastleGrimtol.Project.Models
{
  class Blaster : Item
  {
    public Blaster(string name, string description) : base(name, description)
    { }
    public override void use(Room room, Planet planet, Player player, GameService game)
    {
      planet.UseBlaster(room);
    }
  }
}