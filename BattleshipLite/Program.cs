using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;

WelcomeMessage();

PlayerInfoModel activePlayer = CreatePlayer("Player 1");
PlayerInfoModel opponent = CreatePlayer("Player 2");

PlayerInfoModel? winner = null;

do
{
    DisplayShotGrid(activePlayer);

    RecordPlayerShot(activePlayer, opponent);

    bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

    if (doesGameContinue)
    {
        // Swap using a tuple
        (activePlayer, opponent) = (opponent, activePlayer);
    }
    else
    {
        winner = activePlayer;
    }

    // Display score

} while (winner == null);

IdentifyWinner(winner);


Console.ReadLine();

static void IdentifyWinner(PlayerInfoModel winner)
{
    Console.WriteLine($"Congratulations to {winner.Name} for winning!");
    Console.WriteLine($"{winner.Name} took {GameLogic.GetShotCount(winner)} shots");
}

// -----------------------
// Video timestamp: 47:52
// -----------------------

static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
{
    // Ask for a shot (B2)

    // Determine the row / col of the shot. (split it apart)

    // Determne if the shot is valid

    // Determine the results

    // Record results
}

static void DisplayShotGrid(PlayerInfoModel activePlayer)
{
    string currentRow = activePlayer.ShotGrid[0].SpotLetter; // A

    foreach (GridSpotModel spot in activePlayer.ShotGrid)
    {

        if (currentRow != spot.SpotLetter)
        {
            Console.WriteLine();
            currentRow = spot.SpotLetter;
        }

        if (spot.Status == GridSpotStatus.Empty)
        {
            Console.Write($" {spot.SpotLetter}{spot.SpotNumber} ");
        }
        else if (spot.Status == GridSpotStatus.Hit)
        {
            Console.Write(" X ");
        }
        else if (spot.Status == GridSpotStatus.Miss)
        {
            Console.Write(" O ");
        }
        else
        {
            Console.Write(" ? ");
        }

    }
}

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
    string? name = string.Empty;

    do
    {
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
    } while (string.IsNullOrEmpty(name));

    return name;
}

static void PlaceShips(PlayerInfoModel playerInfo)
{
    do
    {
        Console.Write($"Where do you want to place ship number {playerInfo.ShipLocations.Count + 1}: ");
        string? location = Console.ReadLine();
        
        bool isValidLocation = GameLogic.PlaceShip(playerInfo, location);

        if (!isValidLocation)
        {
            Console.WriteLine("That is not a valid location. Try again");
        }

    } while (playerInfo.ShipLocations.Count < 5);
}


