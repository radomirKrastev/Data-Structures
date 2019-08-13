namespace DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main()
        {
            var dimension = int.Parse(Console.ReadLine());
            var labyrinth = GetLabyrinth(dimension);

            var startRow = 0;
            var startCol = 0;
            var startPointFound = false;

            for (int r = 0; r < dimension; r++)
            {
                for (int c = 0; c < dimension; c++)
                {
                    if (labyrinth[r, c] == "*")
                    {
                        startRow = r;
                        startCol = c;
                        startPointFound = true;
                    }
                }

                if (startPointFound)
                {
                    break;
                }
            }

            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(new Cell(startRow, startCol, 0));

            while (cells.Count > 0)
            {
                Cell current = cells.Dequeue();
                var row = current.Row;
                var col = current.Col;
                var moves = current.Moves;
                //up
                if (row - 1 >= 0 && labyrinth[row - 1, col] == "0")
                {
                    labyrinth[row - 1, col] = (moves + 1).ToString();
                    cells.Enqueue(new Cell(row - 1, col, moves + 1));
                }
                //right
                if (col + 1 < labyrinth.GetLength(1) && labyrinth[row, col + 1] == "0")
                {
                    labyrinth[row, col + 1] = (moves + 1).ToString();
                    cells.Enqueue(new Cell(row, col + 1, moves + 1));
                }
                //down
                if (row + 1 < labyrinth.GetLength(0) && labyrinth[row + 1, col] == "0")
                {
                    labyrinth[row + 1, col] = (moves + 1).ToString();
                    cells.Enqueue(new Cell(row + 1, col, moves + 1));
                }
                //left
                if (col - 1 >= 0 && labyrinth[row, col - 1] == "0")
                {
                    labyrinth[row, col - 1] = (moves + 1).ToString();
                    cells.Enqueue(new Cell(row, col - 1, moves + 1));
                }
            }

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == "0")
                    {
                        labyrinth[i, j] = "u";
                    }

                    Console.Write(labyrinth[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static string[,] GetLabyrinth(int dimension)
        {
            string[,] labyrinth = new string[dimension, dimension];

            for (int r = 0; r < dimension; r++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int c = 0; c < dimension; c++)
                {
                    labyrinth[r, c] = line[c].ToString();
                }
            }

            return labyrinth;
        }
    }
}
