using BattleshipLiteLibrary.Models;


namespace BattleshipLiteLibrary;
public static class GameLogic
{
    public static void InitializeGrid(PlayerInfoModel playerInfo)
    {
        List<string> letters = new()
        {
            "A",
            "B",
            "C",
            "D",
            "E",
        };

        List<int> numbers = new()
        {
            1,
            2,
            3,
            4,
            5,
        };

        foreach (string letter in letters)
        {
            foreach (int number in numbers)
            {
                AddGridSpot(playerInfo, letter, number);
            }
        }
    }
    private static void AddGridSpot(PlayerInfoModel playerInfo, string letter, int number)
    {
        GridSpotModel spot = new()
        {
            SpotLetter = letter,
            SpotNumber = number,
            Status = GridSpotStatus.Empty
        };

        playerInfo.ShotGrid.Add(spot);
    }

    public static bool PlayerStillActive(PlayerInfoModel opponent)
    {
        bool isActive = false;

        foreach (var ship in opponent.ShipLocations)
        {
            if (ship.Status == GridSpotStatus.Sunk)
            {
                isActive = true;
            }
        }
        return isActive;
    }

    public static int GetShotCount(PlayerInfoModel winner)
    {
        int shotCount = 0;

        foreach (var shot in winner.ShotGrid)
        {
            if (shot.Status != GridSpotStatus.Empty)
            {
                shotCount++;
            }
        }

        return shotCount;
    }

    public static bool PlaceShip(PlayerInfoModel playerInfo, string? location)
    {
        (string row, int column) = SplitShot(location);

        bool isValidLocation = ValidateGridLocation(playerInfo, row, column);
        bool isSpotOpen = ValidateShipLocation(playerInfo, row, column);

        if (isValidLocation && isSpotOpen)
        {
            playerInfo.ShipLocations.Add(new GridSpotModel
            {
                SpotLetter = row.ToUpper(),
                SpotNumber = column,
                Status = GridSpotStatus.Ship
            });
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool ValidateShipLocation(PlayerInfoModel playerInfo, string row, int column)
    {
        bool isValidLocation = true;
        foreach(var ship in playerInfo.ShipLocations)
        {
            if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
            {
                isValidLocation = false;
            }
        }

        return isValidLocation;
    }

    private static bool ValidateGridLocation(PlayerInfoModel playerInfo, string row, int column)
    {
        bool isValidLocation = false;
        foreach (var ship in playerInfo.ShotGrid)
        {
            if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)
            {
                isValidLocation = true;
            }
        }

        return isValidLocation;
    }

    public static (string row, int column) SplitShot(string shotLocation)
    {
        char[] splitLocation = shotLocation.ToArray();

        if (shotLocation.Length != 2)
        {
            throw new ArgumentException("This was an invalid shot type.", nameof(shotLocation));
        }

        string row = char.ToString(splitLocation[0]);

        int column = int.Parse(splitLocation[1].ToString());

        return (row, column);
    }

    public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
    {
        bool isValidShot = false;
        foreach (var gridSpot in activePlayer.ShotGrid)
        {
            if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
            {
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    isValidShot = true;
                }
            }
        }

        return isValidShot;
    }
    // ------------------
    //  TIMESTAMP: 31:49
    // ------------------
    public static bool DetermineShotResults(PlayerInfoModel opponent, string row, int column)
    {
        throw new NotImplementedException();
    }

    public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isAHit)
    {
        throw new NotImplementedException();
    }
}

