﻿//=======================================================================================================================================
// ROBOCHESS - BOT - Skeleton Code
// Created by Jon Klassen
// Last Modified: March 12, 2019
//
// Description: This is where the brain of the operation lives. While I have supplied a few helper functions, the rest is up to you. If
//              you have any questions or theres anything I missed, please let me know on GitHub https://github.com/NaitCTClub/RoboChess
//              This is still a work in the making so be patient.
//
// Crucial Functions you NEED to use
///     MyTurn() -                    its located here and it communicates with the Controller. Only use *ChessMoves* from PossibleMoves()
///     MainBoard.PossibleMoves() -   returns all legal moves [including making sure the king is not vulnerable after the move]
///     
// Crucial Knowledge
///     Board Navigation          -   All Cells in MainBoard are given Point coordinates on property ID wit [0,0] on top left and [7,7] on bottom right
///                                   Example: MainBoard.Cells[0].ID = [0,0]
///                                            MainBoard.Cells[63].ID = [7,7]
///                                                     OR easier via    
///                                            MainBoard.Cells.GetCell(Point) - return Cell associated to that point
///                                            MainBoard.Cells.NextCell(Reference Cell, Point) - returns a cell in certain direction 
///                                                                         Up - new Point( 0, -1 )
///                                                                         down -        ( 0,  1 )
///                                                                         Left  -       (-1,  0 )
///                                                                         Right  -      ( 1,  0 )
///                                                                         Diagonal -    ( 1,  1 )
///                                                                         
///     Struct *ChessMove*        -   Instructions and details for a GamePiece move 
///                                   [Cell From, Cell To, GamePiece moved, GamePiece captured, Condition MoveType]
///     Struct *Condition*        -   Represents the *ChessMove* type
///                                   [Attack][Neutral][EnPassant]
///     Class *Board*             -   Contains the list of Cells, players, whosturn, gamepieces
///     Class *Cells*             -   Squares on the Board - another way to acquire GamePiece locations, Uses *Point* for coordinates via ID      
///     Class *GamePiece*         -   Base class for subclasses of all Piece types (King, Queen, etc)
///                                                                         
///     
//  Helpful Knowledge
///     MainBoard.PlayerOne       -   Used for looking up Opponent moves if "Me == MainBoard.PlayerOne" for example     
///     MainBoard.PlayerTwo       -     
///     MainBoard.MovePiece()     -   Allows you to see the board one step ahead - Careful, it currently changes the MainBoard So....
///     MainBoard.UndoMovePiece() -   This Must Be used each time after using MovePiece()
//=======================================================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ChessTools;
using static ChessTools.Library;

namespace Chess
{
    public class Bot_OberynMartell : BotController
    {
        private Random _rando = new Random();

        //              Add your global variables here

        public Bot_OberynMartell() : base() {}
        //=======================================================================================
        //                  Initialize your variables here         *Only change the inside code
        //=======================================================================================
        public override void RefreshMemory()
        {

        }

        //=======================================================================================
        //                  Your Bot's Move Handler
        //=======================================================================================
        public override ChessMove MyTurn() // Return a legal move for one of your GamePieces
        {
            List<ChessMove> lsOfMoves = GetAllMoves(); // Example

            return GetTheSafest(lsOfMoves);
        }

        //=======================================================================================
        //                  Your Bot's Promotion Handler
        //=======================================================================================
        public override GamePiece Promotion() // Return a promotion Piece for your pawn in the endzone
        {
            return new Queen(); // Queen is da best
        }

        /////////////////////////////////////////////////////////////////////////////////////
        //
        //                  Your Bot Brain Goes Here                *Example Code provided
        //
        /////////////////////////////////////////////////////////////////////////////////////

        public List<ChessMove> GetAllMoves() // Find all legal Moves
        {
            List<ChessMove> lsOfMoves = new List<ChessMove>();

            // Iterate through all your gamepieces
            foreach (GamePiece piece in Me.MyPieces.FindAll(p => p.isAlive)) // Usefull, no point in moving a DEAD GamePiece
            {
                List<ChessMove> moves = VirtualBoard.PossibleMoves(piece);

                lsOfMoves.AddRange(moves);
            }

            return lsOfMoves;
        }

        // Example Function - Returns a single *ChessMove*
        private ChessMove GetTheSafest(List<ChessMove> lsMoves)
        {
            List<ChessMove> betterMoves = lsMoves.FindAll(m => m.MoveType == Condition.Attack);  // Lambda's for searching Lists are a powerful tool.
            List<ChessMove> bestMoves = new List<ChessMove>();

            if( betterMoves.Count > 0)
            {
                foreach (ChessMove move in betterMoves)
                {
                    // Look in the future
                    ChessMove mve = VirtualBoard.MovePiece(move);  // capture possible return of additional information into the move (This MUST be done if pawn)
                    bool isPieceSafe = VirtualBoard.IsSafe(mve.PieceMoved.Location, Me);
                    VirtualBoard.UndoMovePiece(mve);

                    if (isPieceSafe)
                        bestMoves.Add(move);
                }
            }
            if(bestMoves.Count < 0)
            {
                foreach (ChessMove move in lsMoves)
                {
                    // Look in the future
                    ChessMove mve = VirtualBoard.MovePiece(move);  // capture possible return of additional information into the move (This MUST be done if pawn)
                    bool isPieceSafe = VirtualBoard.IsSafe(mve.PieceMoved.Location, Me);
                    VirtualBoard.UndoMovePiece(mve);

                    if (isPieceSafe)
                        bestMoves.Add(mve);
                }
            }

            if (bestMoves.Count > 0)
                return bestMoves[_rando.Next(0, bestMoves.Count)];
            else
                return lsMoves[_rando.Next(0, lsMoves.Count)];
        }
    }
}
