using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlareChallenge
{
    public class MazeGenerator
    {
        /// <summary>
        /// Represents the possible directions for movement within a maze.
        /// </summary>
        public enum Direction
        {
            None = 0,
            North = 1,
            South = 2,
            East = 4,
            West = 8
        }

        private int rows;
        private int columns;
        private int[,] grid;

        readonly Dictionary<Direction, int> HorizontalDirection = new()
        {
            {Direction.North, 0},
            {Direction.South, 0},
            {Direction.East, 1},
            {Direction.West, -1},
        };

        readonly Dictionary<Direction, int> VerticalDirection = new()
        {
           {Direction.North, -1},
            {Direction.South, 1},
            {Direction.East, 0},
            {Direction.West, 0},
        };

        readonly Dictionary<Direction, Direction> ReverseDirection = new()
        {
            {Direction.North, Direction.South},
            {Direction.South, Direction.North},
            {Direction.East, Direction.West},
            {Direction.West, Direction.East},
        };


        /// <summary>
        /// Returns an array containing all possible directions for navigating within the maze.
        /// </summary>
        /// <returns>An array of Direction enum values representing North, South, East, and West.</returns>
        private static Direction[] GetAllDirections()
        {
            return [Direction.North, Direction.South, Direction.East, Direction.West];
        }

        /// <summary>
        /// Checks if a given row and column index are within the maze boundaries.
        /// </summary>
        /// <param name="row">The row index to check.</param>
        /// <param name="col">The column index to check.</param>
        /// <returns>True if the row and column are within the maze boundaries, False otherwise.</returns>
        private bool IsWithinMaze(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < columns;
        }


        /// <summary>
        /// Generates a maze data structure represented by a 2D integer array.
        /// </summary>
        /// <param name="rows">The desired number of rows in the maze.</param>
        /// <param name="columns">The desired number of columns in the maze.</param>
        /// <returns>A 2D integer array representing the generated maze.</returns>
        public int[,] GenerateMaze(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            grid = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid[i, j] = (int)Direction.None;
                }
            }
            int startRow = new Random().Next(0, rows);
            int startCol = new Random().Next(0, columns);

            CreatePassages(startRow, startCol);

            return grid;
        }

        /// <summary>
        /// This function recursively carves passages through the maze grid using a backtracking approach.
        /// </summary>
        /// <param name="row">The current row index in the maze grid.</param>
        /// <param name="col">The current column index in the maze grid.</param>
        private void CreatePassages(int row, int col)
        {
            var directions = GetAllDirections().OrderBy(x => Guid.NewGuid()).ToArray();
 
            foreach (Direction direction in directions)
            {
                int newCol = col + HorizontalDirection[direction];
                int newRow = row + VerticalDirection[direction];

                if (IsWithinMaze(newRow, newCol) && (grid[newRow, newCol] == (int)Direction.None))
                {
                    grid[row, col] |= (int)direction;
                    grid[newRow, newCol] |= (int)ReverseDirection[direction];

                    CreatePassages(newRow, newCol);
                }
            }
        }
    }
}
