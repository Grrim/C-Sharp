using System;

namespace checkers{
    public class Move{
        public string[] behindBeating(char[,] board, char pawn, char pawn3, char pawn2, char pawn4, int row, int col, string choose, int i, int j){
            string[] array = new string[4];
            
            if ((board[i, j] == pawn || board[i, j] == pawn3) && (board[i-1, j+1] == pawn2 || board[i-1, j+1] == pawn4) && board[i+1, j-1] == ' '){
                Console.WriteLine("1. You can beat with pawn: " + (i-1) + ", " + (j+1));
                Console.WriteLine("Confirm...");
                Console.ReadLine();
                row = i - 1;
                col = j + 1;
                choose = "P";
                array[3] = "1";
            }  
            else if ((board[i, j] == pawn || board[i, j] == pawn3) && (board[i-1, j-1] == pawn2 || board[i-1, j-1] == pawn4) && board[i+1, j+1] == ' '){
                Console.WriteLine("1. You can beat with pawn: " + (i-1) + ", " + (j-1));
                Console.WriteLine("Confirm...");
                Console.ReadLine();
                row = i - 1;
                col = j - 1;
                choose = "L";
                array[3] = "1";
            } 
            else if ((board[i, j] == pawn || board[i, j] == pawn3) && (board[i+1, j-1] == pawn2 || board[i+1, j-1] == pawn4) && board[i-1, j+1] == ' '){
                Console.WriteLine("1. You can beat with pawn: " + (i+1) + ", " + (j-1));
                Console.WriteLine("Confirm...");
                Console.ReadLine();
                row = i + 1;
                col = j - 1;
                choose = "L";
                array[3] = "1";
            }  
            else if ((board[i, j] == pawn || board[i, j] == pawn3) && (board[i+1, j+1] == pawn2 || board[i+1, j+1] == pawn4) && board[i-1, j-1] == ' '){
                Console.WriteLine("1. You can beat with pawn: " + (i+1) + ", " + (j+1));
                Console.WriteLine("Confirm...");
                Console.ReadLine();
                row = i + 1;
                col = j + 1;
                choose = "P";
                array[3] = "1";
            }  
            array[0] = Convert.ToString(row);
            array[1] = Convert.ToString(col);
            array[2] = choose;
            return array;
        }
        public int[] isBeaten(int isBeaten, int row, int col, int a, int b, int c, bool beat){
            int[] array = new int[3];
            switch (isBeaten){
                case 1:
                    Console.WriteLine("Confirm...");
                    Console.ReadLine();
                    row = row + a;
                    col = col + c;
                    array[2] = 1;
                    break;
                case 2:
                    Console.WriteLine("Confirm...");
                    Console.ReadLine();
                    row = row + a;
                    col = col + b;
                    break;
                case 3:
                    bool goodField = false;
                    Console.WriteLine("Choose the pawn. 1/2");
                    isBeaten = Convert.ToInt32(Console.ReadLine());
                    while (goodField == false){
                        if (isBeaten == 1){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + a;
                            col = col + c;
                            goodField = true;
                        }
                        else if (isBeaten == 2){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + a;
                            col = col + b;
                            goodField = true;
                        }
                        else{
                            Console.WriteLine("Incorrect data. Choose again.");
                        }
                    }
                break;
                case 4:
                    Console.WriteLine("Confirm...");
                    Console.ReadLine();
                    row = row + b;
                    col = col + c;
                    beat = true;
                    array[2] = 1;
                    break;
                case 5:
                    goodField = false;
                    Console.WriteLine("Choose the pawn. 1/2");
                    isBeaten = Convert.ToInt32(Console.ReadLine());
                    while (goodField == false){
                        if (isBeaten == 1){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + a;
                            col = col + c;
                            goodField = true;
                        }
                        else if (isBeaten == 3){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + b;
                            col = col + a;
                            goodField = true;
                        }
                        else{
                            Console.WriteLine("Incorrect data. Choose again.");
                        }
                    }
                break;
                case 6:
                    goodField = false;
                    Console.WriteLine("Choose the pawn. 1/2");
                    isBeaten = Convert.ToInt32(Console.ReadLine());
                    while (goodField == false){
                        if (isBeaten == 1){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + a;
                            col = col + c;
                            goodField = true;
                        }
                        else if (isBeaten == 2){
                            Console.WriteLine("Confirm...");
                            Console.ReadLine();
                            row = row + a;
                            col = col + b;
                            goodField = true;
                        }
                        else{
                            Console.WriteLine("Incorrect data. Choose again.");
                        }
                    }
                break;
            }
            array[0] = row;
            array[1] = col;
            return array;
        }

        public int[] isMultipleAttack(char[,] board, char pawn, char pawn2, int row, int col){
            int isBeaten = 0;
            int doubleCheck = 0;
            int[] array = new int[3];
            Board board1 = new Board();

            if (col != 0 && col != 1){
                if (row != 6 && row != 7){
                    if ((board[row+1, col-1] == pawn ||  board[row+1, col-1] == pawn2) && board[row+2, col-2] == ' '){
                        doubleCheck += 1;
                    }
                }
                if (row != 0 && row != 1){
                    if ((board[row-1, col-1] == pawn || board[row-1, col-1] == pawn2) && board[row-2, col-2] == ' '){
                    doubleCheck += 4;
                    }
                }
            }
            if (col != 6 && col != 7){
                if (row != 6 && row != 7){
                    if ((board[row+1, col+1] == pawn || board[row+1, col+1] == pawn2) && board[row+2, col+2] == ' '){
                        doubleCheck += 7;
                    }
                }
                if (row != 0 && row != 1){
                    if ((board[row-1, col+1] == pawn || board[row-1, col+1] == pawn2) && board[row-2, col+2] == ' '){
                        doubleCheck += 2;
                    }
                }
            }

            switch(doubleCheck){
                case 1:
                    Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                    if (board[row, col] == pawn){
                       board[row, col] = ' ';
                        board[row+2, col-2] = pawn;
                        board[row+1, col-1] = ' '; 
                    }
                    else{
                        board[row, col] = ' ';
                        board[row+2, col-2] = pawn2;
                        board[row+1, col-1] = ' ';
                    }
                    board1.printBoard(board);  
                    row = row + 2;
                    col = col - 2;
                    break;
                case 2:
                    Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                    if (board[row, col] == pawn){
                        board[row, col] = ' ';
                        board[row-2, col+2] = pawn;
                        board[row-1, col+1] = ' ';
                    }
                    else{
                        board[row, col] = ' ';
                        board[row-2, col+2] = pawn2;
                        board[row-1, col+1] = ' ';
                    }
                    board1.printBoard(board);  
                    row = row - 2;
                    col = col + 2;
                    break;
                case 3:
                    bool goodField = false;
                    Console.WriteLine("Choose the pawn. 1/2");
                    isBeaten = Convert.ToInt32(Console.ReadLine());
                    while (goodField == false){
                        if (isBeaten == 1){
                            Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                            if (board[row, col] == pawn){
                                board[row, col] = ' ';
                                board[row+2, col-2] = pawn;
                                board[row+1, col-1] = ' ';
                            }
                            else{
                                board[row, col] = ' ';
                                board[row+2, col-2] = pawn2;
                                board[row+1, col-1] = ' ';
                            }
                            board1.printBoard(board);  
                            row = row + 2;
                            col = col - 2;
                            break;
                        }
                        if (isBeaten == 2){
                            Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                            if (board[row, col] == pawn){
                                board[row, col] = ' ';
                                board[row-2, col+2] = pawn;
                                board[row-1, col+1] = ' ';
                            }
                            else{
                                board[row, col] = ' ';
                                board[row-2, col+2] = pawn2;
                                board[row-1, col+1] = ' ';
                            }
                            board1.printBoard(board);  
                            row = row - 2;
                            col = col + 2;
                            break;
                        }
                        else{
                            Console.WriteLine("Incorrect data. Choose again."); 
                        }
                    }
                    break;
                    case 4:
                        Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col)); 
                        if (board[row, col] == pawn){ 
                            board[row, col] = ' ';
                            board[row-2, col-2] = pawn;
                            board[row-1, col-1] = ' ';
                        }
                        else{
                            board[row, col] = ' ';
                            board[row-2, col-2] = pawn2;
                            board[row-1, col-1] = ' ';
                        }
                        board1.printBoard(board);  
                        row = row - 2;
                        col = col - 2;
                        break;
                    case 5:
                        goodField = false;
                        Console.WriteLine("Choose the pawn. 1/2");
                        isBeaten = Convert.ToInt32(Console.ReadLine());
                        while (goodField == false){
                            if (isBeaten == 1){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row+2, col-2] = pawn;
                                    board[row+1, col-1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row+2, col-2] = pawn2;
                                    board[row+1, col-1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row + 2;
                                col = col - 2;
                                break;
                            }
                            if (isBeaten == 2){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn;
                                    board[row-1, col-1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn2;
                                    board[row-1, col-1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row - 2;
                                col = col - 2;
                                break;
                            }
                            else{
                                Console.WriteLine("Incorrect data. Choose again."); 
                            }
                        }
                        break;
                    case 6:
                        goodField = false;
                        Console.WriteLine("Choose the pawn. 1/2");
                        isBeaten = Convert.ToInt32(Console.ReadLine());
                        while (goodField == false){
                            if (isBeaten == 1){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row-2, col+2] = pawn;
                                    board[row-1, col+1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row-2, col+2] = pawn2;
                                    board[row-1, col+1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row - 2;
                                col = col + 2;
                                break;
                            }
                            if (isBeaten == 2){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn;
                                    board[row-1, col-1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn2;
                                    board[row-1, col-1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row - 2;
                                col = col - 2;
                                break;
                            }
                            else{
                                Console.WriteLine("Incorrect data. Choose again."); 
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("1. You can beat with pawn: " + row + ", " + col);
                        if (board[row, col] == pawn){
                            board[row, col] = ' ';
                            board[row+2, col+2] = pawn;
                            board[row+1, col+1] = ' ';
                        }
                        else{
                            board[row, col] = ' ';
                            board[row+2, col+2] = pawn2;
                            board[row+1, col+1] = ' ';
                        }
                        board1.printBoard(board);  
                        row = row + 2;
                        col = col + 2;
                        break;
                    case 8:
                        goodField = false;
                        Console.WriteLine("Choose the pawn. 1/2");
                        isBeaten = Convert.ToInt32(Console.ReadLine());
                        while (goodField == false){
                            if (isBeaten == 1){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row+2, col-2] = pawn;
                                    board[row+1, col-1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row+2, col-2] = pawn2;
                                    board[row+1, col-1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row + 2;
                                col = col - 2;
                                break;
                                }
                            if (isBeaten == 2){
                                Console.WriteLine("1. You can beat with pawn: " + row + ", " + col);
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn;
                                    board[row+1, col+1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn2;
                                    board[row+1, col+1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row + 2;
                                col = col + 2;
                                break;
                            }
                            else{
                                Console.WriteLine("Incorrect data. Choose again."); 
                            }
                        }
                        break;
                    case 9:
                        goodField = false;
                        Console.WriteLine("Choose the pawn. 1/2");
                        isBeaten = Convert.ToInt32(Console.ReadLine());
                        while (goodField == false){
                            if (isBeaten == 1){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row-2, col+2] = pawn;
                                    board[row-1, col+1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row-2, col+2] = pawn2;
                                    board[row-1, col+1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row - 2;
                                col = col + 2;
                                break;
                            }
                            if (isBeaten == 2){
                                Console.WriteLine("1. You can beat with pawn: " + row + ", " + col);
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn;
                                    board[row+1, col+1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn2;
                                    board[row+1, col+1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row + 2;
                                col = col + 2;
                                break;
                            }
                            else{
                                Console.WriteLine("Incorrect data. Choose again."); 
                            }
                        }
                        break;
                    case 11:
                        goodField = false;
                        Console.WriteLine("Choose the pawn. 1/2");
                        isBeaten = Convert.ToInt32(Console.ReadLine());
                        while (goodField == false){
                            if (isBeaten == 1){
                                Console.WriteLine("1. You can beat with pawn: " + (row) + ", " + (col));
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn;
                                    board[row-1, col-1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row-2, col-2] = pawn2;
                                    board[row-1, col-1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row - 2;
                                col = col - 2;
                                break;
                            }
                            if (isBeaten == 2){
                                Console.WriteLine("1. You can beat with pawn: " + row + ", " + col);
                                if (board[row, col] == pawn){
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn;
                                    board[row+1, col+1] = ' ';
                                }
                                else{
                                    board[row, col] = ' ';
                                    board[row+2, col+2] = pawn2;
                                    board[row+1, col+1] = ' ';
                                }
                                board1.printBoard(board);  
                                row = row + 2;
                                col = col + 2;
                                break;
                            }
                            else{
                                Console.WriteLine("Incorrect data. Choose again."); 
                            }
                        }
                        break;
                    }
                    array[0] = row;
                    array[1] = col;
                    return array;
                }
            }
        }
