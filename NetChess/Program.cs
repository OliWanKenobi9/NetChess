using System;

namespace NetChess
{
    public enum PieceType { Pawn, Bishop, Knight, Rook, Queen, King, Empty }
    public struct Piece
    {
        public PieceType type;
        public bool isWhite;
        public (int, int) position;
    }
    public struct BoardPosition
    {
        public (int, int) position;
        public Piece current;
    }
    internal class Program
    {
        static BoardPosition[] InitialiseBoard()
        {
            BoardPosition[] board = new BoardPosition[64];
            int index = 0;

            for (int j = 0; j < 8; j++)
            {
                for (int h = 0; h < 8; h++)
                {
                    board[index].position = (j + 1, h + 1);
                    board[index].current.position = board[index].position;
                    board[index].current.type = PieceType.Empty;
                    index++;
                }
            }
            return board;
        }
        static Piece[] InitialisePieces()
        {
            Piece[] pieces = new Piece[32];

            for (int i = 0; i < 8; i++)
            {
                pieces[i].type = PieceType.Pawn;
                pieces[i].isWhite = true;
                pieces[i].position = (2, i+1);
            }
            for (int i = 8; i < 16; i++)
            {
                pieces[i].type = PieceType.Pawn;
                pieces[i].isWhite = false;
                pieces[i].position = (7, i - 7);
            }


            pieces[16].type = PieceType.Rook;
            pieces[16].position = (1, 1);
            pieces[16].isWhite = true;

            pieces[17].type = PieceType.Rook;
            pieces[17].position = (1, 8);
            pieces[17].isWhite = true;

            pieces[18].type = PieceType.Rook;
            pieces[18].position = (8, 1);
            pieces[18].isWhite = false;

            pieces[19].type = PieceType.Rook;
            pieces[19].position = (8, 8);
            pieces[19].isWhite = false;


            pieces[20].type = PieceType.Knight;
            pieces[20].position = (1, 2);
            pieces[20].isWhite = true;

            pieces[31].type = PieceType.Knight;
            pieces[31].position = (1, 7);
            pieces[31].isWhite = true;

            pieces[21].type = PieceType.Knight;
            pieces[21].position = (8, 2);
            pieces[21].isWhite = false;

            pieces[22].type = PieceType.Knight;
            pieces[22].position = (8, 7);
            pieces[22].isWhite = false;


            pieces[23].type = PieceType.Bishop;
            pieces[23].position = (1, 3);
            pieces[23].isWhite = true;

            pieces[24].type = PieceType.Bishop;
            pieces[24].position = (1, 6);
            pieces[24].isWhite = true;

            pieces[25].type = PieceType.Bishop;
            pieces[25].position = (8, 3);
            pieces[25].isWhite = false;

            pieces[26].type = PieceType.Bishop;
            pieces[26].position = (8, 6);
            pieces[26].isWhite = false;


            pieces[27].type = PieceType.King;
            pieces[27].position = (1, 5);
            pieces[27].isWhite = true;

            pieces[28].type = PieceType.King;
            pieces[28].position = (8, 4);
            pieces[28].isWhite = false;


            pieces[29].type = PieceType.Queen;
            pieces[29].position = (1, 4);
            pieces[29].isWhite = true;

            pieces[30].type = PieceType.Queen;
            pieces[30].position = (8, 5);
            pieces[30].isWhite = false;

            return pieces;
        }
        static void DisplayBoard(BoardPosition[] board)
        {
            for(int i = 0; i < board.Length; i++)
            {
                string symbol = "";
                
                switch (board[i].current.type)
                {
                    case PieceType.Pawn:
                        symbol = " P ";
                        break;
                    case PieceType.Bishop:
                        symbol = " B ";
                        break;
                    case PieceType.Knight:
                        symbol = " N ";
                        break;
                    case PieceType.Rook:
                        symbol = " R ";
                        break;
                    case PieceType.Queen:
                        symbol = " Q ";
                        break;
                    case PieceType.King:
                        symbol = " K ";
                        break;
                    case PieceType.Empty:
                        symbol = "   ";
                        break;
                }

                if (i % 8 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
                
                
                Console.BackgroundColor = ((board[i].position.Item1 + board[i].position.Item2) % 2 == 0) ? ConsoleColor.Green: ConsoleColor.DarkYellow;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(symbol);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Pawn: P | Bishop: B | Knight: N | Rook: R | Queen: Q | King: K");
        }
        static BoardPosition[] GetPieces(Piece[] pieces, BoardPosition[] board)
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
        static (BoardPosition[] board, Piece[] pieces) MovePiece(BoardPosition[] board, Piece[] pieces)
        {
            string input;
            (string, string) startStr, moveToStr;
            (int, int) start, moveTo;
            Console.Write("Input: ");
            input = Console.ReadLine();
            startStr = (input.Substring(0, 1), input.Substring(1, 1));
            moveToStr = (input.Substring(0, 1), input.Substring(1, 1));

            switch(startStr.Item1.ToLower())
            {
                case "a":
                    start.Item1 = 1;
                    break;
                case "b":
                    start.Item1 = 2;
                    break;
                case "c":
                    start.Item1 = 3;
                    break;
                case "d":
                    start.Item1 = 4;
                    break;
                case "e":
                    start.Item1 = 5;
                    break;
                case "f":
                    start.Item1 = 6;
                    break;
                case "g":
                    start.Item1 = 7;
                    break;
                case "h":
                    start.Item1 = 8;
                    break;
                default:
                    Console.WriteLine("Invalid Input (Start)");
                    break;
            }

            switch (moveToStr.Item1.ToLower())
            {
                case "a":
                    moveTo.Item1 = 1;
                    break;
                case "b":
                    moveTo.Item1 = 2;
                    break;
                case "c":
                    moveTo.Item1 = 3;
                    break;
                case "d":
                    moveTo.Item1 = 4;
                    break;
                case "e":
                    moveTo.Item1 = 5;
                    break;
                case "f":
                    moveTo.Item1 = 6;
                    break;
                case "g":
                    moveTo.Item1 = 7;
                    break;
                case "h":
                    moveTo.Item1 = 8;
                    break;
                default:
                    Console.WriteLine("Invalid Input (Move)");
                    break;
            }

            Console.WriteLine($"{start.Item1}, {moveTo.Item1}");

            return (board, pieces);
        }
        static void Main(string[] args)
        {
            BoardPosition[] board = InitialiseBoard();
            Piece[] pieces = InitialisePieces();
            int turn = 1;
            bool whiteTurn;
            // Declaration

            do
            {
                whiteTurn = turn % 2 != 0 ? true : false;

                Console.Clear();
                board = GetPieces(pieces, board);
                DisplayBoard(board);
                turn++;
            } while (true); // Win condition
        }
    }
}