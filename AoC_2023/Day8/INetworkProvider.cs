namespace AoC_2023.Day8;

internal interface INetworkProvider
{
    Task<Network> ProvideNetworkAsync();
}