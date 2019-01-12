using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {

    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    private Planet CurrentPlanet { get; set; }

    public GameService()
    {
      StartGame();
    }

    //Start Setup
    //Initializes the game, creates rooms, their exits, and add items to rooms
    public void Setup()
    {
      CurrentPlayer = new Player();
      Hoth hoth = new Hoth("Hoth", "Ice Planet");
      CurrentPlanet = hoth;
      CurrentRoom = hoth.Briefing;
    }

    //Setup and Starts the Game loop
    public void StartGame()
    {
      Setup();
      OpeningScreen();
      GetUserInput();
    }

    //Restarts the game 
    public void Reset()
    {
      Setup();
      Console.Clear();
      StartLine();
      GetUserInput();
    }

    // Opening Screen
    private void OpeningScreen()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.BackgroundColor = ConsoleColor.Black;
      Console.Clear();
      Console.WriteLine(@"
        


        
                      88888888888  888    88888
                     88      88   88 88   88  88
                      8888   88  88   88  88888
                         88  88 888888888 88   88
                 888888888   88 88     88 88    8888888
     
                 88  88  88    888     88888    8888888
                 88  88  88   88 88    88  88  88
                 88 8888 88  88   88   88888    8888
                  888  888  888888888  88  88      88
                   88  88   88     88  88   88888888




");
      Thread.Sleep(2000);
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine(@"
      
      

      
      
        A long time ago, in a galaxy 
        far, far away...




");
      Thread.Sleep(2000);
      Console.ResetColor();
      StartLine();
    }

    public void StartLine()
    {
      Console.Clear();
      Console.WriteLine("\n\tEcho Bace is under attack by the Galactic Empire.");
      Console.WriteLine("\tYou were just given the mission to infiltrate the Empire");
      Console.WriteLine("\tand bring back anything that would help in the war.");
    }

    public void Died()
    {
      Console.Write("\n\tYou have Died would you like to play again(y/n):");
      string answer = Console.ReadLine();
      switch (answer)
      {
        case "y":
          Reset();
          break;
        default:
          Quit();
          break;
      }
    }

    public void GetUserInput()
    {
      Console.Write("\n\tWhat would you like to do: ");
      string userInput = Console.ReadLine();
      string[] input = userInput.Split(' ');
      if (input.Length > 1)
      {
        if (input.Length > 2)
        {
          input[1] = input[1] + " " + input[2];
        }
        switch (input[0])
        {
          case "go":
            Go(input[1]);
            break;
          case "take":
            // to do take an Item
            TakeItem(input[1]);
            break;
          case "use":
            // to do use an Item
            UseItem(input[1]);
            break;
          default:
            Console.WriteLine("\n\tI do not understand.\n You can use help for addional commands.");
            GetUserInput();
            break;
        }
      }
      else
      {
        switch (input[0])
        {
          case "quit":
            Quit();
            break;
          case "look":
            Look();
            break;
          case "inventory":
            Inventory();
            break;
          case "help":
            Help();
            break;
          case "restart":
            Reset();
            break;
          default:
            Look();
            break;
        }
      }

    }

    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        if (CurrentPlanet.GoodMove(CurrentPlayer, CurrentRoom.Name))
        {
          Console.Clear();
          Console.WriteLine("\n\t" + CurrentRoom.Description);
          GetUserInput();
        }
        else
        {
          Died();
        }
      }
      else
      {
        Console.Clear();
        Console.WriteLine("\n\tSorry you can not go that way.\n");
        Console.WriteLine("\n\t" + CurrentRoom.Description);
        GetUserInput();
      }
    }

    public void Help()
    {
      Console.Clear();
      Console.WriteLine(@"
  Options:
    go 'direction'  -- Go north, east, south, or west
    take 'item'     -- Take an item that you find
    use 'item'      -- Use an item to do something
    inventory       -- See the items you have
    look            -- Look around and see what is there
    restart         -- Restart the game
    quit            -- Quit the game");
      GetUserInput();
    }

    public void Inventory()
    {
      Console.Clear();
      Console.WriteLine();
      Console.WriteLine("\n\tYou have: ");
      foreach (var item in CurrentPlayer.Inventory)
      {
        Console.WriteLine($"\t{item.Name}  --  {item.Description}");
      }
      GetUserInput();
    }

    public void Look()
    {
      Console.Clear();
      Console.WriteLine();
      Console.WriteLine("\n\t" + CurrentRoom.Description);
      if (CurrentRoom.Items.Count > 0)
      {
        Console.WriteLine("\n\tThere is");
        foreach (var item in CurrentRoom.Items)
        {
          Console.WriteLine("\t" + item.Name);
        }
      }
      GetUserInput();
    }

    public void Quit()
    {
      Console.WriteLine("Exit");
    }

    public void TakeItem(string itemName)
    {
      Item objectToTake = CurrentRoom.Items.Find(it => { return itemName.Equals(it.Name); });
      if (objectToTake == null)
      {
        Console.WriteLine("Sorry did not understand what you wanted to take.");
      }
      else if (objectToTake.Takeable)
      {
        CurrentPlayer.Inventory.Add(objectToTake);
        CurrentRoom.Items.Remove(objectToTake);
        Console.WriteLine($"\n\tYou have a {objectToTake.Name}");
      }
      else
      {
        Console.WriteLine("\n\tThat will break your back. You leave it.");
      }
      GetUserInput();
    }

    public void UseItem(string itemName)
    {
      Console.Clear();
      var toUse = CurrentPlayer.Inventory.Find(it => { return itemName.ToUpper().Equals(it.Name.ToUpper()); });
      if (toUse != null)
      {
        Console.WriteLine($"\n\tUsing {toUse.Name}");
        toUse.use(CurrentPlanet);
      }
      else if ((toUse = CurrentRoom.Items.Find(it => { return itemName.ToUpper().Equals(it.Name.ToUpper()); })) != null)
      {
        Console.WriteLine($"\n\tUsing {toUse.Name}");
        toUse.use(CurrentPlanet);
      }
      else
      {
        Console.WriteLine("\n\tCan not use that.");
      }
      GetUserInput();
    }
  }
}