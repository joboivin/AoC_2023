using AoC_2023.Common;

namespace AoC_2023.Day5;

internal class AlmanacProvider(IRawInputProvider rawInputProvider) : IAlmanacProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public async Task<Almanac> ProvideAlmanacAsync()
    {
        var inputAsList = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
        
        var almanac = new Almanac
        {
            Seeds = inputAsList[0][7..].Split(' ').Select(x => long.Parse(x)).ToList(),
            Maps = ProvideMaps(inputAsList[2..]).ToList()
        };

        return almanac;
    }

    private IEnumerable<Map> ProvideMaps(IList<string> mapLines)
    {
        var newMap = true;
        Map map = null;

        for(var i = 0; i < mapLines.Count; i++)
        {
            if(newMap)
            {
                newMap = false;
                map = new Map {Entries = new List<MapEntry>()};
                continue;
            }

            if(string.IsNullOrWhiteSpace(mapLines[i]))
            {
                newMap = true;
                yield return map;
                continue;
            }

            var values = mapLines[i].Split(' ');
            map.Entries.Add(new MapEntry {
                 DestinationRangeStart = long.Parse(values[0]), 
                 SourceRangeStart = long.Parse(values[1]), 
                 RangeLength = long.Parse(values[2])});
        }

        yield return map;
    }
}