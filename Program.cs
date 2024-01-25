namespace Tetris_text_csharp
{
    internal class Program
    {
        static int sizeX = 10;
        static int sizeY = 5;
        static char charEmpty = '.';
        static char charPiece = 'o';
        //TO DO:charPiece must be different than charFilled due to RotatePiece
        static char charFilled = 's';
        static char[,] gridChars = new char[sizeX, sizeY];

        static void Main(string[] args)
        {
            Console.WriteLine("Tetrix text game!\n");
            DrawGridInit();
            //gridChars[1, 2] = charPiece;
            //gridChars[1, 3] = charFilled;
            gridChars[4, 4] = charFilled;
            PrintGrid();
            AddPiece('T');
            PrintGrid();
            RotatePiece();
            PrintGrid();
            MovePieceDown();
            PrintGrid();
            MovePieceDown();
            PrintGrid();
            MovePieceDown();
            PrintGrid();
        }

        public static void DrawGridInit()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    gridChars[i, j] = charEmpty;
                }
            }
        }

        public static void AddPiece(char pieceType)
        {
            /* Geo choice: O, I, S, Z, L, J, T
            https://miro.medium.com/v2/resize:fit:828/format:webp/0*XduzlQ6FEPgqwiOy.  */

            int midGrid = (sizeX / 2);
            if (pieceType == 'O')
            {
                Console.WriteLine("\nAdding O");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid + 1, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
                gridChars[midGrid + 1, 1] = charPiece;
            }
            else if (pieceType == 'I')
            {
                Console.WriteLine("\nAdding I");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
                gridChars[midGrid, 2] = charPiece;
                gridChars[midGrid, 3] = charPiece;
            }
            else if (pieceType == 'S')
            {
                Console.WriteLine("\nAdding S");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid + 1, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
                gridChars[midGrid - 1, 1] = charPiece;
            }
            else if (pieceType == 'Z')
            {
                Console.WriteLine("\nAdding Z");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid - 1, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
                gridChars[midGrid + 1, 1] = charPiece;
            }
            else if (pieceType == 'L')
            {
                Console.WriteLine("\nAdding L");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
                gridChars[midGrid, 2] = charPiece;
                gridChars[midGrid + 1, 2] = charPiece;
            }
            else if (pieceType == 'J')
            {
                Console.WriteLine("\nAdding J");
                gridChars[midGrid + 1, 0] = charPiece;
                gridChars[midGrid + 1, 1] = charPiece;
                gridChars[midGrid + 1, 2] = charPiece;
                gridChars[midGrid, 2] = charPiece;
            }
            else if (pieceType == 'T')
            {
                Console.WriteLine("\nAdding T");
                gridChars[midGrid, 0] = charPiece;
                gridChars[midGrid - 1, 0] = charPiece;
                gridChars[midGrid + 1, 0] = charPiece;
                gridChars[midGrid, 1] = charPiece;
            }
            else
            {
                Console.WriteLine("ERROR: piece type not supported: " + pieceType);
            }
        }

        public static void RotatePiece()
        {
            /*
            .oo..      ..o..
            ..oo.  to  .oo..
            .....      .o...
            */

            Console.WriteLine("\nRotate piece CCW");

            int pieceMinX = 999999;
            int pieceMaxX = -1;
            int pieceMinY = 999999;
            int pieceMaxY = -1;
            //Save out piece in temp matrix
            char[,] gridCharsTemp = new char[4, 4];
            char[,] gridCharsTempNew = new char[4, 4];

            //Get min/max extend of piece
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (gridChars[i, j] == charPiece)
                    {
                        if (i <= pieceMinX) { pieceMinX = i; }
                        if (i > pieceMaxX) { pieceMaxX = i; }
                        if (j <= pieceMinY) { pieceMinY = j; }
                        if (j > pieceMaxY) { pieceMaxY = j; }
                    }
                }
            }
            //Save out piece in temp matrix
            for (int i = pieceMinX; i <= pieceMaxX; i++)
            {
                for (int j = pieceMinY; j <= pieceMaxY; j++)
                {
                    gridCharsTemp[i - pieceMinX, j - pieceMinY] = gridChars[i, j];
                    //Clear piece
                    gridChars[i, j] = charEmpty;
                }
            }
            //Console.WriteLine("pieceMinX: " + pieceMinX);
            //Console.WriteLine("pieceMaxX: " + pieceMaxX);
            //Console.WriteLine("pieceMinY: " + pieceMinY);
            //Console.WriteLine("pieceMaxY: " + pieceMaxY);

            //Print out test matrix
            //Console.WriteLine("\nTemp_matrix start");
            //for (int j = 0; j < 4; j++)
            //{
            //    string test = "";
            //    for (int i = 0; i < 4; i++)
            //    {
            //        test += gridCharsTemp[i, j];
            //    }
            //    Console.WriteLine(test);
            //}
            //Console.WriteLine("Temp_matrix end");

            int pieceDelX = pieceMaxX - pieceMinX;
            int pieceDelY = pieceMaxY - pieceMinY;
            //Console.WriteLine("pieceDelX: " + pieceDelX);
            //Console.WriteLine("pieceDelY: " + pieceDelY);

            //Rotate new temp matrix - CW
            for (int j = 0; j <= pieceDelX; j++)
            {
                for (int i = 0; i <= pieceDelY; i++)
                {
                    int testt = ((pieceDelY) - j);
                    gridCharsTempNew[i, j] = gridCharsTemp[((pieceDelX) - j), i];
                }
            }

            //Print out new temp matrix
            //Console.WriteLine("Temp_matrix_new start");
            //for (int j = 0; j < 4; j++)
            //{
            //    string test = "";
            //    for (int i = 0; i < 4; i++)
            //    {
            //        test += gridCharsTempNew[i, j];
            //    }
            //    Console.WriteLine(test);
            //}
            //Console.WriteLine("Temp_matrix_new end\n");

            //Write back new temp matrix to gridChars[]
            for (int i = pieceMinX; i <= pieceMinX + 3; i++)
            {
                for (int j = pieceMinY; j <= pieceMinY + 3; j++)
                {
                    char charToWrite = gridCharsTempNew[i - pieceMinX, j - pieceMinY];
                    if (charToWrite == charPiece)
                    {
                        gridChars[i, j] = charToWrite;
                    }
                }
            }
        }

        public static void MovePieceDown()
        {
            Console.WriteLine("\nMove piece down");

            bool canBeMoved = true;

            //Go down each line and check if charPiece can be moved
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (j == sizeY - 1 && gridChars[i, j] == charPiece)
                    {
                        canBeMoved = false;
                    }
                    if (j < sizeY - 1)
                    {
                        if (gridChars[i, j] == charPiece && gridChars[i, j + 1] == charFilled)
                        {
                        canBeMoved = false;
                        }
                    }
                }
            }
            Console.WriteLine("Can be moved down: " +canBeMoved);

            //Move piece down
            if (canBeMoved)
            {
                for (int i = sizeX - 1; i >= 0; i--)
                {
                    for (int j = sizeY - 1; j >= 0; j--)
                    {
                        if (j > 0)
                        {
                            if (gridChars[i, j - 1] == charPiece)
                            {
                                gridChars[i, j] = charPiece;
                                gridChars[i, j - 1] = charEmpty;
                            }
                        }
                    }
                }
            }

            //Solidify piece
            if (!canBeMoved)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    for (int j = 0; j < sizeY; j++)
                    {
                        if (gridChars[i, j] == charPiece)
                        {
                            gridChars[i, j] = charFilled;
                        }
                    }
                }
            }
        }

        public static void PrintGrid()
        {
            Console.WriteLine("Print Grid:");
            for (int j = 0; j < sizeY; j++)
            {
                string test = "";
                for (int i = 0; i < sizeX; i++)
                {
                    test += gridChars[i, j];
                }
                Console.WriteLine(test);
            }
        }
    }
}