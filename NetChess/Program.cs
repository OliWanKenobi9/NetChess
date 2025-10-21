using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetChess
{
    public enum pieceType { Pawn, Bishop, Knight, Rook, Queen, King, Empty }
    public struct piece
    {
        public pieceType type;
        public bool isWhite;
        public (int, int) position;
    }
    public struct boardPosition
    {
        public (int, int) position;
        public piece current;
    }
    internal class Program
    {
        static boardPosition[] initialiseBoard()
        {
            boardPosition[] board = new boardPosition[64];
            int index = 0;

            for (int j = 0; j < 8; j++)
            {
                for (int h = 0; h < 8; h++)
                {
                    board[index].position = (j + 1, h + 1);
                    board[index].current.position = board[index].position;
                    board[index].current.type = pieceType.Empty;
                    index++;
                }
            }
            return board;
        }
        static piece[] initialisePieces()
        {
            piece[] pieces = new piece[32];

            for (int i = 0; i < 8; i++)
            {
                pieces[i].type = pieceType.Pawn;
                pieces[i].isWhite = true;
                pieces[i].position = (2, i+1);
            }
            for (int i = 8; i < 16; i++)
            {
                pieces[i].type = pieceType.Pawn;
                pieces[i].isWhite = false;
                pieces[i].position = (7, i - 7);
            }


            pieces[16].type = pieceType.Rook;
            pieces[16].position = (1, 1);
            pieces[16].isWhite = true;

            pieces[17].type = pieceType.Rook;
            pieces[17].position = (1, 8);
            pieces[17].isWhite = true;

            pieces[18].type = pieceType.Rook;
            pieces[18].position = (8, 1);
            pieces[18].isWhite = false;

            pieces[19].type = pieceType.Rook;
            pieces[19].position = (8, 8);
            pieces[19].isWhite = false;


            pieces[20].type = pieceType.Knight;
            pieces[20].position = (1, 2);
            pieces[20].isWhite = true;

            pieces[31].type = pieceType.Knight;
            pieces[31].position = (1, 7);
            pieces[31].isWhite = true;

            pieces[21].type = pieceType.Knight;
            pieces[21].position = (8, 2);
            pieces[21].isWhite = false;

            pieces[22].type = pieceType.Knight;
            pieces[22].position = (8, 7);
            pieces[22].isWhite = false;


            pieces[23].type = pieceType.Bishop;
            pieces[23].position = (1, 3);
            pieces[23].isWhite = true;

            pieces[24].type = pieceType.Bishop;
            pieces[24].position = (1, 6);
            pieces[24].isWhite = true;

            pieces[25].type = pieceType.Bishop;
            pieces[25].position = (8, 3);
            pieces[25].isWhite = false;

            pieces[26].type = pieceType.Bishop;
            pieces[26].position = (8, 6);
            pieces[26].isWhite = false;


            pieces[27].type = pieceType.King;
            pieces[27].position = (1, 5);
            pieces[27].isWhite = true;

            pieces[28].type = pieceType.King;
            pieces[28].position = (8, 4);
            pieces[28].isWhite = false;


            pieces[29].type = pieceType.Queen;
            pieces[29].position = (1, 4);
            pieces[29].isWhite = true;

            pieces[30].type = pieceType.Queen;
            pieces[30].position = (8, 5);
            pieces[30].isWhite = false;

            return pieces;
        }
        static void displayBoard(boardPosition[] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                string symbol = "";
                
                switch (board[i].current.type)
                {
                    case pieceType.Pawn:
                        symbol = " P ";
                        break;
                    case pieceType.Bishop:
                        symbol = " B ";
                        break;
                    case pieceType.Knight:
                        symbol = " N ";
                        break;
                    case pieceType.Rook:
                        symbol = " R ";
                        break;
                    case pieceType.Queen:
                        symbol = " Q ";
                        break;
                    case pieceType.King:
                        symbol = " K ";
                        break;
                    case pieceType.Empty:
                        symbol = "   ";
                        break;
                }

                if (i % 8 == 0 && i != 0)
                {
                    Console.WriteLine();
                }

                if ((board[i].position.Item1 + board[i].position.Item2) % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.Green;
                else Console.BackgroundColor = ConsoleColor.DarkYellow;

                if (board[i].current.isWhite)
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(symbol);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Pawn: P | Bishop: B | Knight: N | Rook: R | Queen: Q | King: K");
        }
        static boardPosition[] getPieces(piece[] pieces, boardPosition[] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                for(int j = 0; j < pieces.Length; j++)
                {
                    if(pieces[j].position == board[i].position)
                    {
                        board[i].current = pieces[j];
                    }
                }
            }
            return board;
        }
        static piece[] move(piece[] pieces, boardPosition[] board, bool whiteTurn)
        /* PGN Notation: [x1, y1] [x2, y2]
         * e2 e4
         * a5 a6
         * c3 g3
         */
        {
            Console.Write("Notation: ");
            string input = Console.ReadLine();


            return pieces;
        }

        static void Main(string[] args)
        {
            boardPosition[] board = initialiseBoard();
            piece[] pieces = initialisePieces();
            int turn = 1;
            bool whiteTurn;
            // Declaration

            while(true)
            {
                if (turn % 2 == 0)
                    whiteTurn = false;
                else whiteTurn = true;

                // Ablauf
                Console.Clear();
                board = getPieces(pieces, board);
                displayBoard(board);
                pieces = move(pieces, board, whiteTurn);
            }
        }
    }
}