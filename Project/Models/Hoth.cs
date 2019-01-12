using System;
using System.Threading;

namespace CastleGrimtol.Project.Models
{
  class Hoth : Planet
  {
    public Room Briefing = new Room("Breifing Room", "You are in Echo Base breifing room\n\tthere is a corador to the west and a door to the south.");
    public Room Hanger = new Room("Hanger", "You are in Echo Base Spaceship Hanger with\n\tX-wings, Y-wings, snowspeeders, and transport ships \n\tbeing loaded to evacuate the base.");
    public Room Trench1 = new Room("Trench", "You are in the trench. To the East \n\tis more trench. The Empire is attacking \n\tfrom the south. There is a Plasma Cannon.");
    public Room Trench2 = new Room("Trench", "You are in the trench. To the East \n\tand the West is more Trench. The Empire is attacking from the south.");
    public Room Trench3 = new Room("Trench", "You are in the trench. To the West \n\tis more Trench. The Empire is attacking \n\tfrom the south. There is a Ion Cannon.");
    public Room Between1 = new Room("Between", "There is a rock wall to the west. \n\tSpace between the Rebels and Galatic Empire. Stormtroopers advaning.");
    public Room Between2 = new Room("Between", "You are in the space between the Rebels and \n\tGalatic Empire. Stormtroopers advaning.");
    public Room Between3 = new Room("Between", "There is a clift to the east of you.\n\t You are in the space between the Rebels and \n\tGalatic Empire. Stormtroopers advaning.");
    public Room ATAT2 = new Room("AT-AT controlled area 2", "AT-AT attacking, moving forward!");
    public Room ATAT3 = new Room("AT-AT controlled area 3", "AT-AT attacking, moving forward!");
    public bool PlasmaCannonFired { get; set; } = false;
    public Hoth(string name, string description) : base(name, description)
    {
      // Build Map

      // Briefing Room
      Briefing.AddExit("west", Hanger);
      Briefing.AddExit("south", Trench2);
      // Hanger
      Hanger.AddExit("east", Briefing);
      Hanger.AddExit("south", Trench1);
      // Trench Area 1 (Room)
      Trench1.AddExit("north", Hanger);
      Trench1.AddExit("south", Between1);
      Trench1.AddExit("east", Trench2);
      // Trench Area 2 (Room)
      Trench2.AddExit("north", Briefing);
      Trench2.AddExit("south", Between2);
      Trench2.AddExit("east", Trench3);
      Trench2.AddExit("west", Trench1);
      // Trench Area 3 (Room)
      Trench3.AddExit("south", Between3);
      Trench3.AddExit("west", Trench2);
      // Fighting Area Between forces area 1 (Room)
      Between1.AddExit("north", Trench1);
      Between1.AddExit("east", Between2);
      // Fighting Area Between forces area 2 (Room)
      Between2.AddExit("north", Trench2);
      Between2.AddExit("south", ATAT2);
      Between2.AddExit("east", Between3);
      Between2.AddExit("west", Between1);
      // Fighting Area Between forces area 3 (Room)
      Between3.AddExit("north", Trench3);
      Between3.AddExit("south", ATAT3);
      Between3.AddExit("west", Between2);
      // AT-AT Controlled area 2 (Room)
      ATAT2.AddExit("north", Between2);
      ATAT2.AddExit("east", ATAT3);
      // AT-At Controlled Area 3 (Room)
      ATAT3.AddExit("north", Between3);
      ATAT3.AddExit("west", ATAT2);

      //Items in Areas
      Hanger.AddItem(new Item("R5-D4", "Astromec Droid great for all uses."));
      Trench1.AddItem(new PlasmaCannon("Plasma Cannon", "Large Cannon"));
      Trench3.AddItem(new IonCannon("Ion Cannon", "Large Cannon"));
      Between2.AddItem(new Item("Large Bolder", "Great for hiding behind", false));
    }

    public override bool GoodMove(Player player, string room)
    {
      int baseDestoried = 10;
      player.Move++;
      if (player.Move == baseDestoried)
      {
        if (room == Briefing.Name)
        {
          Console.WriteLine("\n\tThe Base has been destoried. You were in the \n\tthe room that was hit by laser cannons.");
          return false;
        }
        ChangeMap();
      }
      if ((room == Between1.Name || room == Between2.Name || room == Between3.Name) && !PlasmaCannonFired)
      {
        Console.Clear();
        Console.WriteLine("\n\tYou crazy charging an army?");
        return false;
      }

      if (player.Move < baseDestoried && room.Equals("AT-AT controlled area 2"))
      {
        Console.WriteLine("\n\tYou were in the wrong place at the wrong time.\n\tYou were smashed by an AT-AT.");
        return false;
      }
      else
      {
        return true;
      }

    }
    public void ChangeMap()
    {
      Console.WriteLine("\n\tEcho Base has been destroyed.\n\n");
      Thread.Sleep(1500);
      ATAT2.Description = "\n\tAT-AT are moving back to ships.";
      ATAT3.Description = "\n\tAT-AT are moving back to ships.";
      Briefing.Description = "\n\tEcho Base has been destoryed. This room is left burning.\n\tGood thing you weren't here.";
      Hanger.Description = "\n\tThe hanger has been overrun by Stromtroopers.";
      Between1.Description = "\n\tStormtroopers are guarding this area.";
      Between2.Description = "\n\tStormtroopers are guarding this area.";
      Between3.Description = "\n\tStormtroopers are guarding this area.";
    }

    public override void FirePlasmaCannon()
    {
      Between2.AddItem(new Item("Uniform", "It didn't help the Storm Tooper."));
      PlasmaCannonFired = true;
    }
  }
}