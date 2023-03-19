using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


        private int[][] piece1 = { new int[] { 1, 0, 0 }, new int[] { 1, 1, 1 } };
        private int[][] piece2 = { new int[] { 1, 1, 1 }, new int[] { 1, 0, 0 } };
        private int[][] piece3 = { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, 1 } };
        private int[][] piece4 = { new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 1, 0 } };
        private int[][] piece5 = { new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } };
        private int[][] piece6 = { new int[] { 0, 1, 1 }, new int[] { 1, 1, 0 } };
        private int[][] piece7 = { new int[] { 0, 1, 0 }, new int[] { 1, 1, 1 } };
        private int[][] piece8 = { new int[] { 1, 1 }, new int[] { 1, 1 } };
        private int[][] piece9 = { new int[] { 1 }, new int[] { 1 }, new int[] { 1 }, new int[] { 1 } };
        private int[][] piece10 = { new int[] { 1, 1, 1, 1 } };



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
                    double y = startY - (numRows - i - 1) * (rectHeight + margin);
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
                case 0:
                    return Colors.White;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TransformedBitmap transformBmp = new TransformedBitmap();
            BitmapImage bmpImage = new BitmapImage();
            bmpImage.BeginInit();
            switch(Int32.Parse(Option.Text))
            {
                case 1:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\one.png", UriKind.RelativeOrAbsolute);
                    break;
                case 2:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\two.png", UriKind.RelativeOrAbsolute);
                    break;
                case 3:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\three.png", UriKind.RelativeOrAbsolute);
                    break;
                case 4:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\four.png", UriKind.RelativeOrAbsolute);
                    break;
                case 5:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\five.png", UriKind.RelativeOrAbsolute);
                    break;
                case 6:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\six.png", UriKind.RelativeOrAbsolute);
                    break;
                case 7:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\seven.png", UriKind.RelativeOrAbsolute);
                    break;
                case 8:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\eight.png", UriKind.RelativeOrAbsolute);
                    break;
                case 9:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\nine.png", UriKind.RelativeOrAbsolute);
                    break;
                case 10:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\ten.png", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    MessageBox.Show("Select Valid Option.", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            bmpImage.EndInit();
            transformBmp.BeginInit();
            transformBmp.Source = bmpImage;
            RotateTransform transform = new RotateTransform(0);

            switch (Int32.Parse(Rotation.Text))
            {
                case 0:
                    transform = new RotateTransform(0);
                    break;
                case 1:
                    transform = new RotateTransform(90);
                    break;
                case 2:
                    transform = new RotateTransform(180);
                    break;
                case 3:
                    transform = new RotateTransform(270);
                    break;
                default:
                    MessageBox.Show("Select Valid Option: 1:90, 2:180, 3:270", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            transformBmp.Transform = transform;
            transformBmp.EndInit();
            Selected_Image.Source = transformBmp;
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
