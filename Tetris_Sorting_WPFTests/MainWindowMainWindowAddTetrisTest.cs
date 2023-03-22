using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris_Sorting_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tetris_Sorting_WPF.Tests
{
    [TestClass()]
    public class MainWindowMainWindowAddTetrisTest
    {
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
        private MainWindow window;
        private object sender = new object();
        private RoutedEventArgs e = new RoutedEventArgs();

        public MainWindowMainWindowAddTetrisTest()
        {
            window = new MainWindow();
        }

        [TestMethod()]
        public void AddTetrisSingleAdd()

        {
            // Act
            window.Initialize_Container_Click(sender, e);
            bool result1 = window.AddPiece(piece8, 0);
            Assert.IsTrue(result1);
        }
        [TestMethod()]
        public void AddTetrisMultipleGivenOrderAdd()

        {
            // Act
            window.Initialize_Container_Click(sender, e);
            bool result1 = window.AddPiece(piece8, 0);
            bool result2 = window.AddPiece(piece2, 0);
            bool result3 = window.AddPiece(piece10, 0);
            bool result4 = window.AddPiece(piece9, 0);
            bool result5 = window.AddPiece(piece7, 0);
            bool result6 = window.AddPiece(piece4, 1);
            bool result7 = window.AddPiece(piece2, 1);
            bool result8 = window.AddPiece(piece4, 0);
            bool result9 = window.AddPiece(piece5, 0);
            bool result10 = window.AddPiece(piece6, 1);
            bool result11 = window.AddPiece(piece8, 0);
            bool result12 = window.AddPiece(piece3, 0);
            bool result13 = window.AddPiece(piece1, 2);
            bool result14 = window.AddPiece(piece7, 2);
            Assert.IsTrue(result1 && result2 && result3 && result4 && result5 && result6 && result7 && result8 && result9 && result10 && result11 && result12 && result13 && result14);
        }
    }
}