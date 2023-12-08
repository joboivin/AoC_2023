using AoC_2023.Common;

namespace AoC_2023.Day8;

internal class NetworkProvider (IRawInputProvider rawInputProvider) : INetworkProvider
{
    private readonly IRawInputProvider _rawInputProvider = rawInputProvider;

    public async Task<Network> ProvideNetworkAsync()
    {
        var lines = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();

        return new Network {
            Directions = lines[0],
            Nodes = ProvideNodes(lines[2..]).ToList()
        };
    }

    private static IEnumerable<Node> ProvideNodes(List<string> nodesLines)
    {
        const int nodeNameBeginning = 0;
        const int leftNodeNameBeginning = 7;
        const int rightNodeNameBeginning = 12;
        const int nodeNameLength = 3;

        return nodesLines.Select(x => new Node{
            Name = x.Substring(nodeNameBeginning, nodeNameLength),
            LeftNodeName = x.Substring(leftNodeNameBeginning, nodeNameLength),
            RightNodeName = x.Substring(rightNodeNameBeginning, nodeNameLength)
        });
    }
}