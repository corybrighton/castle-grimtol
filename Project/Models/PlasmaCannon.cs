using System;

namespace CastleGrimtol.Project.Models
{
  class PlasmaCannon : Item
  {
    public PlasmaCannon(string name, string description) : base(name, description, false)
    { }
    public override void use(Room planet)
    {
      Console.WriteLine("\n\tShooting the Ion Cannon. You hit amoung a group\n\tof Strom Troopers.");
      planet.FirePlasmaCannon();
    }
  }
}