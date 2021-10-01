using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    interface IAlgorithm
    {
        bool Solve(ref StateNode state);

        int F(StateNode state);
    }
}
