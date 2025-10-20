using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChess
{
    public enum pieceType { Pawn, Bishop, Knight, Rook, Queen, King }
    public struct piece
    {
        public pieceType type;
        public bool isWhite;
        (int, int) position;
    }
    public struct boardPosition
    {
        public (int, int) position;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            boardPosition[] board = new boardPosition[64];
            piece[] pieces = new piece[32];
            // Declaration


            #region Initialise Variables

            for(int i = 0; i < 64; i++)
            {
                for(int j = 0; j < 8; i++)
                {
                    for(int h = 0; h < 8; i++)
                    {
                        board[i].position = (j, h);
                    }
                }
            }

            for(int i = 0; i < 8; i++)
            {

            }

            #endregion
        }
    }
}