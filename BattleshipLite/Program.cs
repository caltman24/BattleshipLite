using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;


WelcomeMessage();
PlayerInfoModel player1 = CreatePlayer("Player 1");
PlayerInfoModel player2 = CreatePlayer("Player 2");

Console.ReadLine();

static void WelcomeMessage()
{
    Console.WriteLine("Welcome to Battleship Lite");
    Console.WriteLine("Created by Corbyn Altman\n");
}

static PlayerInfoModel CreatePlayer(string playerName)
{
    PlayerInfoModel playerInfo = new();
    Console.WriteLine($"player information for { playerName }");

    // Ask the user for their name
    playerInfo.Name = AskUserForName();
    // Load up the shot grid
    GameLogic.InitializeGrid(playerInfo);

    // Ask the user for their 5 ship placements
    PlaceShips(playerInfo);

    // Clear
    Console.Clear();

    return playerInfo;
}

static string AskUserForName()
{    
    Console.Write("Enter your name: ");
    return Console.ReadLine();
}

static void PlaceShips(PlayerInfoModel playerInfo)
{
    do
    {
        Console.Write($"Where do you want to place ship number {playerInfo.ShipLocations.Count + 1}: ");
        string location = Console.ReadLine();

        bool isValidLocation = GameLogic.PlaceShip(playerInfo, location);

        if (!isValidLocation)
        {
            Console.WriteLine("That is not a valid location. Try again");
        }
    } while (playerInfo.ShipLocations.Count < 5);
}

