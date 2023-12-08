using AoC_2023.Common;
using AoC_2023.Day8;
using NSubstitute;

namespace AoC_2023_Tests.Day8;

public class NetworkProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly NetworkProvider _subject;

    public NetworkProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new NetworkProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideNetworkAsync_WhenUsingExampleInput_ThenReturnsExpectedNetwork()
    {
        SetupRawInputProvider();

        var result = await _subject.ProvideNetworkAsync();

        result.Directions.Should().Be("LLR");
        result.Nodes.Should().HaveCount(3);
        result.Nodes.Should().Contain(x => x.Name == "BBB" && x.LeftNodeName == "AAA" && x.RightNodeName == "ZZZ");
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new List<string> {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        }.ToAsyncEnumerable());
    }
}