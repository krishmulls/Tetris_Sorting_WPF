using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        int numRows;
        int numCols;
        bool exception;
        int[][] piece;
        int rotation = 0;
        int selectedPiece = 8;

        ContainerDrawing drawing;
        ShowPiecePreview imagePreview;
        CheckAddPiece checkAdd;
        Rotate rotatePiece;

        public MainWindow()
        {
            /*
             * The Program UI and Modules Initialization
             */

            imagePreview = new ShowPiecePreview();
            InitializeComponent();
            drawing = new ContainerDrawing(ref canvas);
            checkAdd = new CheckAddPiece(ref numRows, ref numCols, ref exception);
            rotatePiece = new Rotate();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {   /*
             * Initiated when a add button is performed calls the add tetris to container
             */
            // Create a new transformed bitmap and bitmap image
            try
            {
                if (Rotation == null || Option == null)
                {
                    rotation = 0;
                    selectedPiece = 8;
                }
                else
                {
                    selectedPiece = int.Parse(Option.Text);
                    rotation = int.Parse(Rotation.Text);
                }
                imagePreview.ShowPreview(selectedPiece, rotation, ref piece, ref SelectedImage);
            }
            catch
            {
                // Object initilization
            }

            bool checkAdd = AddPiece(piece, rotation);
            if (checkAdd)
            {
                drawing.draw(ref container);
            }
            else
            {
                MessageBox.Show("Container is Full or Input piece is to complex to handle to add cancelling addition", "Add into Container Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        public bool AddPiece(int[][] piece, int rotation)
        {   /*
             *The AddTetris method is responsible for adding a tetris piece to the container.
             */

            // Get the bottom-left unoccupied cell in the container
            int[] bottomLeftCellContainer = GetBottomLeftUnoccupiedCell(container);
            if (bottomLeftCellContainer is null)
            {
                if (MessageBoxResult.OK == MessageBox.Show("Container is Full or Reserved", "Add into Container Error", MessageBoxButton.OK, MessageBoxImage.Error))
                {
                    if (MessageBoxResult.OK == MessageBox.Show("Do you want to clear container", "Clear Container", MessageBoxButton.OKCancel, MessageBoxImage.Error))
                    {
                        Clear_Click(new object(), new RoutedEventArgs());
                        bottomLeftCellContainer = new int[] { 0, 0 };
                        drawing.draw(ref container);
                    }
                    else
                    {
                        MessageBox.Show("Cancelling Addition", "Addition Cancelled", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            int containerRow = bottomLeftCellContainer[0];
            int containerColumn = bottomLeftCellContainer[1];

            // Rotate the tetris piece by the specified number of times
            piece = rotatePiece.RotatePiece(ref piece, rotation);
            bool checkadd = false;
            while (containerRow >= 0)
            {
                while (containerColumn < numCols)
                {
                    // Get the bottom-left occupied cell in the piece
                    int[] bottomLeftCellPiece = GetBottomLeftOccupiedCell(piece);
                    // Check if the piece can be added to the container at the specified position
                    bool check = checkAdd.CheckPieceAddition(container, piece, containerRow, containerColumn, bottomLeftCellPiece[0], bottomLeftCellPiece[1]);
                    if (exception == true)
                    {
                        return false;
                    }
                    if (check)
                    {
                        // Add piece to the container
                        checkadd = checkAdd.AddPieceIntoContainer(ref container, piece, containerRow, containerColumn, bottomLeftCellPiece[0], bottomLeftCellPiece[1]);
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
            drawing.clearContainer(ref container, row, col);
        }

        public void Initialize_Container_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Initiated when a Initiate Cotainer button is  clicked to Initiate container with null values
             */
            int row = Int32.Parse(rows.Text);
            int col = Int32.Parse(Columns.Text);
            drawing.clearContainer(ref container, row, col);
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
            numRows = container.Length;
            numCols = container[0].Length;
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
            int rows = piece.Length;
            int columns = piece[0].Length;

            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (piece[row][col] > 0)
                    {
                        return new int[] { row, col };
                    }
                }
            }
            // Return null if no Occupied cell is found
            return null;
        }



        private void Option_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Rotation == null || Option == null)
                {
                    rotation = 0;
                    selectedPiece = 8;
                }
                else
                {
                    selectedPiece = int.Parse(Option.Text);
                    rotation = int.Parse(Rotation.Text);
                }
                imagePreview.ShowPreview(selectedPiece, rotation, ref piece, ref SelectedImage);
            }
            catch
            {
                // Object initilization
            }
        }

        private void Rotation_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Rotation == null || Option == null)
                {
                    rotation = 0;
                    selectedPiece = 8;
                }
                else
                {
                    selectedPiece = int.Parse(Option.Text);
                    rotation = int.Parse(Rotation.Text);
                }
                imagePreview.ShowPreview(selectedPiece, rotation, ref piece, ref SelectedImage);
            }
            catch
            {
                // Object initilization
            }
        }
    }
}
