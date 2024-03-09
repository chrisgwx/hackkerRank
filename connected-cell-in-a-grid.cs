using System;
/* 
 * https://www.hackerrank.com/challenges/connected-cell-in-a-grid/problem
 *My Idea was to use recursion to traverse the connected region, marking visited cells to avoid counting them multiple times
 */
class Solution
{
    static void Main()
    {
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        bool[,] arr = new bool[m, n];

        for (int i = 0; i < m; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');

            for (int j = 0; j < temp.Length; j++)
            {
                arr[i, j] = temp[j] == "1";
            }
        }

        int result = FindLargestRegion(arr);
        Console.WriteLine(result);
    }

    static int FindLargestRegion(bool[,] arr)
    {
        int max = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j])
                {
                    int val = CalcAdjacent(arr, i, j);

                    if (val > max)
                    {
                        max = val;
                    }
                }
            }
        }

        return max;
    }

    static int CalcAdjacent(bool[,] arr, int i, int j)
    {
        if (i < 0 || i >= arr.GetLength(0) || j < 0 || j >= arr.GetLength(1) || !arr[i, j])
        {
            return 0;
        }

        arr[i, j] = false;

        int val = 1;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                val += CalcAdjacent(arr, i + x, j + y);
            }
        }

        return val;
    }
}
