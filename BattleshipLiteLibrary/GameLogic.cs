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

        foreach(string letter in letters)
        {
            foreach(int number in numbers)
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

    public static bool PlaceShip(PlayerInfoModel playerInfo, string location)
    {
        throw new NotImplementedException();
    }
}

