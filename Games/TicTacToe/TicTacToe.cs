// See https://aka.ms/new-console-template for more information

class TicTacToe {

    static void Main(string[] args){
        Console.WriteLine();
        Console.WriteLine("Choose board size: ");
        int n = Convert.ToInt32(Console.ReadLine());
        while (n < 3){
            Console.WriteLine("Board size must be grater than 2");
            Console.WriteLine("Choose board size: ");
            n = Convert.ToInt32(Console.ReadLine());
        }
        char[,] board = new char[n, n];
        char player1 = 'O';
        char player2 = 'X';

        playerMove(board, player1, player2);
    }

    static void printBoard(char[,] board){
        Console.WriteLine();
        Console.Write("    ");
        for (int i = 0; i < board.GetLength(0); i++){
            Console.Write("  " + i + ":");
        }

        Console.WriteLine();
        for (int i = 0; i < board.GetLength(0); i++){
            Console.WriteLine();
            Console.Write(i + ":  |");
            for (int j = 0; j < board.GetLength(1); j++){
                Console.Write(" " + board[i,j] + " |");
            }
        }
        Console.WriteLine();
    }

    static void playerMove(char[,] board, char player1, char player2){   
        int turn = 0;
        printBoard(board);
        
        while (turn < 9){
            Console.WriteLine();
            Console.Write("Choose row: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Choose column: ");
            int col = Convert.ToInt32(Console.ReadLine());

            if (board[row, col] == 'X' || board[row, col] == 'O'){
                Console.WriteLine("The field is already taken. Choose another.");
            }
            else{
                if (turn%2==0){
                    board[row, col] = 'X';
                    printBoard(board);
                    turn++;
                }
                else{
                    board[row, col] = 'O';
                    printBoard(board);
                    turn++;
                }
            }
            isRow(board);
            isColumn(board);
            isLeftDiagonal(board);
            isRightDiagonal(board);
        }
    }

    static void isRow(char[,] board){
        for (int i = 0; i < board.GetLength(0); i++){
            for (int j = 1; j < board.GetLength(1)-1; j++){
                if (board[i, j] == 'X' && board[i, j-1] == 'X' && board[i, j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    System.Environment.Exit(1);
                }
                else if (board[i, j] == 'O' && board[i, j-1] == 'O' && board[i, j+1] == 'O'){
                    Console.WriteLine("Player O won");
                    System.Environment.Exit(1);
                }
            }
        }
    }

    static void isColumn(char[,] board){
        for (int i = 1; i < board.GetLength(0)-1; i++){
            for (int j = 0; j < board.GetLength(1); j++){
                if (board[i, j] == 'X' && board[i-1, j] == 'X' && board[i+1, j] == 'X'){
                    Console.WriteLine("Player X won");
                    System.Environment.Exit(1);
                }
                else if (board[i, j] == 'O' && board[i-1, j] == 'O' && board[i+1, j] == 'O'){
                    Console.WriteLine("Player O won");
                    System.Environment.Exit(1);
                }
            }
        }
    }

    static void isLeftDiagonal(char[,] board){
        for (int i = 1; i < board.GetLength(0)-1; i++){
            for (int j = 1; j < board.GetLength(1)-1; j++){
                if (board[i, j] == 'X' && board[i-1, j-1] == 'X' && board[i+1, j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    System.Environment.Exit(1);
                }
                else if (board[i, j] == 'O' && board[i-1, j-1] == 'O' && board[i-1, j-1] == 'O'){
                    Console.WriteLine("Player O won");
                    System.Environment.Exit(1);
                }
            }
        }
    }

    static void isRightDiagonal(char[,] board){
        for (int i = 1; i < board.GetLength(0)-1; i++){
            for (int j = 1; j < board.GetLength(1)-1; j++){
                if (board[i, j] == 'X' && board[i+1, j-1] == 'X' && board[i-1, j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    System.Environment.Exit(1);
                }
                else if (board[i, j] == 'O' && board[i+1, j-1] == 'O' && board[i-1, j+1] == 'O'){
                    Console.WriteLine("Player O won");
                    System.Environment.Exit(1);
                }
            }
        }
    }
    
}