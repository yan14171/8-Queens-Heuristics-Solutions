using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queens.Interfaces;

namespace Queens.Game;

class Board
{
    public Board(Point[] queens, IAlgorithm algorithm)
    {
        _state = new StateNode(queens);
        _algorithm = algorithm;
    }

    StateNode _state;
    IAlgorithm _algorithm;

    public bool Solve()
    {
        return _algorithm.Solve(ref _state);
    }

    public int GetIterations()
    {
        return _state.Iterations;
    }

    public string GetRepresentation()
    {
        return _state.GetQueens().Select(n => n.ToString())
            .Aggregate((a, b) => a += $"\n{b}");
    }
}
