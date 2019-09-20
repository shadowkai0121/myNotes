using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入數量(>2)：");
            int amount = int.Parse(Console.ReadLine());

            int[] nums = new int[amount];
            nums[0] = 1;
            nums[1] = 1;

            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = nums[i - 1] + nums[i - 2];
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
