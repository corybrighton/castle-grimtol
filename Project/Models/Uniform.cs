using System;

namespace CastleGrimtol.Project.Models
{
  class Uniform : Item
  {
    public Uniform(string name, string description) : base(name, description)
    { }
    public override void use(Room planet)
    {
      Console.WriteLine("\n\tShooting the Ion Cannon. You hit amoung a group\n\tof Strom Troopers.");
      planet.FirePlasmaCannon();
    }
  }
}