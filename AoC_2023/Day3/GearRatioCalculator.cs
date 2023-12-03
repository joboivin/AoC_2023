
namespace AoC_2023.Day3;

internal class GearRatioCalculator : IGearRatioCalculator
{
    private readonly IDictionary<string, IList<int>> _partsNumbersByGear = new Dictionary<string, IList<int>>();

    public int CalculateGearRatio(IEnumerable<Part> parts)
    {
        foreach(var part in parts)
        {
            foreach(var nearbyGear in part.NearbyGears)
            {
                if(!_partsNumbersByGear.ContainsKey(nearbyGear))
                    _partsNumbersByGear.Add(nearbyGear, new List<int>());

                _partsNumbersByGear[nearbyGear].Add(part.Number);
            }
        }

        return _partsNumbersByGear.Values.Where(x => x.Count == 2).Select(x => x[0] * x[1]).Sum();
    }
}