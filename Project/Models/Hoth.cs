namespace CastleGrimtol.Project.Models
{
  class Hoth : Planet
  {
    public Room briefing = new Room("Breifing Room", "You are in Echo Base breifing room there is a corador to the west and a door to the south.");
    public Room hanger = new Room("Hanger", "You are in Echo Base Spaceship Hanger with X-wings, Y-wings, snowspeeders, and transport ships being loaded to evacuate the base");
    public Room trench1 = new Room("Trench", "You are in the trench. To the East is more trench. There is a Plasma Cannon");
    public Room trench2 = new Room("Trench", "East and West is more Trench. There is a blaster");
    public Room trench3 = new Room("Trench", "To the West is more Trench. There is a Ion Cannon");
    public Room between1 = new Room("Between", "Space between the Rebels and Galatic Empire. Stormtroopers advaning.");
    public Room between2 = new Room("Between", "Space between the Rebels and Galatic Empire. Stormtroopers advaning.");
    public Room between3 = new Room("Between", "Space between the Rebels and Galatic Empire. Stormtroopers advaning.");
    public Room atat2 = new Room("ATAT controlled area", "AT-AT attacking, moving forward");
    public Room atat3 = new Room("ATAT controlled area", "AT-AT attacking, moving forward");
    public Hoth(string name, string description) : base(name, description)
    {
      // Build Map

      // Briefing Room
      briefing.AddExit("west", hanger);
      briefing.AddExit("south", trench2);
      // Hanger
      hanger.AddExit("east", briefing);
      hanger.AddExit("south", trench1);
      // Trench Area 1 (Room)
      trench1.AddExit("north", hanger);
      trench1.AddExit("south", between1);
      trench1.AddExit("east", trench2);
      // Trench Area 2 (Room)
      trench2.AddExit("north", briefing);
      trench2.AddExit("south", between2);
      trench2.AddExit("east", trench1);
      trench2.AddExit("west", trench3);
      // Trench Area 3 (Room)
      trench3.AddExit("south", between3);
      trench3.AddExit("east", trench2);
      // Fighting Area Between forces area 1 (Room)
      between1.AddExit("north", trench1);
      between1.AddExit("east", between2);
      // Fighting Area Between forces area 2 (Room)
      between2.AddExit("north", trench2);
      between2.AddExit("south", atat2);
      between2.AddExit("east", between1);
      between2.AddExit("west", between3);
      // Fighting Area Between forces area 3 (Room)
      between3.AddExit("north", trench3);
      between3.AddExit("south", atat3);
      between3.AddExit("east", between2);
      // AT-AT Controlled area 2 (Room)
      atat2.AddExit("north", between2);
      atat2.AddExit("east", atat3);
      // AT-At Controlled Area 3 (Room)
      atat3.AddExit("north", between3);
      atat3.AddExit("east", trench1);
      atat3.AddExit("west", trench3);
    }
  }
}