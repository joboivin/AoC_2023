
namespace AoC_2023.Day8;

internal class Day8Solver (INetworkProvider networkProvider, INetworkNavitagor networkNavitagor) : IDaySolver
{
    private readonly INetworkProvider _networkProvider = networkProvider;
    private readonly INetworkNavitagor _networkNavigator = networkNavitagor;

    public async Task<long> SolveAsync()
        => _networkNavigator.NavigateNetwork(await _networkProvider.ProvideNetworkAsync());

    public async Task<long> SolveBonusAsync()
        => _networkNavigator.NavigateNetworkBonus(await _networkProvider.ProvideNetworkAsync());
}