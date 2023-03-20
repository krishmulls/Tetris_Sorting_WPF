﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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

    public partial class MainWindow : Window
    {
        /* 
         *Initialization of class scope variables here
         */
        private int[][] piece1 = { new int[] { 1, 0, 0 }, new int[] { 1, 1, 1 } };
        private int[][] piece2 = { new int[] { 2, 2, 2 }, new int[] { 2, 0, 0 } };
        private int[][] piece3 = { new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, 1 } };
        private int[][] piece4 = { new int[] { 3, 3 }, new int[] { 3, 0 }, new int[] { 3, 0 } };
        private int[][] piece5 = { new int[] { 2, 2, 0 }, new int[] { 0, 2, 2 } };
        private int[][] piece6 = { new int[] { 0, 4, 4 }, new int[] { 4, 4, 0 } };
        private int[][] piece7 = { new int[] { 0, 1, 0 }, new int[] { 1, 1, 1 } };
        private int[][] piece8 = { new int[] { 4, 4 }, new int[] { 4, 4 } };
        private int[][] piece9 = { new int[] { 3 }, new int[] { 3 }, new int[] { 3 }, new int[] { 3 } };
        private int[][] piece10 = { new int[] { 1, 1, 1, 1 } };
        public int[][] container;
        int numRows = 0;
        int numCols = 0;


        public MainWindow()
        {
            /*
             * The Program UI and Modules Initialization
             */
            InitializeComponent();

        }

        private void GenerateRectangles(double startX, double startY)
        {
            /*
             * The Container Cells UI generation in the canvas
             */
            numRows = container.Length;
            numCols = container[0].Length;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {   /*
             * Initiated when a add button is performed calls the add tetris to container
             */
            // Create a new transformed bitmap and bitmap image
            TransformedBitmap transformBmp = new TransformedBitmap();
            BitmapImage bmpImage = new BitmapImage();

            // Begin initialization of the bitmap image
            bmpImage.BeginInit();

            // Initialize piece array and rotation variable
            int[][] piece = piece8;
            int rotation;

            // Set the image URI based on the selected option
            switch (Int32.Parse(Option.Text))
            {
                case 1:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\one.png", UriKind.RelativeOrAbsolute);
                    piece = piece1; 
                    break;
                case 2:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\two.png", UriKind.RelativeOrAbsolute);
                    piece = piece2;
                    break;
                case 3:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\three.png", UriKind.RelativeOrAbsolute);
                    piece = piece3;
                    break;
                case 4:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\four.png", UriKind.RelativeOrAbsolute);
                    piece = piece4;
                    break;
                case 5:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\five.png", UriKind.RelativeOrAbsolute);
                    piece = piece5;
                    break;
                case 6:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\six.png", UriKind.RelativeOrAbsolute);
                    piece = piece6;
                    break;
                case 7:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\seven.png", UriKind.RelativeOrAbsolute);
                    piece = piece7;
                    break;
                case 8:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\eight.png", UriKind.RelativeOrAbsolute);
                    piece = piece8;
                    break;
                case 9:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\nine.png", UriKind.RelativeOrAbsolute);
                    piece = piece9;
                    break;
                case 10:
                    bmpImage.UriSource = new Uri(@"D:\Workspace\Tetris_Sorting_WPF\images\ten.png", UriKind.RelativeOrAbsolute);
                    piece = piece10;
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
            rotation = Int32.Parse(Rotation.Text);

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
            SelectedImage.Source = transformBmp;
            bool checkAdd = AddTetris(piece, rotation);
            if (checkAdd)
            {
                GenerateRectangles(15, 385);
            }
            else
            {
                MessageBox.Show("Container is Full or Input piece is to complex to handle", "Add into Container Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool AddTetris(int[][] piece, int rotation)
        {   /*
             *The AddTetris method is responsible for adding a tetris piece to the container.
             */

            // Get the bottom-left unoccupied cell in the container
            int[] bottomLeftCellContainer = GetBottomLeftUnoccupiedCell(container);
            if (bottomLeftCellContainer is null)
            {
                if (MessageBoxResult.OK == MessageBox.Show("Container is Full or Reserved", "Add into Container Error", MessageBoxButton.OK, MessageBoxImage.Error))
                {
                    if(MessageBoxResult.OK == MessageBox.Show("Do you want to clear container", "Clear Container", MessageBoxButton.OKCancel, MessageBoxImage.Error))
                    {
                        Clear_Click(new object(), new RoutedEventArgs());
                        bottomLeftCellContainer[1] = 0;
                        bottomLeftCellContainer[0] = 0;
                    }
                    else
                    {
                        MessageBox.Show("Application will Close", "Application Close", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            int containerRow = bottomLeftCellContainer[0];
            int containerColumn = bottomLeftCellContainer[1];

            // Rotate the tetris piece by the specified number of times
            piece = RotatePiece(piece, rotation);
            bool checkadd = false;
            while (containerRow >= 0)
            {
                while (containerColumn < numCols)
                {
                    // Get the bottom-left occupied cell in the piece
                    int[] bottomLeftCellPiece = GetBottomLeftOccupiedCell(piece);
                    // Check if the piece can be added to the container at the specified position
                    bool check = checkAddPieceToContainer(container, piece, containerRow, containerColumn, bottomLeftCellPiece[0], bottomLeftCellPiece[1]);
                    if (check)
                    {
                        // Add piece to the container
                        checkadd = AddPieceToContainer(container, piece, containerRow, containerColumn, bottomLeftCellPiece[0], bottomLeftCellPiece[1]);
                        break;
                    }
                    if (checkadd)
                    {
                        break;
                    }
                    containerColumn++;
                }
                if (checkadd)
                {
                    break;
                }
                containerColumn = 0;
                containerRow--;
            }
            return checkadd;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {   /*
             * Initiated when a clear button is performed to clear container
             */
            int row = Int32.Parse(rows.Text);
            int col = Int32.Parse(Columns.Text);
            container = new int[row][];
            for (int j = 0; j < row; j++)
            {
                container[j] = new int[col];
            }
            //To display the new container
            GenerateRectangles(15, 385);
        }

        private void Initialize_Container_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Initiated when a Initiate Cotainer button is  clicked to Initiate container with null values
             */
            int row = Int32.Parse(rows.Text);
            int col = Int32.Parse(Columns.Text);
            container = new int[row][];
            for (int j = 0; j < row; j++)
            {
                container[j] = new int[col];
            }
            GenerateRectangles(15, 385);
        }

        static int[][] RotatePiece(int[][] piece, int rotation)
        {
            /*
             * Rotate the piece by 90 degrees for each multiple of 1 for the value in rotation
            */            
            while (rotation % 4 > 0)
            {
                piece = RotatePieceOnce(piece);
                rotation--;
            }

            return piece;
        }

        static int[][] RotatePieceOnce(int[][] piece)
        {
            /*
            * Rotate the piece once by 90 degrees 
            */
            int height = piece.Length;
            int width = piece[0].Length;
            int[][] rotatedPiece = new int[width][];

            for (int i = 0; i < width; i++)
            {
                rotatedPiece[i] = new int[height];
                for (int j = 0; j < height; j++)
                {
                    rotatedPiece[i][j] = piece[height - j - 1][i];
                }
            }

            return rotatedPiece;
        }

        private int[] GetBottomLeftUnoccupiedCell(int[][] container)
        {
            /*
             * This method finds the bottom left unoccupied cell in a 2D container array
            */
            // If container is null, prompt the user to initialize it with default values
            if (container == null)
            {
                if (MessageBoxResult.OK == MessageBox.Show("Please initialize container first, Click OK to initialize now with default row, column and continue process", "Container Initialization", MessageBoxButton.OK, MessageBoxImage.Error))
                {
                    Initialize_Container_Click(new object(), new RoutedEventArgs());
                    container = this.container;
                }
            }
            int numRows = container.Length;
            int numCols = container[0].Length;
            // Loop through the container from the bottom left to find the first unoccupied cell
            for (int row = numRows - 1; row >= 0; row--)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // If an unoccupied cell is found, return its row and column as an integer array
                    if (container[row][col] == 0)
                    {
                        return new int[] { row, col };
                    }
                }
            }

            // Return null if no unoccupied cell is found
            return null;
        }

        private static int[] GetBottomLeftOccupiedCell(int[][] piece)
        {
            /*
             * This method finds the bottom left Occupied cell in a 2D piece array
            */
            int numRows = piece.Length;
            int numCols = piece[0].Length;

            for (int row = numRows - 1; row >= 0; row--)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (piece[row][col]> 0)
                    {
                        return new int[] { row, col };
                    }
                }
            }
            // Return null if no Occupied cell is found
            return null;
        }

        private bool AddPieceToContainer(int[][] container, int[][] piece, int row, int col, int pieceRow, int pieceCol)
        {   /*
             * Source code Logic for adding piece into container 
             */
            // Get the dimensions of the container and piece arrays
            int containerRows = container.Length;
            int containerCols = container[0].Length;
            int pieceRows = piece.Length;
            int pieceCols = piece[0].Length;
            int columnMerge = 0;
            int rowMerge = 0;
            // check if there is 0 column present at the bottom of piece inorder to merge the space
            // occupied space in container
            if (pieceCol != 0 && container[numRows - 1][0] != 0)
            {
                columnMerge = -pieceCol;
            }
            // check if there is 0 rows present at the bottom to top of piece inorder to merge the
            // space occupied space in container
            if (pieceRow != pieceRows - 1 && container[numRows - 1][0] != 0)
            {
                rowMerge = pieceRow;
            }
            // Check if the piece fits within the container at the specified position
            for (int r = 0; r < pieceRows; r++)
            {
                for (int c = 0; c < pieceCols; c++)
                {
                    int containerRow = row - r + rowMerge;
                    int containerCol = col + c + columnMerge;
                    if (containerCol < 0)
                    {
                        containerCol = 0;
                    }
                    if (containerRow >= containerRows)
                    {
                        containerRow = containerRows - 1;
                    }
                    // Check if the container cell is within bounds or container cell is already occupied
                    if (containerRow > containerRows || containerCol < containerCols)
                    {
                        if (container[containerRow][containerCol] == 0 && piece[((pieceRows - 1) - r)][c]> 0)
                        {
                            container[containerRow][containerCol] = piece[((pieceRows - 1) - r)][c];
                        }

                    }

                }
            }
            return true;
        }


        private bool checkAddPieceToContainer(int[][] container, int[][] piece, int row, int col, int pieceRow, int pieceCol)
        {
            /*
             * Source code Logic for checking a  piece of container can be added into container 
             */
            // Get the dimensions of the container and piece arrays
            int containerRows = container.Length;
            int containerCols = container[0].Length;
            int pieceRows = piece.Length;
            int pieceCols = piece[0].Length;
            int columnMerge = 0;
            int rowMerge = 0;
            // check if there is 0 column present at the bottom of piece inorder to merge the space
            // occupied space in container
            if (pieceCol != 0 && container[numRows-1][0] != 0)
            {
                columnMerge = -pieceCol;
            }
            // check if there is 0 rows present at the bottom to top of piece inorder to merge the
            // space occupied space in container
            if (pieceRow != pieceRows - 1 && container[numRows - 1][0] != 0)
            {
                rowMerge = pieceRow;
            }
            // Check if the piece fits within the container at the specified position
            for (int r = 0; r < pieceRows; r++)
            {
                for (int c = 0; c < pieceCols; c++)
                {
                    int containerRow = row - r + rowMerge;
                    int containerCol = col + c + columnMerge;
                    if (containerCol < 0)
                    {
                        containerCol = 0;
                    }
                    if (containerRow >= containerRows)
                    {
                        containerRow = containerRows - 1;
                        if (containerRow < 0)
                        {
                            MessageBox.Show("The Piece cannot be added because of not found space to add and pattern become complex, Exiting application, check logs for more", "Container Space error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    // Check if the container cell is within bounds or container cell is already occupied
                    if (containerRow >= containerRows || containerCol >= containerCols || (container[containerRow][containerCol]> 0 && piece[((pieceRows - 1) - r)][(c)]> 0))
                    {
                        return false;
                    }
                    // If an empty cell is found make sure the neighbour are not envolping it
                    // So no piece call fill the space
                    if (piece[((pieceRows - 1) - r)][(c)] == 0)
                    {
                        if (((r - 1) < pieceRows && (r - 1) >= 0) && ((containerCol + 1) < containerCols))
                        {
                            if ((container[containerRow][containerCol + 1]> 0) || piece[((pieceRows - 1) - r)][(c)] > 0)
                            {
                                return false;
                            }
                            for (int conCol = containerCol; conCol >= containerCols; conCol--)
                            {
                                if (container[containerRow][conCol] == 0)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}