using System;
using System.Collections.Generic;
using System.Linq;

namespace Queens.Game;

class StateNode : IComparable
{
    public StateNode(IEnumerable<Point> queens)
    {
        _queens = queens.ToList();
    }

    public StateNode(IEnumerable<Point> queens, StateNode parent)
    {
        _queens = queens.ToList();
        _parent = parent;
    }

    public StateNode()
    {

    }

    StateNode _parent;

    IEnumerable<Point> _queens;

    int _conflicts = -1, _iterations = -1;

    public int Conflicts
    {
        get
        {
            if (_conflicts == -1)
                _conflicts = GetConflicts();

            return _conflicts;
        }
    }

    public int Iterations
    {
        get
        {
            if (_iterations == -1)
                _iterations = GetIterations();

            return _iterations;
        }
    }

    public bool IsSuccess()
    {
        return Conflicts == 0;
    }

    public IEnumerable<StateNode> GetChildren(bool setParent)
    {
        IEnumerable<StateNode> children = new List<StateNode>();

        foreach (Point queen in _queens)
        {
            if (setParent)
                children = children.Concat(GetNeighbourSets(queen).Select(n => new StateNode(n, this)));
            else
                children = children.Concat(GetNeighbourSets(queen).Select(n => new StateNode(n)));
        }

        return children;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is StateNode)) return 0;

        return -((obj as StateNode).GetConflicts() - GetConflicts());
    }

    public void SetParent(StateNode parent) => _parent = parent;

    public IEnumerable<Point> GetQueens()
    {
        foreach (var item in _queens)
        {
            yield return item;
        }
    }

    #region private

    IEnumerable<IEnumerable<Point>> GetNeighbourSets(Point queen)
    {
        IEnumerable<Point> crnt = new List<Point>();
        for (int i = 0; i < 8; i++)
        {
            if (queen.Y != i)
            {
                crnt = _queens.Where(n => n != queen)
                    .Append(new Point(queen.X, i));
                yield return crnt;
            }
        }
    }

    int GetConflicts()
    {
        bool rowCheck, colCheck, rdiagCheck, ldiagCheck;
        int cons = 0;
        HashSet<int> rowNums = new HashSet<int>(),
            colNums = new HashSet<int>(),
            ldiagNums = new HashSet<int>(),
            rdiagNums = new HashSet<int>();

        foreach (var queen in _queens)
        {
            rowCheck = rowNums.Add(queen.Y);
            colCheck = colNums.Add(queen.X);
            rdiagCheck = rdiagNums.Add(queen.X + queen.Y);
            ldiagCheck = ldiagNums.Add(queen.X - queen.Y);

            if (!rowCheck) cons++;
            if (!colCheck) cons++;
            if (!rdiagCheck) cons++;
            if (!ldiagCheck) cons++;
        }

        return cons;
    }

    int GetIterations()
    {
        StateNode crntNode = _parent;
        int cnt = 0;

        while (crntNode != null)
        {
            cnt++;
            crntNode = crntNode._parent;
        }

        return cnt;
    }
    #endregion
}