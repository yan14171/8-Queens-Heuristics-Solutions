using System;

namespace Queens.Game;

public struct Point : IEquatable<Point>
{
    #region Fields

    public static readonly Point Zero = new Point();

    private readonly int x;
    private readonly int y;

    #endregion

    #region Properties

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    #endregion

    #region Constructor

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    #endregion

    #region Methods

    public bool Equals(Point other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object obj)
    {
        return obj is Point ? Equals((Point)obj) : false;
    }

    public override int GetHashCode()
    {
        // Prevent XOR commutative property
        return (int)(x ^ 2L - y);
    }

    public override string ToString()
    {
        return string.Format("[{0}, {1}]", x, y);
    }

    public string ToString(IFormatProvider provider)
    {
        return string.Format(provider, "[{0}, {1}]", x, y);
    }

    #endregion

    #region Others

    public Point Add(int offsetX, int offsetY)
    {
        return new Point(x + offsetX, y + offsetY);
    }

    #endregion

    #region Operators

    public static bool operator ==(Point a, Point b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Point a, Point b)
    {
        return !a.Equals(b);
    }

    #endregion
}

