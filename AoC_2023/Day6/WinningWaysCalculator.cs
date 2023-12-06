namespace AoC_2023.Day6;

internal class WinningWaysCalculator : IWinningWaysCalculator
{
    public long CalculateWinningWays(Race race)
    {
        var totalNumberOfWays = race.Time + 1;
        var firstWinningWayIndex = -1;

        for(var i = 0; i < totalNumberOfWays; i++)
        {
            var distanceTraveled = i * (race.Time - i);

            if(distanceTraveled > race.Distance)
            {
                firstWinningWayIndex = i;
                break;
            }
        }

        return firstWinningWayIndex == -1 ? 0 : totalNumberOfWays - (2 * firstWinningWayIndex);
    }
}