//productivity tips: GetConflicts needs to be cached. Use binary heap in the A*
//                   implement Point as a record, use linked list to save queen positions
//                   Parralel and Concurrent collection for getChildren
using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(
                queens: new[] {
                new Point(2,8), // 2,0
                new Point(5,1), // 5,1
                new Point(7,2), // 7,2
                new Point(0,4), // 0,3
                new Point(3,5), // 3,4
                new Point(4,8), // 4,6
                new Point(6,7), // 6,5
                new Point(1,7), // 1,7
                 }, new AStar());

            if( board.Solve() )
            Console.WriteLine($"Board took {board.GetIterations()} iterations to find the solution");
            

            else Console.WriteLine("Board wasn't solved");

            Console.WriteLine($"Final Board Results: \n{board.GetRepresentation()}");
        }
    }
}
