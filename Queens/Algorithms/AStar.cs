using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queens.Game;
using Queens.Interfaces;

namespace Queens.Algorithms
{
    class AStar : IAlgorithm
    {
        public int F(StateNode state)
        {
            return G(state) + H(state);
        }

        public bool Solve(ref StateNode state)
        {
            int allStates = 1;
            List<StateNode> openSet = new List<StateNode>();
            HashSet<StateNode> closedSet = new HashSet<StateNode>();
            openSet.Add(state);

            while (openSet.Count() > 0)
            {

                StateNode currentNode = openSet[0];
                for (int i = 0; i < openSet.Count; i++)
                {
                    if (F(openSet[i]) < F(currentNode) || F(openSet[i]) == F(currentNode) && G(openSet[i]) < G(currentNode))
                        currentNode = openSet[i];
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode.IsSuccess())
                {
                    state = currentNode;
                    Console.WriteLine($"Seen {allStates} at all. Saved in memory {closedSet.Count} states");
                    return true;
                }
                foreach (var child in currentNode.GetChildren(false))
                {
                    allStates++;
                    if (closedSet.Contains(child))
                        continue;

                    if (!openSet.Contains(child))
                    {
                        child.SetParent(currentNode);
                        openSet.Add(child);
                    }
                }
            }

            Console.WriteLine($"Seen ${allStates} at all. Saved in memory {closedSet.Count} sets");
            return false;
        }


        int G(StateNode state)
        {
            return state.Conflicts;
        }

        int H(StateNode state)
        {
            return state.Iterations;
        }
    }
}
