// See https://aka.ms/new-console-template for more information

class Connect4{
    static void Main(string[] args){
        char[,] board = new char[6,7];
        char player1 = 'O';
        char player2 = 'X';
        Console.WriteLine("Welcome in Connect4 game! Have fun!");
        printBoard(board);
        makeMove(board, player1, player2);
    }

    static void isRow(char[,] board){   
        Console.WriteLine();
        for(int i=0; i < board.GetLength(0); i++){
            for(int j=2; j < board.GetLength(1)-2; j++){
                if(board[i,j] == 'O' && board[i,j-1] == 'O' && board[i,j-2] == 'O' && board[i,j+1] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'O' && board[i,j-1] == 'O' && board[i,j+2] == 'O' && board[i,j+1] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                if(board[i,j] == 'X' && board[i,j-1] == 'X' && board[i,j-2] == 'X' && board[i,j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'X' && board[i,j-1] == 'X' && board[i,j+2] == 'X' && board[i,j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
            }
        }
    }
    
    static void isColumn(char[,] board){
        for(int i=2; i < board.GetLength(0)-2; i++){
            for(int j=0; j < board.GetLength(1); j++){
                if(board[i,j] == 'O' && board[i-1,j] == 'O' && board[i-2,j] == 'O' && board[i+1,j] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'O' && board[i-1,j] == 'O' && board[i+2,j] == 'O' && board[i+1,j] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                if(board[i,j] == 'X' && board[i-1,j] == 'X' && board[i-2,j] == 'X' && board[i+1,j] == 'X'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'X' && board[i-1,j] == 'X' && board[i+2,j] == 'X' && board[i+1,j] == 'X'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
            }
        }
    }

    static void isLeftDiagonal(char[,] board){
        for(int i=2; i < board.GetLength(0)-2; i++){
            for(int j=1; j < board.GetLength(1)-1; j++){
                if(board[i,j] == 'O' && board[i-1,j-1] == 'O' && board[i+2,j+2] == 'O' && board[i+1,j+1] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'X' && board[i-1,j-1] == 'X' && board[i+2,j+2] == 'X' && board[i+1,j+1] == 'X'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
            }
        }
    }

    static void isRightDiagonal(char[,] board){
        for(int i=2; i < board.GetLength(0)-2; i++){
            for(int j=1; j < board.GetLength(1)-1; j++){
                if(board[i,j] == 'O' && board[i-1,j+1] == 'O' && board[i+1,j-1] == 'O' && board[i+2,j-2] == 'O'){
                    Console.WriteLine("Player O won");
                    Environment.Exit(1);
                }
                else if(board[i,j] == 'X' && board[i-1,j+1] == 'X' && board[i+1,j-1] == 'X' && board[i+2,j-2] == 'O'){
                    Console.WriteLine("Player X won");
                    Environment.Exit(1);
                }
            }
        }
    }

    static void makeMove(char[,] board, char player1, char player2){
        int i = 0;

        while (i < 42){
            Console.WriteLine("\n");
            Console.Write("Choose column from 0 to 6: ");
            int col = Convert.ToInt32(Console.ReadLine());
            while (col > 6 || col < 0){
                Console.Write("Wrong field. Choose another: ");
                col = Convert.ToInt32(Console.ReadLine());
            }
            int counter = 1; 

            if (i%2==1){
                while (board[board.GetLength(0)-counter, col] == 'O' || (board[board.GetLength(0)-counter, col] == 'X')){
                    counter++;
                    while (counter > 6){
                        if (counter > 6){
                            printBoard(board);
                            Console.WriteLine("\n\nThis field is already taken!");
                        }
                        Console.Write("Choose another column: ");
                        col = Convert.ToInt32(Console.ReadLine());
                        counter = 1; 
                    }
                }
                board[board.GetLength(0)-counter, col] = 'X';
                i++;
            }
            else if (i%2==0){
                while (board[board.GetLength(0)-counter, col] == 'O' || (board[board.GetLength(0)-counter, col] == 'X')){
                    counter++;
                    while (counter > 6){
                        if (counter > 6){
                            printBoard(board);
                            Console.WriteLine("\n\nThis field is already taken!");
                        }
                        Console.Write("Choose another column: ");
                        col = Convert.ToInt32(Console.ReadLine());
                        counter = 1; 
                    }
                }
                board[board.GetLength(0)-counter, col] = 'O';
                i++;
            }
            printBoard(board);
            isRow(board);
            isColumn(board);
            isLeftDiagonal(board);
            isRightDiagonal(board);
        }
    }

    static void printBoard(char[,] board){
        Console.WriteLine();
        Console.Write("     ");
        for(int i=0; i < board.GetLength(1); i++){
            Console.Write(i + ":  ");
        }

        Console.WriteLine();
        for(int i=0; i < board.GetLength(0); i++){
            Console.WriteLine();
            Console.Write(i + ": " + "|");
            for(int j=0; j < board.GetLength(1); j++){
                Console.Write(" " + board[i, j] + " |");
            }
        }
    }
}