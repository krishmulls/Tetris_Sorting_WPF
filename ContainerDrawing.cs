using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris_Sorting_WPF
{
    internal class ContainerDrawing
    {
        private const int START_X = 15;
        private const int START_Y = 385;

        private Canvas canvas;

        public ContainerDrawing(ref Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void draw(ref int[][] container)
        {
            /*
            * The Container Cells UI generation in the canvas
            */
            int numRows = container.Length;
            int numCols = container[0].Length;
            double rectWidth = 20;
            double rectHeight = 20;
            double margin = 4;

            for (int i = numRows - 1; i >= 0; i--)
            {
                for (int j = 0; j < numCols; j++)
                {
                    // Create a new rectangle for each element in the array
                    Rectangle rect = new Rectangle();
                    rect.Width = rectWidth;
                    rect.Height = rectHeight;

                    // Set the fill color based on the value in the array
                    int value = container[i][j];
                    rect.Fill = new SolidColorBrush(GetColor(value));

                    // Set the position of the rectangle on the canvas
                    double x = START_X + j * (rectWidth + margin);
                    double y = START_Y - (numRows - i - 1) * (rectHeight + margin);
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);

                    // Add the rectangle to the canvas
                    canvas.Children.Add(rect);
                }
            }
        }

        private static Color GetColor(int value)
        {
            // Return a color based on the value in the array
            switch (value)
            {
                case 0:
                    return Colors.Black;
                case 1:
                    return Colors.DarkSlateGray;
                case 2:
                    return Colors.Aqua;
                case 3:
                    return Colors.Teal;
                case 4:
                    return Colors.LightSeaGreen;
                default:
                    return Colors.Red;
            }
        }
    }
}
