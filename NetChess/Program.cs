using System;
using System.Collections.Generic;
using System.Linq;
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

            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int h = 0; h < 8; h++)
                    {
                        board[i].position = (j+1, h+1);
                        board[i].current.position = board[i].position;
                        board[i].current.type = pieceType.Empty;
                    }
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
                pieces[i].position = (2, i+1);
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
            pieces[27].position = (1, 4);
            pieces[27].isWhite = true;

            pieces[28].type = pieceType.King;
            pieces[28].position = (8, 5);
            pieces[28].isWhite = false;


            pieces[29].type = pieceType.Queen;
            pieces[29].position = (1, 5);
            pieces[29].isWhite = true;

            pieces[30].type = pieceType.Queen;
            pieces[30].position = (8, 4);
            pieces[30].isWhite = false;

            return pieces;
        }
        static void displayBoard(boardPosition[] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                string symbol = "";
                if (board[i].position.Item1 == 9 || board[i].position.Item1 == 17 || board[i].position.Item1 == 25 || board[i].position.Item1 == 33 || board[i].position.Item1 == 41 || board[i].position.Item1 == 49 || board[i].position.Item1 == 57)
                {
                    Console.WriteLine();
                }
                switch (board[i].current.type)
                {
                    case pieceType.Pawn:
                        symbol = "P";
                        break;
                    case pieceType.Bishop:
                        symbol = "B";
                        break;
                    case pieceType.Knight:
                        symbol = "H";
                        break;
                    case pieceType.Rook:
                        symbol = "R";
                        break;
                    case pieceType.Queen:
                        symbol = "Q";
                        break;
                    case pieceType.King:
                        symbol = "K";
                        break;
                    case pieceType.Empty:
                        symbol = " ";
                        break;
                }

                if (board[i].position.Item1 + board[i].position.Item2 % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.Green;
                else Console.BackgroundColor = ConsoleColor.DarkYellow;

                if (board[i].current.isWhite)
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(symbol);
                Console.ForegroundColor = ConsoleColor.Black;
            }
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
        static void Main(string[] args)
        {
            boardPosition[] board = initialiseBoard();
            piece[] pieces = initialisePieces();
            // Declaration

            board = getPieces(pieces, board);
            displayBoard(board);

            Console.ReadKey();
        }
    }
}