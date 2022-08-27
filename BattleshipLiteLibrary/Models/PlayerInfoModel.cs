
namespace BattleshipLiteLibrary.Models;

public class PlayerInfoModel
{
    public string Name { get; set; }
    public List<GridSpotModel> ShipLocations { get; set; } = new();
    public List<GridSpotModel> ShotGrid { get; set; } = new();

}

