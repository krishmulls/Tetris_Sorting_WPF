using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tetris_Sorting_WPF
{
    internal class CheckAddPiece
    {
        private int numRows;
        private int numCols;
        private bool exception;

        public CheckAddPiece(ref int numRows, ref int numCols, ref bool exception)
        {
            this.numRows = numRows;
            this.numCols = numCols;
            this.exception = exception;
        }

        public bool CheckPieceAddition(int[][] container, int[][] piece, int row, int col, int pieceRow, int pieceCol)
        {
            /*
             * Source code Logic for checking a  piece of container can be added into container 
             */
            // Get the dimensions of the container and piece arrays
            numRows = container.Length;
            numCols = container[0].Length;
            int pieceRows = piece.Length;
            int pieceCols = piece[0].Length;
            int columnMerge = 0;
            int rowMerge = 0;
            // check if there is 0 column present at the bottom of piece inorder to merge the space
            // occupied space in container
            if (pieceCol != 0 && container[this.numRows - 1][0] != 0)
            {
                columnMerge = -pieceCol;
            }
            // check if there is 0 rows present at the bottom to top of piece inorder to merge the
            // space occupied space in container
            if (pieceRow != pieceRows - 1 && container[this.numRows - 1][0] != 0)
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
                    int pieceRowSyncContainer = ((pieceRows - 1) - r);
                    int pieceColSyncContainer = c;
                    if (containerRow < 0 || containerCol < 0)
                    {
                        MessageBox.Show("The Piece cannot be added because of not found space to add and pattern become complex, check logs for more", "Container Space error", MessageBoxButton.OK, MessageBoxImage.Error);
                        exception = true;
                        return false;
                    }
                    if (containerCol < 0)
                    {
                        containerCol = 0;
                    }
                    if (containerRow >= numRows)
                    {
                        containerRow = numRows - 1;
                    }
                    // Check if the container cell is within bounds or container cell is already occupied
                    if (containerRow >= numRows || containerCol >= numCols || (container[containerRow][containerCol] > 0 && piece[pieceRowSyncContainer][pieceColSyncContainer] > 0))
                    {
                        return false;
                    }
                    // If an empty cell is found make sure the neighbour are not envolping it
                    // So no piece call fill the space
                    if (piece[pieceRowSyncContainer][pieceColSyncContainer] == 0)
                    {
                        if (((r - 1) < pieceRows && (r - 1) >= 0) && ((containerCol + 1) < numCols))
                        {
                            if ((container[containerRow][containerCol + 1] > 0) || piece[pieceRowSyncContainer][pieceColSyncContainer] > 0)
                            {
                                return false;
                            }
                            for (int conCol = containerCol; conCol >= numCols; conCol--)
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

        public bool AddPieceIntoContainer(ref int[][] container, int[][] piece, int row, int col, int pieceRow, int pieceCol)
        {
            /*
             * Source code Logic for adding piece into container 
             */
            // Get the dimensions of the container and piece arrays
            numRows = container.Length;
            numCols = container[0].Length;
            int pieceRows = piece.Length;
            int pieceCols = piece[0].Length;
            int columnMerge = 0;
            int rowMerge = 0;
            // check if there is 0 column present at the bottom of piece inorder to merge the space
            // occupied space in container
            if (pieceCol != 0 && container[this.numRows - 1][0] != 0)
            {
                columnMerge = -pieceCol;
            }
            // check if there is 0 rows present at the bottom to top of piece inorder to merge the
            // space occupied space in container
            if (pieceRow != pieceRows - 1 && container[this.numRows - 1][0] != 0)
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
                    if (containerRow < 0 || containerCol < 0)
                    {
                        MessageBox.Show("The Piece cannot be added because of not found space to add and pattern become complex, Exiting application, check logs for more", "Container Space error", MessageBoxButton.OK, MessageBoxImage.Error);
                        exception = true;
                        return false;
                    }
                    if (containerCol < 0)
                    {
                        containerCol = 0;
                    }
                    if (containerRow >= numRows)
                    {
                        containerRow = numRows - 1;
                    }
                    int pieceRowSyncContainer = ((pieceRows - 1) - r);
                    int pieceColSyncContainer = c;
                    // Check if the container cell is within bounds or container cell is already occupied
                    if (containerRow > numRows || containerCol < numCols)
                    {
                        if (container[containerRow][containerCol] == 0 && piece[pieceRowSyncContainer][pieceColSyncContainer] > 0)
                        {
                            container[containerRow][containerCol] = piece[((pieceRows - 1) - r)][c];
                        }

                    }

                }
            }
            return true;
        }

    }
}
