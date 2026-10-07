namespace matrix

{
    internal class Program
    {
        static void output(int M, int N, Double[,] matrix)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(" | " + matrix[i, j]);
                }
                Console.Write(" |");
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            int N = 0, M = 0;
            Console.Write("Enter size row: ");
            M = int.Parse(Console.ReadLine()!);
            Console.Write("Enter size column: ");
            N = int.Parse(Console.ReadLine()!);
            Double[,] matrix = new double[M, N];

            //input 
            for (int row = 0; row < M; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    Console.WriteLine($"Enrer your number ({row + 1},{column + 1})");
                    matrix[row, column] = double.Parse(Console.ReadLine()!);
                }
            }
            //output 
            Console.WriteLine("your matrix:");
            output(M, N, matrix);
            //-------------------> 

            bool isZeroRow = true;
            int topRow = 0;
            int bottomRow = M - 1;
            for (topRow = 0; topRow < M; topRow++)
            {
                if( topRow >= bottomRow )
                {
                    break;
                }

                isZeroRow = true;
                for (int column = 0; column < N; column++)
                {
                    if (matrix[topRow, column] != 0)
                    {
                        isZeroRow = false;
                        break;
                    }
                }
                if (isZeroRow == true)
                {

                    for (bottomRow = M - 1; bottomRow > topRow; bottomRow--)
                    {
                        isZeroRow = true;
                        for (int column = 0; column < N; column++)
                        {
                            if (matrix[bottomRow, column] != 0)
                            {
                                isZeroRow = false;
                                break;
                            }
                        }

                        if (isZeroRow == false)
                        {
                            double tmp = 0;
                            for (int column = 0; column < N; column++)
                            {
                                tmp = matrix[topRow, column];
                                matrix[topRow, column] = matrix[bottomRow, column];
                                matrix[bottomRow, column] = tmp;
                            }
                            Console.WriteLine($"Row {topRow + 1} swapped with Row {bottomRow + 1}");
                            output(M, N, matrix);
                            topRow++;
                        }
                    }
                }
            }
            int pivotRow = 0;
            for (int col = 0; col < N && pivotRow < M; col++)
            {
                int found = -1;
                for (int row = pivotRow; row < M; row++)
                {
                    if (matrix[row, col] != 0)
                    {
                        found = row;
                        break;
                    }
                }

                if (found == -1)
                {
                    continue;
                }

                if (found != pivotRow)
                {
                    double tmp = 0;
                    for (int column = 0; column < N; column++)
                    {
                        tmp = matrix[pivotRow, column];
                        matrix[pivotRow, col] = matrix[found, column];
                        matrix[found, column] = tmp;
                    }
                    Console.WriteLine($"Row {pivotRow + 1} swapped with Row {found + 1}");
                    output(M, N, matrix);
                }

                if (matrix[pivotRow, col] != 1)
                {
                    double pivot = matrix[pivotRow, col];
                    for (int column = 0; column < N; column++)
                    {
                        matrix[pivotRow, column] /= pivot;
                    }
                    Console.WriteLine($"Division by {pivot} in row {pivotRow + 1}");
                    output(M, N, matrix);
                }

                for (int row = pivotRow + 1; row < M; row++)
                {
                    if (matrix[row, col] != 0)
                    {
                        double c = matrix[row, col];
                        for (int column = 0; column < N; column++)
                        {
                            matrix[row, column] -= c * matrix[pivotRow, column];
                        }
                        Console.WriteLine($"Row {row + 1} -= {c} * Row {pivotRow + 1}");
                        output(M, N, matrix);
                    }
                }
                pivotRow++;
            }
        }
    }
}