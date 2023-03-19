using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris_Sorting_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int[][] myArray = new int[][] {
            new int[] { 1, 2, 1, 1, 2, 1 },
            new int[] { 4, 5, 2, 1, 2, 1 },
            new int[] { 1, 2, 3, 1, 2, 1 },
            new int[] { 4, 5, 4, 1, 2, 1 },
            new int[] { 1, 2, 5, 1, 2, 1 },
            new int[] { 4, 5, 6, 1, 2, 1 },
            new int[] { 7, 8, 7, 1, 2, 1 },
            new int[] { 4, 5, 6, 1, 2, 1 },
            new int[] { 7, 8, 7, 1, 2, 1 }
        };
        public MainWindow()
        {
            InitializeComponent();
            GenerateRectangles(20,380);
        }
        private void GenerateRectangles(double startX, double startY)
        {
            int numRows = myArray.Length;
            int numCols = myArray[0].Length;
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
                    int value = myArray[i][j];
                    rect.Fill = new SolidColorBrush(GetColor(value));

                    // Set the position of the rectangle on the canvas
                    double x = startX + j * (rectWidth + margin);
                    double y = startY - (numRows- i - 1) * (rectHeight + margin);
                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);

                    // Add the rectangle to the canvas
                    canvas.Children.Add(rect);
                }
            }
        }


        private Color GetColor(int value)
        {
            // Return a color based on the value in the array
            switch (value)
            {
                case 1:
                    return Colors.Red;
                case 2:
                    return Colors.Blue;
                case 3:
                    return Colors.Green;
                case 4:
                    return Colors.Yellow;
                case 5:
                    return Colors.Purple;
                case 6:
                    return Colors.Orange;
                case 7:
                    return Colors.Black;
                case 8:
                    return Colors.Gray;
                case 9:
                    return Colors.White;
                default:
                    return Colors.Transparent;
            }
        }
    }
}
