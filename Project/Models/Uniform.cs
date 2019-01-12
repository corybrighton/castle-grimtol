using System;

namespace CastleGrimtol.Project.Models
{
  class Uniform : Item
  {
    public Uniform(string name, string description) : base(name, description)
    { }
    public override void use(Room room, Planet planet, Player player, GameService game)
    {
      if (player.Inventory.Find(item => { return item.Name == "Uniform"; }) == null)
      {
        player.Inventory.Add(new Uniform("Uniform", "Use Storm Trooper Uniform."));
      }
      if (!room.PlaceToChange)
      {
        Console.WriteLine("\n\tYou were shot putting on the uniform. You should hid when you change.");
        game.Died();
      }
      else if (player.hasSTuniformOn = !player.hasSTuniformOn)
      {
        Console.WriteLine("\n\tYou put the Strom Trooper uniform on.");
      }
      else
      {
        Console.WriteLine("\n\t You have taken the Storm Trooper uniform off.");
      }

    }
  }
}