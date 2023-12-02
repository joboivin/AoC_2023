namespace AoC_2023.Day2;

internal interface IGameProvider
{
    Game ProvideGame(string line);
}