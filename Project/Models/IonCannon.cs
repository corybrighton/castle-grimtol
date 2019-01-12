using System;

namespace CastleGrimtol.Project.Models
{
  class IonCannon : Item
  {
    public IonCannon(string name, string description) : base(name, description, false)
    { }
    public override void use(Room room, Planet planet, Player player, GameService game)
    {
      Console.WriteLine("\n\tShooting the Ion Cannon. You made a great shot\n\tand disabled an AT-AT.");
    }
  }
}