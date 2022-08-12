using System;

namespace checkers{
    public class Board{
        public char[,] board1 { get; set; } = new char[8, 8];
        public void printBoard(char[,] board){
            for (int i = 0; i < board.GetLength(0); i++){
                Console.WriteLine();
                Console.WriteLine("   -------------------------------------------------");
                Console.Write(i + ": |");
                for (int j = 0; j < board.GetLength(1); j++){
                    if(board[i,j] != 'O' && board[i,j] != 'X' && board[i,j] != '@' && board[i,j] != '%'){
                        board[i, j] = ' ';
                    }
                    Console.Write("  " + board[i,j] + "  |");
                }
            }
            Console.WriteLine("  \n   -------------------------------------------------");
        }

        public void startingPosition(char[,] board){
            for (int i = 0; i <= 2; i=i+2){
                for (int j = 1; j <= 7; j=j+2){
                    board[i, j] = 'X';
                }
            }
            for (int i = 5; i <= 7; i=i+2){
                for (int j = 0; j <= 7; j=j+2){
                    board[i, j] = 'O';
                }
            }
            for (int i = 1; i < 2; i++){
                for (int j = 0; j <= 7; j=j+2){
                    board[i, j] = 'X';
                }
            }
            for (int i = 6; i < 7; i++){
                for (int j = 1; j <= 7; j=j+2){
                    board[i, j] = 'O';
                }
            }
        }

        public void superPawn(char[,] board){
            for (int s = 0; s <= 7; s++){
                for (int l = 0; l <= 7; l++){
                    if (board[0, l] == 'O'){
                        board[0, l] = '@';
                    }
                    else if (board[7, l] == 'X'){
                        board[7, l] = '%';
                    }        
                } 
            }
        }

        public void isWinner(char[,] board){
            int counterO = 0;
            int counterX = 0;
            for (int i = 0; i <= 7; i++){
                for (int j = 0; j <= 7; j++){
                    if (board[i, j] == 'O' || board[i, j] == '@'){
                        counterO++;
                    }
                    else if (board[i, j] == 'X' || board[i, j] == '%'){
                        counterX++;
                    }
                }
            }
            if (counterO == 0){
                Console.WriteLine("Player X won");
                System.Environment.Exit(1);
            }
            else if (counterX == 0){
                Console.WriteLine("Player O won");
                System.Environment.Exit(1);
            }
        }
        
        public int[] thereIsNoPawn(char[,] board, int row, int col){
            int[] array = new int[2];
            Console.WriteLine(board[row, col]);
            Console.WriteLine("There is no such field. Choose again.");
            Console.WriteLine("Row: ");
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Col: ");
            col = Convert.ToInt32(Console.ReadLine());
            array[0] = row;
            array[1] = col;
            return array;
        }

        public string isPlaceOnBoard(string? choose, int col, int row){
            if (col == 0){
                while ((choose == "L" || choose == "l") && (choose != "R" || choose != "r")){
                    Console.WriteLine("There is no such field. Choose again.");
                    Console.WriteLine("Left - L, Right - R");
                    choose = Console.ReadLine();
                }
            }
            else if (col == 7){
                while ((choose == "R" || choose == "r") && (choose != "L" || choose != "l")){
                    Console.WriteLine("There is no such field. Choose again.");
                    Console.WriteLine("Left - L, Right - R");
                    choose = Console.ReadLine();
                }
            } 
            else if (row == 0){
                while ((choose == "UL" || choose == "ul" || choose == "UR" || choose == "ur") && (choose != "DL" || choose != "dl" || choose != "DR" || choose != "dr")){
                    Console.WriteLine("There is no such field. Choose again.");
                    Console.WriteLine("Up-Left - UL, Down-Left - DL, Up-Right - UR, Down-Right - DR");
                    choose = Console.ReadLine();
                }
            }
            else if (row == 7){
                while ((choose == "DL" || choose == "dl" || choose == "DR" || choose == "dr") && (choose != "UL" || choose != "ul" || choose != "UL" || choose != "ul")){
                    Console.WriteLine("There is no such field. Choose again.");
                    Console.WriteLine("Up-Left - UL, Down-Left - DL, Up-Right - UR, Down-Right - DR");
                    choose = Console.ReadLine();
                }
            } 
            return choose!;
        }
    }
}