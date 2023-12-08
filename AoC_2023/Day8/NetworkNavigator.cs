
namespace AoC_2023.Day8;

internal class NetworkNavigator : INetworkNavitagor
{
    private const string NetworkBeginning = "AAA";
    private const string NetworkEnd = "ZZZ";

    public long NavigateNetwork(Network network)
    {
        var networkAsDictionnary = network.Nodes.ToDictionary(x => x.Name);
        
        return NavigateNetwork(networkAsDictionnary, network.Directions, NetworkBeginning, x => x == NetworkEnd);
    }

    private static long NavigateNetwork(IDictionary<string, Node> network, string directions, string beginning, Func<string, bool> isAtNetworkEnd)
    {
        var numberOfSteps = 0;
        var currentNode = network[beginning];
        var numberOfDirections = directions.Length;

        while(!isAtNetworkEnd(currentNode.Name))
        {
            var direction = directions[numberOfSteps % numberOfDirections];

            if(direction == 'L')
                currentNode = network[currentNode.LeftNodeName];
            else
                currentNode = network[currentNode.RightNodeName];

            numberOfSteps++;
        }

        return numberOfSteps;
    }

    public long NavigateNetworkBonus(Network network)
    {
        var networkAsDictionnary = network.Nodes.ToDictionary(x => x.Name);
        var allStartingNodes = networkAsDictionnary.Keys.Where(x => x.EndsWith('A'));

        var numberOfStepsByStartingNode = allStartingNodes.Select(x => NavigateNetwork(networkAsDictionnary, network.Directions, x, y => y.EndsWith('Z')));

        return DetermineLeastCommonMultiple(numberOfStepsByStartingNode);
    }

    private static long DetermineLeastCommonMultiple(IEnumerable<long> numbers)
	{
	    var sortedNumbers = numbers.ToList();
        sortedNumbers.Sort();

		var leastCommonMultiple = sortedNumbers[0];
		
		for (var i = 1; i < sortedNumbers.Count; i++)
            leastCommonMultiple = DetermineLeastCommonMultiple(leastCommonMultiple, sortedNumbers[i]);

        return leastCommonMultiple;
	}

    private static long DetermineLeastCommonMultiple(long firstNumber, long secondNumber)
	{
		var firstNumberTemp = firstNumber;
		var secondNumberTemp = secondNumber;
		
		while (firstNumberTemp != secondNumberTemp)
		{
			while (firstNumberTemp < secondNumberTemp)
			{
				firstNumberTemp += firstNumber;
			}
			
			while (secondNumberTemp < firstNumberTemp)
			{
				secondNumberTemp += secondNumber;
			}
		}
		
		return firstNumberTemp;
	}
}