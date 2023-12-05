namespace AoC_2023;

internal interface IDaySolver
{
    Task<long> SolveAsync();
    Task<long> SolveBonusAsync();
}