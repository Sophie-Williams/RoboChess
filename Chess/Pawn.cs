﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using ChessTools;
using Image = System.Windows.Controls.Image;

namespace Chess
{
    /**
    * @brief The pawn chess piece.
    **/
    public class Pawn : GamePiece
    {
        public bool enPassant = false; // True if susceptible to an EnPassant, re-set to false after one turn
        /**
         * @brief Constructor for the Pawn object. Calls the constructor for the base GamePiece
         * class before it does it's own construction.
         **/
        public Pawn(Color pieceColor, Point id) : base(pieceColor, id)
        {
            //if (TeamColor == Color.Black)
            //    Img = ChessImages.Black_Pawn;
            //else
            //    Img = ChessImages.White_Pawn;
            Img = GetPieceImage(TeamColor);
        }
        public Pawn(GamePiece piece) : base(piece) { } // Virtual
        public Pawn() { } // Used for Virtual Promotion

        public Image GetPieceImage(Color teamColor)
        {
            Image result;

            if (TeamColor == Color.Black)
                result = new Image()
                {
                    Source = new BitmapImage(new Uri("Resources/BlackPawn.png", UriKind.Relative))
                };
            //Img = ChessImages.Black_Queen;
            else
                result = new Image()
                {
                    Source = new BitmapImage(new Uri("Resources/whitePawn.png", UriKind.Relative))
                };

            return result;
        }

        // Possible Moves, Blind to other Game Pieces
        public override List<BlindMove> BlindMoves()
        {
            List<BlindMove> blindMoves = new List<BlindMove>();

            Point direction = new Point(0,0);

            if (this.TeamColor == Color.White)
                direction.Y = -1;
            else
                direction.Y = +1;


            // Rules for moving Pawn
            // Neutral move

            // Move 2 in the forward direction on first move
            if(this.Location == this.ID)
                blindMoves.Add(new BlindMove(direction, 2, Condition.Neutral));
            // Move 1 in the forward direcion thereafter
            else
                blindMoves.Add(new BlindMove(direction, 1, Condition.Neutral));
            // Attack move

            // Forward Diagonal 1 position, only possible with opponent 
            // Piece in location
            direction.X = 1;
            blindMoves.Add(new BlindMove(direction, 1, Condition.Attack));
            direction.X = -1;
            blindMoves.Add(new BlindMove(direction, 1, Condition.Attack));

            return blindMoves;
        }
    }
}
