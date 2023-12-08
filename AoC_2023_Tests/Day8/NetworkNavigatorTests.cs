using AoC_2023.Day8;

namespace AoC_2023_Tests.Day8;

public class NetworkNavigatorTests
{
    private readonly NetworkNavigator _subject = new NetworkNavigator();

    [Fact]
    public void NavigateNetwork_WhenUsingFirstExample_Then2StepsNeeded()
    {
        var nodes = new [] {
            new Node { Name = "AAA", LeftNodeName = "BBB", RightNodeName = "CCC"},
            new Node { Name = "BBB", LeftNodeName = "DDD", RightNodeName = "EEE"},
            new Node { Name = "CCC", LeftNodeName = "ZZZ", RightNodeName = "GGG"},
            new Node { Name = "DDD", LeftNodeName = "DDD", RightNodeName = "DDD"},
            new Node { Name = "EEE", LeftNodeName = "EEE", RightNodeName = "EEE"},
            new Node { Name = "GGG", LeftNodeName = "GGG", RightNodeName = "GGG"},
            new Node { Name = "ZZZ", LeftNodeName = "ZZZ", RightNodeName = "ZZZ"}
        };
        var directions = "RL";

        var result = _subject.NavigateNetwork(new Network { Directions = directions, Nodes = nodes});

        result.Should().Be(2);
    }

    [Fact]
    public void NavigateNetwork_WhenUsingSecondExample_Then6StepsNeeded()
    {
        var nodes = new [] {
            new Node { Name = "AAA", LeftNodeName = "BBB", RightNodeName = "BBB"},
            new Node { Name = "BBB", LeftNodeName = "AAA", RightNodeName = "ZZZ"},
            new Node { Name = "ZZZ", LeftNodeName = "ZZZ", RightNodeName = "ZZZ"}
        };
        var directions = "LLR";

        var result = _subject.NavigateNetwork(new Network { Directions = directions, Nodes = nodes });

        result.Should().Be(6);
    }

    [Fact]
    public void NavigateNetworkBonus_WhenUsingExample_Then6StepsNeeded()
    {
        var nodes = new [] {
            new Node { Name = "11A", LeftNodeName = "11B", RightNodeName = "XXX"},
            new Node { Name = "11B", LeftNodeName = "XXX", RightNodeName = "11Z"},
            new Node { Name = "11Z", LeftNodeName = "11B", RightNodeName = "XXX"},
            new Node { Name = "22A", LeftNodeName = "22B", RightNodeName = "XXX"},
            new Node { Name = "22B", LeftNodeName = "22C", RightNodeName = "22C"},
            new Node { Name = "22C", LeftNodeName = "22Z", RightNodeName = "22Z"},
            new Node { Name = "22Z", LeftNodeName = "22B", RightNodeName = "22B"},
            new Node { Name = "XXX", LeftNodeName = "XXX", RightNodeName = "XXX"}
        };
        var directions = "LR";

        var result = _subject.NavigateNetworkBonus(new Network { Directions = directions, Nodes = nodes });

        result.Should().Be(6);
    }
}