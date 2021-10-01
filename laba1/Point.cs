using System;

namespace laba1
{
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
            return this.x == other.x && this.y == other.y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point ? this.Equals((Point)obj) : false;
        }

        public override int GetHashCode()
        {
            // Prevent XOR commutative property
            return (int)(x ^ (2L - y));
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.x, this.y);
        }

        public string ToString(IFormatProvider provider)
        {
            return string.Format(provider, "[{0}, {1}]", this.x, this.y);
        }

        #endregion

        #region Others

        public Point Add(int offsetX, int offsetY)
        {
            return new Point(this.x + offsetX, this.y + offsetY);
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
}

