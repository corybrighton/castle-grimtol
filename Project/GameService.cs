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
      CurrentRoom = hoth.briefing;
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
      Console.WriteLine(@"Echo Bace is under attack by the Galactic Empire. 
      You were just given the mission to infiltrate the Empire and bring back anything that would help in the war.");

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
                   88  88   88     88  88   88888888");
      Thread.Sleep(2000);
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine(@"
      
      
      
      
      A long time ago, in a galaxy 
      far, far away...");
      Thread.Sleep(2000);
      Console.ResetColor();
      Console.Clear();
      Console.WriteLine(@"
      Echo Bace is under attack by the Galactic Empire. 
      You were just given the mission to infiltrate the Empire and bring back anything that would help in the war.");
    }

    public void GetUserInput()
    {
      Console.Write("What would you like to do: ");
      string userInput = Console.ReadLine();
      string[] input = userInput.Split(' ');
      if (input.Length > 1)
      {
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
            Console.WriteLine(@"
            I do not understand. Use help for addional commands.");
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
            // to do
            Look();
            break;
          case "inventory":
            // to do list inventory
            Inventory();
            break;
          case "help":
            // to do show help
            Help();
            break;
          case "restart":
            Reset();
            break;
        }
      }

    }

    public void Go(string direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        Console.Clear();
      }
      else
      {
        Console.Clear();
        Console.WriteLine(@"Sorry you can not go that way.
        ");
      }
      Console.WriteLine(CurrentRoom.Description);
      GetUserInput();
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
        quit            -- Quit the game");
      GetUserInput();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      Console.WriteLine("Exit");
    }

    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}