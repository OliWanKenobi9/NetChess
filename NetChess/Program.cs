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
                for (int j = 0; j < 8; i++)
                {
                    for (int h = 0; h < 8; i++)
                    {
                        board[i].position = (j, h);
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
                pieces[i].position = (1, i);
            }
            for (int i = 8; i < 16; i++)
            {
                pieces[i].type = pieceType.Pawn;
                pieces[i].isWhite = false;
                pieces[i].position = (1, i);
            }

            return pieces;
        }
        static void Main(string[] args)
        {
            boardPosition[] board = initialiseBoard();
            piece[] pieces = initialisePieces();
            // Declaration



        }
    }
}