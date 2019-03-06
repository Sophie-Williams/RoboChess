﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Chess
{
    public class Cell
    {
        // Jon Klassen
        public enum State { Default, Active, Neutral, Enemy, UnChecked };

        public static readonly SolidColorBrush darkCell = new SolidColorBrush(Colors.Gray) { Opacity = 0.8 };
        public static readonly SolidColorBrush lightCell = new SolidColorBrush(Colors.LightGray) { Opacity = 0.8 };
        public static readonly SolidColorBrush activeCell = new SolidColorBrush(Colors.Yellow) { Opacity = 0.8 };
        public static readonly SolidColorBrush neutralMove = new SolidColorBrush(Colors.Blue) { Opacity = 0.8 };
        public static readonly SolidColorBrush attackMove = new SolidColorBrush(Colors.Red) { Opacity = 0.8 };

        public Point ID { get; protected set; }
        private static int _Height = 44;
        private static int _Width = 44;
        public GamePiece Piece { get; set; }
        public Button UIButton { get; protected set; }
        public State Status { get; set; }


        // Constructor
        public Cell(int x, int y)
        {
            ID = new Point(x, y);
            Piece = GamePiece.StartingPiece(new Point(x, y));
            UIButton = new Button
            {
                Width = _Width,
                Height = _Height,
                Name = $"P{ID.X}{ID.Y}",
                //Content = Piece.Img
        };

            CellStatus(State.Default);
        }


        public void CellStatus(State state)
        {
            // Update state enum
            Status = state;
            // Update Background color
            CellColor();

            // Update Gamepiece Image
            if (!(Piece is null))
                UIButton.Content = Piece.Img;
            else
                UIButton.Content = null;
        }

        public void CellColor()
        {
            // Default
            if (Status == State.Default)
                // Sequence for creating the Board's pattern in the UI
                if (((this.ID.Y + this.ID.X) % 2) == 0 || this.ID.Y + this.ID.X == 0)
                    UIButton.Background = lightCell;
                else
                    UIButton.Background = darkCell;

            // Neutral move cell
            else if (Status == State.Neutral)
                UIButton.Background = neutralMove;
            // Attackable Cell
            else if (Status == State.Enemy)
                UIButton.Background = attackMove;
            // Active Cell
            else
                UIButton.Background = activeCell;
        }

        public override string ToString()
        {
            string result;

            if (Piece is null)
            {
                result = "Empty space";
            }
            else
            {
                // if(cells[x,y].Equals(new King()))
                result = " The piece is " + Piece + " " +
                                            Piece.TeamColor + " " +
                                            Piece.ID;
            }
            return result;
        }
    }
}
