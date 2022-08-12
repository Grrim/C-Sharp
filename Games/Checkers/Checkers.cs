using System;

namespace checkers{
    class Checkers{
        static void Main(string[] args){
            Game game = new Game();
            Board board1 = new Board();
            char[,] board = board1.board1;
            board1.startingPosition(board);
            board1.printBoard(board); 
            game.makeMove(board);
        }
    }
}