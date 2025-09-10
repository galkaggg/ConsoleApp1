class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("проверка симметричности квадр. матр. относительно главной диагонали");
        Console.WriteLine();
        Console.Write("введите размер квадратной матрицы n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("ошибка: размер матрицы должен быть положительным целым числом.");
            return;
        }
        double[,] matrix = new double[n, n];

        Console.WriteLine($"введите {n} строк по {n} вещественных чисел (через пробел):");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"строка {i + 1}: ");
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != n)
            {
                Console.WriteLine($"ошибка: ожидается {n} чисел в строке.");
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (!double.TryParse(input[j], out matrix[i, j]))
                {
                    Console.WriteLine($"ошибка: '{input[j]}' не является корректным вещественным числом.");
                    return;
                }
            }
        }

        // вывод матрицы 
        Console.WriteLine("\nваша матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }

        // проверка сим-ти
        bool isSymmetric = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++) // проверяем только верхний треугольник
            {
                if (Math.Abs(matrix[i, j] - matrix[j, i]) > 1e-9)
                {
                    isSymmetric = false;
                    break;
                }
            }
            if (!isSymmetric) break;
        }

        Console.WriteLine();
        if (isSymmetric)
        {
            Console.WriteLine("матрица симметрична относительно главной диагонали.");
        }
        else
        {
            Console.WriteLine("матрица НЕ симметрична относительно главной диагонали.");
        }

        Console.WriteLine("\nнажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
