using Queens.Game;

namespace Queens.Interfaces;

interface IAlgorithm
{
    bool Solve(ref StateNode state);

    int F(StateNode state);
}
