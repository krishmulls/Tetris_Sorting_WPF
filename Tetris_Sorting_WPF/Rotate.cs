using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Sorting_WPF
{
    internal class Rotate
    {

        public int[][] RotatePiece(ref int[][] piece, int rotation)
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

        public int[][] RotatePieceOnce(int[][] piece)
        {
            /*
            * Rotate the piece once by 90 degrees 
            */
            int height = piece.Length;
            int width = piece[0].Length;
            int[][] rotatedPieceOnce = new int[width][];

            for (int i = 0; i < width; i++)
            {
                rotatedPieceOnce[i] = new int[height];
                for (int j = 0; j < height; j++)
                {
                    rotatedPieceOnce[i][j] = piece[height - j - 1][i];
                }
            }

            return rotatedPieceOnce;
        }
    }
}
