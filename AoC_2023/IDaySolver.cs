namespace AoC_2023;

internal interface IDaySolver
{
    Task<int> SolveAsync();
    Task<int> SolveBonusAsync();
}