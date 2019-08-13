namespace DistanceInLabyrinth
{
    public class Cell
    {
        public Cell (int row, int col, int moves)
        {
            this.Row = row;
            this.Col = col;
            this.Moves = moves;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Moves { get; set; }
    }
}
