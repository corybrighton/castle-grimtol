using System;

namespace CastleGrimtol.Project.Models
{
  class Bolder : Item
  {
    public Bolder(string name, string description) : base(name, description, false)
    { }
    public override void use(Room room, Planet planet, Player player, GameService game)
    {
      Console.WriteLine("\n\tYou are hiding behind the large bolder.");
      room.PlaceToChange = true;
    }
  }
}
