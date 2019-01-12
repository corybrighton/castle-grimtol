using System;

namespace CastleGrimtol.Project.Models
{
  class IonCannon : Item
  {
    public IonCannon(string name, string description) : base(name, description, false)
    { }
    public override void use(Room planet)
    {
      Console.WriteLine("\n\tShooting a large bolt of plasma. You made a great shot\n\tand disabled an AT-AT.");
    }
  }
}