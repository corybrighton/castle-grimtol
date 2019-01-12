using System;

namespace CastleGrimtol.Project.Models
{
  class Uniform : Item
  {
    public Uniform(string name, string description) : base(name, description)
    { }
    public override void use(Player player)
    {
      player.hasSTuniformOn = true;
    }
  }
}