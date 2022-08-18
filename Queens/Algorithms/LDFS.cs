using System;
using System.Collections.Generic;
using Queens.Game;
using Queens.Interfaces;

namespace Queens.Algorithms;

class LDFS : IAlgorithm
{
    public int F(StateNode state)
    {
        return -1;
    }

    public bool Solve(ref StateNode state)
    {
        int allStates = 1;
        Stack<StateNode> states = new Stack<StateNode>();
        states.Push(state);
        StateNode crntState = state;

        while (!crntState.IsSuccess() && states.Count > 0)
        {
            if (!(crntState.Iterations == 4))
            {
                foreach (var child in crntState.GetChildren(true))
                {
                    allStates++;
                    states.Push(child);
                }
            }
            crntState = states.Pop();
        }

        state = crntState;

        Console.WriteLine($"Algorithm took {allStates} states and has {states.Count} states saved in memory");

        if (crntState.IsSuccess())
            return true;
        return false;
    }
}
