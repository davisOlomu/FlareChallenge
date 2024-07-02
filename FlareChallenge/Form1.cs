using System.Runtime.CompilerServices;

namespace FlareChallenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            int rows = 15;
            int columns = 15;
            MazeGenerator mazeGenerator = new();
            int[,] maze = mazeGenerator.GenerateMaze(rows, columns);
          
            DrawMaze(maze);
        }

        // <summary>
        /// Attempts to render the maze on the specified panel control.
        /// 
        /// </summary>
        /// <param name="maze">A 2D integer array representing the maze data structure.</param>
        private void DrawMaze(int[,] maze)
        {
            panel1.Refresh();
            int cellSize = 13; 
            Brush brush = new SolidBrush(Color.White);
            using Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {              
                    if (maze[i, j] == (int)MazeGenerator.Direction.North) 
                    {
                        g.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, j * i + cellSize);
                    }
                    if (maze[i, j] == (int)MazeGenerator.Direction.South)
                    {
                        g.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, j * i  + cellSize);
                    }
                    if (maze[i, j] == (int)MazeGenerator.Direction.East)
                    {
                        g.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, j * i + cellSize);
                    }
                    if (maze[i, j] == (int)MazeGenerator.Direction.West)
                    {
                        g.FillRectangle(Brushes.White, j * cellSize, i * cellSize, cellSize, j * i + cellSize);
                    }        
                }             
            }
        }
    }
}
