using System;

namespace checkers{
    public class Game{
        public void makeMove(char[,] board){
            int counter = 0;
            int row = 0;
            int col = 0;
            string? choose = " ";
            bool beat = false;
            bool strike = false;
            bool atak = false;
            Board board1 = new Board();
            Move move1 = new Move();
            while (counter < 1000){
                board1.isWinner(board);
                choose = (choose == "R") ? choose = "L" : choose = "R";
                if (counter%2==0){ 
                    if (beat == false){
                        Console.WriteLine("Row: ");
                        row = Convert.ToInt32(Console.ReadLine());
                        while (row < 0 || row > 8){
                            Console.WriteLine("Fault! Enter the row number again:");
                            row = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Col: ");
                        col = Convert.ToInt32(Console.ReadLine());   
                        while (col < 0 || col > 8){
                            Console.WriteLine("Fault! Enter the col number again:");
                            col = Convert.ToInt32(Console.ReadLine());
                        }
                    }                
                    bool k = false;
                    for (int i = 1; i < board.GetLength(0)-1; i++){
                        for (int j = 1; j < board.GetLength(1)-1; j++){
                            if (atak == false){
                                var rev = move1.behindBeating(board, 'O', '@', 'X', '%', row, col, choose, i, j);  
                                row = Convert.ToInt32(rev[0]);
                                col = Convert.ToInt32(rev[1]);
                                choose = rev[2];
                                if (rev[3] == "1"){
                                    beat = true;
                                    k = true;
                                }
                            }
                            while(k == false){
                                if(board[row, col] == 'O' || board[row, col] == '@'){
                                    if (beat == false){
                                        if (board[row, col] == 'O'){
                                            Console.WriteLine("Left - L, Right - R");
                                            choose = Console.ReadLine();   
                                            while (choose != "L" && choose != "l" && choose != "R" && choose != "r"){
                                                Console.WriteLine("Choose the direction");
                                                choose = Console.ReadLine();  
                                            }
                                        }
                                        else if (board[row, col] == '@'){
                                            Console.WriteLine("Up-Left - UL, Down-Left - DL, Up-Right - UR, Down-Right - DR");
                                            choose = Console.ReadLine();
                                            while (choose != "UR" && choose != "ur" && choose != "UL" && choose != "ul" && choose != "dl" && choose != "DL" && choose != "DR" && choose != "dr"){
                                                Console.WriteLine("Choose the direction");
                                                choose = Console.ReadLine();  
                                            }
                                        } 
                                    }
                                    
                                    choose = board1.isPlaceOnBoard(choose, col, row); 

                                    if (choose == "L" || choose == "l" || choose == "UL" || choose == "ul"){
                                        if (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            while (row < 0 || row > 8){
                                                Console.WriteLine("Fault! Enter the row number again:");
                                                row = Convert.ToInt32(Console.ReadLine());
                                            }
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());   
                                            while (col < 0 || col > 8){
                                                Console.WriteLine("Fault! Enter the col number again:");
                                                col = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ') || ((board[row+1,col-1] == 'X' || board[row+1,col-1] == '%') && board[row+2, col-2] == ' ')){
                                            if ((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' '){
                                                board[row-2, col-2] = 'O';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 2 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && board[row-1, col-1] == ' ' && (board[row-3, col-3] == 'X' || board[row-3, col-3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col-3));
                                                    isBeaten++;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && board[row-1, col-3] == ' ' && (board[row-3, col-1] == 'X' || board[row-3, col-1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && (board[row-1, col-3] == 'X' || board[row-1, col-3] == '%') && board[row-3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "L";
                                                }
                                            }
                                            else if ((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' '){
                                                board[row+2, col-2] = 'O';
                                                board[row+1, col-1] = ' ';
                                                board[row, col] = ' ';
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && board[row+1, col-1] == ' ' && (board[row+3, col-3] == 'X' || board[row+3, col-3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col-3));
                                                    isBeaten++;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && board[row+1, col-3] == ' ' && (board[row+3, col-1] == 'X' || board[row+3, col-1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && (board[row+1, col-3] == 'X' || board[row+1, col-3] == '%') && board[row+3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }                                
                                            if (col == 0 || col == 1 || row == 0 || row == 1 || row == 6 || row == 7){
                                                Console.Write("");
                                            }
                                            else if (board[row-2, col-2] == 'O' || board[row-2, col-2] == '@' || board[row+2, col-2] == 'O' || board[row+2, col-2] == '@')
                                            {      
                                                if (board[row-2, col-2] == 'O' || board[row-2, col-2] == '@'){
                                                    row = row - 2;
                                                    col = col - 2; 
                                                }
                                                else if (board[row+2, col-2] == 'O' || board[row+2, col-2] == '@'){
                                                    row = row + 2;
                                                    col = col - 2; 
                                                }  
                                                while (row != 6 && col != 0 && col != 1 && board[row+2, col-2] == ' ' && (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') || (col != 6 && col != 7 && (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' ') || (col != 0 && col != 1 && (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ') || (row != 6 && col != 6 && col != 7 && (board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ')){
                                                    
                                                    var ress = move1.isMultipleAttack(board, 'X', '%', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else{
                                            board[row-1, col-1] = 'O';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            board1.superPawn(board);
                                            board1.printBoard(board);  
                                            int isBeaten = 0;
                                            beat = false;
                                            if (row == 1 || col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row, col] == ' ' && (board[row-2, col-2] == 'X' || board[row-2, col-2] == '%')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row-2) + ", " + (col-2));
                                                isBeaten++;
                                                choose = "L";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 1 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row, col-2] == ' ' && (board[row-2, col] == 'X' || board[row-2, col] == '%')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row-2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && (board[row, col-2] == 'X' || board[row, col-2] == '%') && board[row-2, col] == ' '){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col-2));
                                                isBeaten = isBeaten + 4;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            var res = move1.isBeaten(isBeaten, row, col, -2, 0, -2, beat); 
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "L";
                                            }
                                        }
                                    }
                                    else if (choose == "R" || choose == "r" || choose == "GP" || choose == "gp"){
                                        if (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            if (beat == false){
                                                Console.WriteLine("Row: ");
                                                row = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Col: ");
                                                col = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (row != 0 && row != 1 && col != 6 && col != 7 && ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' ') || row != 6 && row != 7 && col != 6 && row != 7 && ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ')){
                                            if ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' '){
                                                board[row-2, col+2] = 'O';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && board[row-1, col+1] == ' ' && (board[row-3, col+3] == 'X' || board[row-3, col+3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col+3));
                                                    isBeaten++;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && board[row-1, col+3] == ' ' && (board[row-3, col+1] == 'X' || board[row-3, col+1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && (board[row-1, col+3] == 'X' || board[row-1, col+3] == '%') && board[row-3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' '){
                                                board[row+2, col+2] = 'O';
                                                board[row+1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && board[row+1, col+1] == ' ' && (board[row+3, col+3] == 'X' || board[row+3, col+3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col+3));
                                                    isBeaten++;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && board[row+1, col+3] == ' ' && (board[row+3, col+1] == 'X' || board[row+3, col+1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && (board[row+1, col+3] == 'X' || board[row+1, col+3] == '%') && board[row+3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }   
                                            if (col == 6 || col == 7){
                                                Console.WriteLine();
                                            }
                                            else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') || (board[row+2, col+2] == 'O' || board[row+2, col+2] == '@'))
                                            {
                                                if (board[row-2, col+2] == 'O' || board[row-2, col+2] == '@'){
                                                    row = row - 2;
                                                    col = col + 2; 
                                                }
                                                else if (board[row+2, col+2] == 'O' || board[row+2, col+2] == '@'){
                                                    row = row + 2;
                                                    col = col + 2; 
                                                }
                                                while((col != 0 && col != 1 && (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ') || (col != 6 && col != 7 && (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2,col-2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'X', '%', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else if (row != 7 && col != 0 && ((board[row, col] == 'O' || board[row, col] == '@') && (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' ')){
                                            board[row+2, col-2] = 'O';
                                            board[row+1, col-1] = ' ';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            board[row-1, col+1] = 'O';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                            int isBeaten = 0;
                                            if (col == 6 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row, col] == ' ' && (board[row-2, col+2] == 'X' || board[row-2, col+2] == '%')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row-2) + ", " + (col+2));
                                                isBeaten++;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 6 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row, col+2] == ' ' && (board[row-2, col] == 'X' || board[row-2, col] == '%')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row-2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                choose = "L";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 5 || col == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && (board[row, col+2] == 'X' || board[row, col+2] == '%') && board[row-2, col] == ' '){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col+2));
                                                isBeaten = isBeaten + 4;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            var res = move1.isBeaten(isBeaten, row, col, -2, 0, 2, beat);
                                            row = res[0];
                                            col = res[1];    
                                            if (res[2] == 1){
                                                choose = "R";
                                            }               
                                        }
                                    }
                                    else if (choose == "DL" || choose == "dl"){
                                        if (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());
                                        }      
                                        else if (((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' ') || ((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ')){
                                            if((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' '){
                                                if (board[row, col] == '@'){
                                                    board[row+2, col-2] = '@';
                                                    board[row+1, col-1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                else{
                                                    board[row+2, col-2] = 'O';
                                                    board[row+1, col-1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && board[row+1, col-1] == ' ' && (board[row+3, col-3] == 'X' || board[row+3, col-3] == '%'))
                                                {
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col-3));
                                                    isBeaten++;
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && board[row+1, col-3] == ' ' && (board[row+3, col-1] == 'X' || board[row+3, col-1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') && (board[row+1, col-3] == 'X' || board[row+1, col-3] == '%') && board[row+3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' '){
                                                if (board[row, col] == '@'){
                                                    board[row-2, col-2] = '@';
                                                    board[row-1, col-1] = ' ';
                                                    board[row, col] = ' ';
                                                }
                                                else{
                                                    board[row-2, col-2] = 'O';
                                                    board[row-1, col-1] = ' ';
                                                    board[row, col] = ' ';
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && board[row-1, col-1] == ' ' && (board[row-3, col-3] == 'X' || board[row-3, col-3] == '%'))
                                                {
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col-3));
                                                    isBeaten++;
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && board[row-1, col-3] == ' ' && (board[row-3, col-1] == 'X' || board[row-3, col-1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'O' || board[row-2, col-2] == '@') && (board[row-1, col-3] == 'X' || board[row-1, col-3] == '%') && board[row-3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    beat = true;
                                                    atak = true;
                                                }  
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }     
                                            if (col == 0 || col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row+2, col-2] == 'O' || board[row+2, col-2] == '@') || (board[row-2, col-2] == 'O' || board[row-2, col-2] == '@')){
                                                if (board[row+2, col-2] == 'O' || board[row+2, col-2] == '@'){
                                                    row = row + 2;
                                                    col = col - 2; 

                                                }
                                                else if (board[row-2, col-2] == 'O' || board[row-2, col-2] == '@'){
                                                    row = row - 2;
                                                    col = col - 2; 
                                                }
                                                while((col != 0 && col != 1 && (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' ') || (col != 6 && col != 7 && (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2,col+2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'X', '%', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            } 
                                        }
                                        else if (col != 7 && ((board[row, col] == 'O' || board[row, col] == '@') && (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' ')){
                                            if (board[row, col] == '@'){
                                                board[row-2, col+2] = '@';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';
                                            }
                                            else{
                                              board[row-2, col+2] = 'O';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            if (board[row, col] == '@'){
                                                board[row+1,col-1] = '@';
                                                board[row, col] = ' ';
                                            }
                                            else{
                                              board[row+1,col-1] = 'O';
                                                board[row, col] = ' ';  
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                            int isBeaten = 0;
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row, col] == ' ' && (board[row+2, col-2] == 'X' || board[row+2, col-2] == '%')){
                                                Console.WriteLine("1QEWQE. You can beat with pawn: " + (row+2) + ", " + (col-2));
                                                isBeaten++;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            }
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row, col-2] == ' ' && (board[row+2, col] == 'X' || board[row+2, col] == '%')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row+2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                            } 
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@' && (board[row, col-2] == 'X' || board[row, col-2] == '%') && board[row+2, col] == ' ')){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col-2));
                                                isBeaten = isBeaten + 4;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                                Console.WriteLine(choose);
                                            } 
                                            var res = move1.isBeaten(isBeaten, row, col, 2, 0, -2, beat);
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "R";
                                            }
                                        }
                                    }
                                    else if (choose == "DP" || choose == "dp"){
                                        if (board[row+1, col+1] == 'O' || board[row+1, col+1] == '@'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());
                                        }
                                        
                                        else if (((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ') || ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2,col+2] == ' ')){
                                            if ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' '){
                                                if (board[row, col] == '@'){
                                                   board[row+2, col+2] = '@';
                                                    board[row+1, col+1] = ' ';
                                                    board[row, col] = ' ';  
                                                }
                                                else{
                                                    board[row+2, col+2] = 'O';
                                                    board[row+1, col+1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && board[row+1, col+1] == ' ' && (board[row+3, col+3] == 'X' || board[row+3, col+3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col+3));
                                                    isBeaten++;
                                                    atak = true;
                                                    beat = true;
                                                    choose = "L";
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && board[row+1, col+3] == ' ' && (board[row+3, col+1] == 'X' || board[row+3, col+1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') && (board[row+1, col+3] == 'X' || board[row+1, col+3] == '%') && board[row+3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' '){
                                                if (board[row, col] == '@'){
                                                   board[row-2, col+2] = '@';
                                                    board[row-1, col+1] = ' ';
                                                    board[row, col] = ' ';  
                                                }
                                                else{
                                                    board[row-2, col+2] = 'O';
                                                    board[row-1, col+1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                k = true;
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && board[row-1, col+1] == ' ' && (board[row-3, col+3] == 'X' || board[row-3, col+3] == '%')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col+3));
                                                    isBeaten++;
                                                    atak = true;
                                                    beat = true;
                                                    choose = "L";
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && board[row-1, col+3] == ' ' && (board[row-3, col+1] == 'X' || board[row-3, col+1] == '%')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'O' || board[row-2, col+2] == '@') && (board[row-1, col+3] == 'X' || board[row-1, col+3] == '%') && board[row-3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }     
                                            if (col == 5 || col == 6 || col == 7){
                                                Console.Write("");
                                            }
                                            else if ((board[row+2, col+2] == 'O' || board[row+2, col+2] == '@') || (board[row-2, col+2] == 'O' || board[row-2, col+2] == '@'))
                                            {
                                                if (board[row+2, col+2] == 'O' || board[row+2, col+2] == '@'){
                                                    row = row + 2;
                                                    col = col + 2; 
                                                }
                                                else if (board[row-2, col+2] == 'O' || board[row-2, col+2] == '@'){
                                                    row = row - 2;
                                                    col = col + 2; 
                                                }
                                                while((col != 6 && col != 7 && (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row-2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row+2, col-2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2,col-2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'X', '%', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else if (col != 0 && row != 0 && ((board[row, col] == 'O' || board[row, col] == '@') && (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row-2, col-2] == ' ')){
                                            if (board[row, col] == '@'){
                                                board[row-2, col-2] = '@';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' '; 
                                            }
                                            else{
                                                board[row-2, col-2] = 'O';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' ';
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            if (board[row, col] == '@'){
                                              board[row+1, col+1] = '@';
                                                board[row, col] = ' ';  
                                            }
                                            else{
                                                board[row+1, col+1] = 'O';
                                                board[row, col] = ' ';
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board);   
                                            int isBeaten = 0;
                                            if (col == 6 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row, col] == ' ' && (board[row+2, col+2] == 'X' || board[row+2, col+2] == '%')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row+2) + ", " + (col+2));
                                                isBeaten++;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            }
                                            if (col == 6 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row, col+2] == ' ' && (board[row+2, col] == 'X' || board[row+2, col] == '%')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row+2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                            }  
                                            if (col == 6 || col == 1){
                                                Console.Write("");
                                            }
                                            else if (col != 0 && row != 0 && ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && (board[row, col-2] == 'X' || board[row, col-2] == '%') && board[row+2, col] == ' ')){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col+2));
                                                isBeaten = isBeaten + 4;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            } 
                                            var res = move1.isBeaten(isBeaten, row, col, 2, 0, 2, beat);
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "R";
                                            }
                                        }
                                    }
                                    else{
                                        Console.WriteLine("Incorrect data. Repeat it.");
                                    }   
                                }
                                else{
                                    var res = board1.thereIsNoPawn(board, row, col);
                                    row = res[0];
                                    col = res[1];
                                }
                            }               
                        }
                    }
                }
                else{
                    if (beat == false){
                        Console.WriteLine("Row: ");
                        row = Convert.ToInt32(Console.ReadLine());
                        while (row < 0 || row > 8){
                            Console.WriteLine("Fault! Enter the row number again:");
                            row = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Col: ");
                        col = Convert.ToInt32(Console.ReadLine());   
                        while (col < 0 || col > 8){
                            Console.WriteLine("Fault! Enter the col number again:");
                            col = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    bool k = false;
                    for (int i = 1; i < board.GetLength(0)-1; i++){
                        for (int j = 1; j < board.GetLength(1)-1; j++){
                            if (atak == false){
                                var rev = move1.behindBeating(board, 'X', '%', 'O', '@', row, col, choose, i, j);  
                                row = Convert.ToInt32(rev[0]);
                                col = Convert.ToInt32(rev[1]);
                                choose = rev[2];
                                if (rev[3] == "1"){
                                    beat = true;
                                    k = true;
                                }
                            }
                            while(k == false){
                                if(board[row, col] == 'X' || board[row, col] == '%'){
                                    if (beat == false){
                                        if (board[row, col] == 'X'){
                                            Console.WriteLine("Left - L, Right - R");
                                            choose = Console.ReadLine();   
                                            while (choose != "L" && choose != "l" && choose != "R" && choose != "r"){
                                                Console.WriteLine("Choose the direction");
                                                choose = Console.ReadLine();  
                                            }
                                        }
                                        else if (board[row, col] == '%'){
                                            Console.WriteLine("Up-Left - UL, Up-Right - UR, Down-Left - DL, Down-Right - DR");
                                            choose = Console.ReadLine();
                                            while (choose != "UR" && choose != "ur" && choose != "UL" && choose != "ul" && choose != "dl" && choose != "DL" && choose != "DR" && choose != "dr"){
                                                Console.WriteLine("Choose the direction");
                                                choose = Console.ReadLine();  
                                            }
                                        }
                                    }

                                    choose = board1.isPlaceOnBoard(choose, col, row);
                                    
                                    if (choose == "L" || choose == "l" || choose == "DL" || choose == "dl"){
                                        if (board[row+1, col-1] == 'X' || board[row+1, col-1] == '%'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            while (row < 0 || row > 8){
                                                Console.WriteLine("Fault! Enter the row number again:");
                                                row = Convert.ToInt32(Console.ReadLine());
                                            }
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());   
                                            while (col < 0 || col > 8){
                                                Console.WriteLine("Fault! Enter the col number again:");
                                                col = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }      
                                        else if (((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' ') || ((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ')){
                                            if((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' '){
                                                if (board[row, col] == '%'){
                                                    board[row+2, col-2] = '%';
                                                    board[row+1, col-1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                else{
                                                    board[row+2, col-2] = 'X';
                                                    board[row+1, col-1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && board[row+1, col-1] == ' ' && (board[row+3, col-3] == 'O' || board[row+3, col-3] == '@'))
                                                {
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col-3));
                                                    isBeaten++;
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && board[row+1, col-3] == ' ' && (board[row+3, col-1] == 'O' || board[row+3, col-1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && (board[row+1, col-3] == 'O' || board[row+1, col-3] == '@') && board[row+3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' '){
                                                if (board[row, col] == '%'){
                                                    board[row-2, col-2] = '%';
                                                    board[row-1, col-1] = ' ';
                                                    board[row, col] = ' ';
                                                }
                                                else{
                                                    board[row-2, col-2] = 'X';
                                                    board[row-1, col-1] = ' ';
                                                    board[row, col] = ' ';
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && board[row-1, col-1] == ' ' && (board[row-3, col-3] == 'O' || board[row-3, col-3] == '@'))
                                                {
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col-3));
                                                    isBeaten++;
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && board[row-1, col-3] == ' ' && (board[row-3, col-1] == 'O' || board[row-3, col-1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    beat = true;
                                                    atak = true;
                                                } 
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && (board[row-1, col-3] == 'O' || board[row-1, col-3] == '@') && board[row-3, col-1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    beat = true;
                                                    atak = true;
                                                }  
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }     
                                            if (col == 0 || col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') || (board[row-2, col-2] == 'X' || board[row-2, col-2] == '%')){
                                                if (board[row+2, col-2] == 'X' || board[row+2, col-2] == '%'){
                                                    row = row + 2;
                                                    col = col - 2; 

                                                }
                                                else if (board[row-2, col-2] == 'X' || board[row-2, col-2] == '%'){
                                                    row = row - 2;
                                                    col = col - 2; 
                                                }
                                                while((col != 0 && col != 1 && (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' ') || (col != 6 && col != 7 && (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2,col+2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'O', '@', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            } 
                                        }
                                        else if (col != 7 && ((board[row, col] == 'X' || board[row, col] == '%') && (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' ')){
                                            if (board[row, col] == '%'){
                                                board[row-2, col+2] = '%';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';
                                            }
                                            else{
                                              board[row-2, col+2] = 'X';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            if (board[row, col] == '%'){
                                                board[row+1,col-1] = '%';
                                                board[row, col] = ' ';
                                            }
                                            else{
                                              board[row+1,col-1] = 'X';
                                                board[row, col] = ' ';  
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                            int isBeaten = 0;
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row, col] == ' ' && (board[row+2, col-2] == 'O' || board[row+2, col-2] == '@')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row+2) + ", " + (col-2));
                                                isBeaten++;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                            }
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && board[row, col-2] == ' ' && (board[row+2, col] == 'O' || board[row+2, col] == '@')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row+2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            } 
                                            if (col == 1 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col-1] == 'X' || board[row+1, col-1] == '%') && (board[row, col-2] == 'O' || board[row, col-2] == '@') && board[row+2, col] == ' '){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col-2));
                                                isBeaten = isBeaten + 4;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                                Console.WriteLine(choose);
                                            } 
                                            var res = move1.isBeaten(isBeaten, row, col, 2, 0, -2, beat);
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "L";
                                            }
                                        }
                                    }
                                    else if (choose == "R" || choose == "r" || choose == "DP" || choose == "dp"){
                                        if (board[row+1, col+1] == 'X' || board[row+1, col+1] == '%'){
                                            Console.WriteLine("The field is taken. Choose again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());
                                        }
                                        
                                        else if (((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ') || ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2,col+2] == ' ')){
                                            if ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' '){
                                                if (board[row, col] == '%'){
                                                   board[row+2, col+2] = '%';
                                                    board[row+1, col+1] = ' ';
                                                    board[row, col] = ' ';  
                                                }
                                                else{
                                                    board[row+2, col+2] = 'X';
                                                    board[row+1, col+1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && board[row+1, col+1] == ' ' && (board[row+3, col+3] == 'O' || board[row+3, col+3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col+3));
                                                    isBeaten++;
                                                    atak = true;
                                                    beat = true;
                                                    choose = "L";
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && board[row+1, col+3] == ' ' && (board[row+3, col+1] == 'O' || board[row+3, col+1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && (board[row+1, col+3] == 'O' || board[row+1, col+3] == '@') && board[row+3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row+1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' '){
                                                if (board[row, col] == '%'){
                                                   board[row-2, col+2] = '%';
                                                    board[row-1, col+1] = ' ';
                                                    board[row, col] = ' ';  
                                                }
                                                else{
                                                    board[row-2, col+2] = 'X';
                                                    board[row-1, col+1] = ' ';
                                                    board[row, col] = ' '; 
                                                }
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                k = true;
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && board[row-1, col+1] == ' ' && (board[row-3, col+3] == 'O' || board[row-3, col+3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col+3));
                                                    isBeaten++;
                                                    atak = true;
                                                    beat = true;
                                                    choose = "L";
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && board[row-1, col+3] == ' ' && (board[row-3, col+1] == 'O' || board[row-3, col+1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && (board[row-1, col+3] == 'O' || board[row-1, col+3] == '@') && board[row-3, col+1] == ' '){
                                                    Console.WriteLine("3. You can beat with pawn: " + (row-1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    atak = true;
                                                    beat = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }     
                                            if (col == 5 || col == 6 || col == 7){
                                                Console.Write("");
                                            }
                                            else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') || (board[row-2, col+2] == 'X' || board[row-2, col+2] == '%'))
                                            {
                                                if (board[row+2, col+2] == 'X' || board[row+2, col+2] == '%'){
                                                    row = row + 2;
                                                    col = col + 2; 
                                                }
                                                else if (board[row-2, col+2] == 'X' || board[row-2, col+2] == '%'){
                                                    row = row - 2;
                                                    col = col + 2; 
                                                }
                                                while((col != 6 && col != 7 && (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2,col-2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'O', '@', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else if (col != 0 && row != 0 && ((board[row, col] == 'X' || board[row, col] == '%') && (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ')){
                                            if (board[row, col] == '%'){
                                                board[row-2, col-2] = '%';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' '; 
                                            }
                                            else{
                                                board[row-2, col-2] = 'X';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' ';
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            if (board[row, col] == '%'){
                                              board[row+1, col+1] = '%';
                                                board[row, col] = ' ';  
                                            }
                                            else{
                                                board[row+1, col+1] = 'X';
                                                board[row, col] = ' ';
                                            }
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board);   
                                            int isBeaten = 0;
                                            if (col == 6 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row, col] == ' ' && (board[row+2, col+2] == 'O' || board[row+2, col+2] == '@')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row+2) + ", " + (col+2));
                                                isBeaten++;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            }
                                            if (col == 6 || row == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && board[row, col+2] == ' ' && (board[row+2, col] == 'O' || board[row+2, col] == '@')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row+2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                beat = true;
                                                atak = true;
                                                choose = "L";
                                            }  
                                            if (col == 6 || col == 1){
                                                Console.Write("");
                                            }
                                            else if (col != 0 && row != 0 && ((board[row+1, col+1] == 'X' || board[row+1, col+1] == '%') && (board[row, col-2] == 'O' || board[row, col-2] == '@') && board[row+2, col] == ' ')){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col+2));
                                                isBeaten = isBeaten + 4;
                                                beat = true;
                                                atak = true;
                                                choose = "R";
                                            } 
                                            var res = move1.isBeaten(isBeaten, row, col, 2, 0, 2, beat);
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "R";
                                        }
                                    }
                                }
                                else if (choose == "GL" || choose == "gl"){
                                        if (board[row-1, col-1] == 'X' || board[row-1, col-1] == '%'){
                                            Console.WriteLine(board[row-1, col-1]);
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            Console.WriteLine("Row: ");
                                            row = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Col: ");
                                            col = Convert.ToInt32(Console.ReadLine());
                                        }
                                        else if (((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ') || (row != 7 && (board[row+1,col-1] == 'O' || board[row+1,col-1] == '@') && row != 6 && row != 7 && board[row+2, col-2] == ' ')){
                                            if ((board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' '){
                                                board[row-2, col-2] = '%';
                                                board[row-1, col-1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                int isBeaten = 0;
                                                if (col == 2 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && board[row-1, col-1] == ' ' && (board[row-3, col-3] == 'O' || board[row-3, col-3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col-3));
                                                    isBeaten++;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && board[row-1, col-3] == ' ' && (board[row-3, col-1] == 'O' || board[row-3, col-1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row-2, col-2] == 'X' || board[row-2, col-2] == '%') && (board[row-1, col-3] == 'O' || board[row-1, col-3] == '@') && board[row-3, col-1] == ' '){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "L";
                                                }
                                            }
                                            else if ((board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' '){
                                                board[row+2, col-2] = '%';
                                                board[row+1, col-1] = ' ';
                                                board[row, col] = ' ';
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                beat = false;
                                                board1.superPawn(board);
                                                board1.printBoard(board);  
                                                int isBeaten = 0;
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && board[row+1, col-1] == ' ' && (board[row+3, col-3] == 'O' || board[row+3, col-3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col-3));
                                                    isBeaten++;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && board[row+1, col-3] == ' ' && (board[row+3, col-1] == 'O' || board[row+3, col-1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col-1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 0 || col == 1 || col == 2){
                                                    Console.Write("");
                                                }
                                                else if ((board[row+2, col-2] == 'X' || board[row+2, col-2] == '%') && (board[row+1, col-3] == 'O' || board[row+1, col-3] == '@') && board[row+3, col-1] == ' '){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+1) + ", " + (col-3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, 3, -1, -3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }                                
                                            if (col == 0 || col == 1 || row == 0 || row == 1 || row == 6 || row == 7){
                                                Console.Write("");
                                            }
                                            else if (board[row-2, col-2] == 'X' || board[row-2, col-2] == '%' || board[row+2, col-2] == 'X' || board[row+2, col-2] == '%')
                                            {      
                                                if (board[row-2, col-2] == 'X' || board[row-2, col-2] == '%'){
                                                    row = row - 2;
                                                    col = col - 2; 
                                                }
                                                else if (board[row+2, col-2] == 'X' || board[row+2, col-2] == '%'){
                                                    row = row + 2;
                                                    col = col - 2; 
                                                }  
                                                while (row != 6 && col != 0 && col != 1 && board[row+2, col-2] == ' ' && (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') || (col != 6 && col != 7 && (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' ') || (col != 0 && col != 1 && (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ') || (row != 6 && col != 6 && col != 7 && (board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ')){
                                                    
                                                    var ress = move1.isMultipleAttack(board, 'O', '@', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else{
                                            board[row-1, col-1] = '%';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            board1.superPawn(board);
                                            board1.printBoard(board);  
                                            int isBeaten = 0;
                                            beat = false;
                                            if (row == 1 || col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row, col] == ' ' && (board[row-2, col-2] == 'O' || board[row-2, col-2] == '@')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row-2) + ", " + (col-2));
                                                isBeaten++;
                                                choose = "L";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 1 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && board[row, col-2] == ' ' && (board[row-2, col] == 'O' || board[row-2, col] == '@')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row-2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col-1] == 'X' || board[row-1, col-1] == '%') && (board[row, col-2] == 'O' || board[row, col-2] == '@') && board[row-2, col] == ' '){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col-2));
                                                isBeaten = isBeaten + 4;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            var res = move1.isBeaten(isBeaten, row, col, -2, 0, -2, beat); 
                                            row = res[0];
                                            col = res[1];
                                            if (res[2] == 1){
                                                choose = "R";
                                            }
                                        }
                                    }
                                    else if (choose == "GP" || choose == "gp"){
                                        if (board[row-1, col+1] == 'X' || board[row-1, col+1] == '%'){
                                            Console.WriteLine("There is another pawn on this field. Please select again.");
                                            if (beat == false){
                                                Console.WriteLine("Row: ");
                                                row = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Col: ");
                                                col = Convert.ToInt32(Console.ReadLine());
                                            }
                                        }
                                        else if (row != 0 && row != 1 && col != 6 && col != 7 && ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' ') || row != 6 && row != 7 && col != 6 && row != 7 && ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ')){
                                            if ((board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' '){
                                                board[row-2, col+2] = '%';
                                                board[row-1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && board[row-1, col+1] == ' ' && (board[row-3, col+3] == 'O' || board[row-3, col+3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row-3) + ", " + (col+3));
                                                    isBeaten++;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && board[row-1, col+3] == ' ' && (board[row-3, col+1] == 'O' || board[row-3, col+1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') && (board[row-1, col+3] == 'O' || board[row-1, col+3] == '@') && board[row-3, col+1] == ' '){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row-1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }
                                            else if ((board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' '){
                                                board[row+2, col+2] = '%';
                                                board[row+1, col+1] = ' ';
                                                board[row, col] = ' ';  
                                                if (strike == false){
                                                    counter++;
                                                }      
                                                k = true;
                                                board1.superPawn(board);
                                                board1.printBoard(board); 
                                                beat = false;
                                                int isBeaten = 0;
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && board[row+1, col+1] == ' ' && (board[row+3, col+3] == 'O' || board[row+3, col+3] == '@')){
                                                    Console.WriteLine("1. You can beat with pawn: " + (row+3) + ", " + (col+3));
                                                    isBeaten++;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && board[row+1, col+3] == ' ' && (board[row+3, col+1] == 'O' || board[row+3, col+1] == '@')){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+3) + ", " + (col+1));
                                                    isBeaten = isBeaten + 2;
                                                    choose = "L";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                if (col == 5 || col == 6 || col == 7){
                                                    Console.WriteLine();
                                                }
                                                else if ((board[row+2, col+2] == 'X' || board[row+2, col+2] == '%') && (board[row+1, col+3] == 'O' || board[row+1, col+3] == '@') && board[row+3, col+1] == ' '){
                                                    Console.WriteLine("2. You can beat with pawn: " + (row+1) + ", " + (col+3));
                                                    isBeaten = isBeaten + 4;
                                                    choose = "R";
                                                    beat = true;
                                                    atak = true;
                                                }
                                                var res = move1.isBeaten(isBeaten, row, col, -3, 1, 3, beat);
                                                row = res[0];
                                                col = res[1];
                                                if (res[2] == 1){
                                                    choose = "R";
                                                }
                                            }   
                                            if (col == 6 || col == 7){
                                                Console.WriteLine();
                                            }
                                            else if ((board[row-2, col+2] == 'X' || board[row-2, col+2] == '%') || (board[row+2, col+2] == 'X' || board[row+2, col+2] == '%'))
                                            {
                                                if (board[row-2, col+2] == 'X' || board[row-2, col+2] == '%'){
                                                    row = row - 2;
                                                    col = col + 2; 
                                                }
                                                else if (board[row+2, col+2] == 'X' || board[row+2, col+2] == '%'){
                                                    row = row + 2;
                                                    col = col + 2; 
                                                }
                                                while((col != 0 && col != 1 && (board[row-1, col-1] == 'O' || board[row-1, col-1] == '@') && board[row-2, col-2] == ' ') || (col != 6 && col != 7 && (board[row-1, col+1] == 'O' || board[row-1, col+1] == '@') && board[row-2, col+2] == ' ') || (col != 6 && col != 7 && (board[row+1, col+1] == 'O' || board[row+1, col+1] == '@') && board[row+2, col+2] == ' ') || (col != 0 && col != 1 && (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2,col-2] == ' ')){

                                                    var ress = move1.isMultipleAttack(board, 'O', '@', row, col);
                                                    row = ress[0];
                                                    col = ress[1];
                                                }
                                            }
                                        }
                                        else if (row != 7 && col != 0 && ((board[row, col] == 'X' || board[row, col] == '%') && (board[row+1, col-1] == 'O' || board[row+1, col-1] == '@') && board[row+2, col-2] == ' ')){
                                            board[row+2, col-2] = '%';
                                            board[row+1, col-1] = ' ';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                        }
                                        else{
                                            board[row-1, col+1] = '%';
                                            board[row, col] = ' ';
                                            if (strike == false){
                                                counter++;
                                            }      
                                            k = true;
                                            beat = false;
                                            board1.superPawn(board);
                                            board1.printBoard(board); 
                                            int isBeaten = 0;
                                            if (col == 6 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row, col] == ' ' && (board[row-2, col+2] == 'O' || board[row-2, col+2] == '@')){
                                                Console.WriteLine("1. You can beat with pawn: " + (row-2) + ", " + (col+2));
                                                isBeaten++;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 6 || row == 1){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && board[row, col+2] == ' ' && (board[row-2, col] == 'O' || board[row-2, col] == '@')){
                                                Console.WriteLine("2. You can beat with pawn: " + (row-2) + ", " + (col));
                                                isBeaten = isBeaten + 2;
                                                choose = "L";
                                                beat = true;
                                                atak = true;
                                            }
                                            if (col == 5 || col == 6){
                                                Console.Write("");
                                            }
                                            else if ((board[row-1, col+1] == 'X' || board[row-1, col+1] == '%') && (board[row, col+2] == 'O' || board[row, col+2] == '@') && board[row-2, col] == ' '){
                                                Console.WriteLine("3. You can beat with pawn: " + (row) + ", " + (col+2));
                                                isBeaten = isBeaten + 4;
                                                choose = "R";
                                                beat = true;
                                                atak = true;
                                            }
                                            var res = move1.isBeaten(isBeaten, row, col, -2, 0, 2, beat);
                                            row = res[0];
                                            col = res[1];    
                                            if (res[2] == 1){
                                                choose = "R";
                                            }               
                                        }
                                    }
                                    else{
                                        Console.WriteLine("Incorrect data. Repeat it.");
                                    }
                                } 
                                else{
                                    var res = board1.thereIsNoPawn(board, row, col);
                                    row = res[0];
                                    col = res[1];
                                }
                            }                    
                        }
                    }
                }
            }
        }
    }
}