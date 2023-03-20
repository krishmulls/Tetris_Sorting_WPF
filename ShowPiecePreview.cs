using System;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Tetris_Sorting_WPF
{
    internal class ShowPiecePreview
    {
        private static readonly int[][] PIECE1 = { new int[] { 1, 0, 0 }, new int[] { 1, 1, 1 } };
        private static readonly int[][] PIECE2 = { new int[] { 2, 2, 2 }, new int[] { 2, 0, 0 } };
        private static readonly int[][] PIECE3 = { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, 1 } };
        private static readonly int[][] PIECE4 = { new int[] { 3, 3 }, new int[] { 3, 0 }, new int[] { 3, 0 } };
        private static readonly int[][] PIECE5 = { new int[] { 2, 2, 0 }, new int[] { 0, 2, 2 } };
        private static readonly int[][] PIECE6 = { new int[] { 0, 4, 4 }, new int[] { 4, 4, 0 } };
        private static readonly int[][] PIECE7 = { new int[] { 0, 1, 0 }, new int[] { 1, 1, 1 } };
        private static readonly int[][] PIECE8 = { new int[] { 4, 4 }, new int[] { 4, 4 } };
        private static readonly int[][] PIECE9 = { new int[] { 3 }, new int[] { 3 }, new int[] { 3 }, new int[] { 3 } };
        private static readonly int[][] PIECE10 = { new int[] { 1, 1, 1, 1 } };

        public void ShowPreview(int option, int rotation, ref int[][] piece, ref Image SelectedImage)
        {
            try
            {
                TransformedBitmap transformBmp = new TransformedBitmap();
                BitmapImage bmpImage = new BitmapImage();

                // Begin initialization of the bitmap image
                bmpImage.BeginInit();

                // Initialize selecte piece

                // Set the image URI based on the selected option
                switch (option)
                {
                    case 1:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\one.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE1;
                        break;
                    case 2:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\two.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE2;
                        break;
                    case 3:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\three.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE3;
                        break;
                    case 4:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\four.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE4;
                        break;
                    case 5:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\five.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE5;
                        break;
                    case 6:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\six.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE6;
                        break;
                    case 7:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\seven.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE7;
                        break;
                    case 8:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\eight.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE8;
                        break;
                    case 9:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\nine.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE9;
                        break;
                    case 10:
                        bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\ten.png", UriKind.RelativeOrAbsolute);
                        piece = PIECE10;
                        break;
                    default:
                        // Show error message if the selected option is invalid
                        MessageBox.Show("Select Valid Option.", "Selection error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
                // End initialization of the bitmap image
                bmpImage.EndInit();

                // Begin initialization of the transformed bitmap
                transformBmp.BeginInit();
                transformBmp.Source = bmpImage;

                // Set the source and transformation of the transformed bitmap based on the selected rotation
                RotateTransform transform = new RotateTransform(0);

                // Set the Rotation based on the selected option
                switch (rotation)
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
                // End initialization of the transformed bitmap

                transformBmp.EndInit();
                if (SelectedImage != null)
                {
                    SelectedImage.Source = transformBmp;
                }
            }
            catch
            {
                //Project startup Intialization error can be defined here
            }
        }
    }
}
