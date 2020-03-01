using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////int[] A = { 1, 3, 4, 2, 2, 2, 1, 1, 2 };
            ////int[] A = { 1, 1, 1 ,1 ,1 ,1};

            int[] A = new int[20000];
            A[0] = 1;
            for (int i = 1; i < 20000; i++)
            {
                if (A[i - 1] == 1)
                {
                    A[i] = 2;
                }
                else
                {
                    A[i] = 1;
                }
            }
            ////A[9999] = 7;
            ////A[19999] = 5;

            Console.WriteLine(Solution(A).ToString());
            Console.ReadLine();
        }

        
        public static bool Solution(int[] A)
        {
            bool result = false;
            var array_length = A.Length;
            var variable_length = 1;
            bool search_continue = true;

            if (A.Length >= 5 && !A.Any(x=> x <= 0) && array_length - (variable_length * 2) >= 1) 
            {
                int[] one = new int[variable_length];
                int[] two = new int[variable_length];
                int[] three = new int[array_length - (variable_length * 2)];

                Array.Copy(A, 0, one, 0, variable_length);
                Array.Copy(A, variable_length, two, 0, variable_length);
                Array.Copy(A, (variable_length * 2), three, 0, array_length - (variable_length * 2));

                int sum_one = one.Sum();
                int sum_two = two.Sum();
                int sum_three = three.Sum();

                int dif_one_two = Math.Abs(sum_one - sum_two);
                int dif_one_three = Math.Abs(sum_one - sum_three);
                int dif_two_three = Math.Abs(sum_two - sum_three);

                int index_dif_one_two;
                int index_dif_one_three;
                int index_dif_two_three;

                int number_of_iterations = 0;

                List<int> tmp_list;

                while (search_continue && number_of_iterations <= (array_length - (variable_length * 2)))
                {
                    ////Console.WriteLine($"Iterations: {number_of_iterations.ToString()}");
                    number_of_iterations++;
                    if (sum_one < sum_two && sum_one < sum_three)
                    {
                        index_dif_one_two = two.ToList().IndexOf(dif_one_two);
                        if (index_dif_one_two >= 0)
                        {
                            tmp_list = two.ToList();
                            tmp_list.RemoveAt(index_dif_one_two);

                            two = tmp_list.ToArray();
                            sum_two = two.Sum();
                            index_dif_one_three = three.ToList().IndexOf(dif_one_three);
                            if (index_dif_one_three >= 0)
                            {
                                tmp_list = three.ToList();
                                tmp_list.RemoveAt(index_dif_one_three);

                                three = tmp_list.ToArray();
                                sum_three = three.Sum();
                                if (sum_one == sum_two && sum_one == sum_three)
                                {
                                    result = true;
                                    search_continue = false;
                                    //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (sum_two < sum_one && sum_two < sum_three)
                        {
                            index_dif_one_two = one.ToList().IndexOf(dif_one_two);
                            if (index_dif_one_two >= 0)
                            {
                                tmp_list = one.ToList();
                                tmp_list.RemoveAt(index_dif_one_two);

                                one = tmp_list.ToArray();
                                sum_one = one.Sum();
                                index_dif_two_three = three.ToList().IndexOf(dif_two_three);
                                if (index_dif_two_three >= 0)
                                {
                                    tmp_list = three.ToList();
                                    tmp_list.RemoveAt(index_dif_two_three);

                                    three = tmp_list.ToArray();
                                    sum_three = three.Sum();
                                    if (sum_one == sum_two && sum_one == sum_three)
                                    {
                                        result = true;
                                        search_continue = false;
                                        //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (sum_three < sum_one && sum_three < sum_two)
                            {
                                index_dif_one_three = one.ToList().IndexOf(dif_one_three);
                                if (index_dif_one_three >= 0)
                                {
                                    tmp_list = one.ToList();
                                    tmp_list.RemoveAt(index_dif_one_three);
                                    one = tmp_list.ToArray();
                                    sum_one = one.Sum();
                                    index_dif_two_three = two.ToList().IndexOf(dif_two_three);
                                    if (index_dif_two_three >= 0)
                                    {
                                        tmp_list = two.ToList();
                                        tmp_list.RemoveAt(index_dif_two_three);
                                        two = tmp_list.ToArray();
                                        sum_two = two.Sum();
                                        if (sum_one == sum_two && sum_one == sum_three)
                                        {
                                            result = true;
                                            search_continue = false;
                                            //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (sum_one == sum_two && sum_one != sum_three)
                                {
                                    if (sum_one > sum_three)
                                    {
                                        var tmpOne = one.Skip(2).ToArray();
                                        var sum_tmpOne = tmpOne.Sum();
                                        if (sum_tmpOne == sum_three)
                                        {
                                            result = true;
                                            search_continue = false;
                                            //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                        }
                                        else
                                        {
                                            tmpOne = one.Where((item, index) => index != one.Length - 1 && index != one.Length - 2).ToArray();
                                            if (sum_tmpOne == sum_three)
                                            {
                                                result = true;
                                                search_continue = false;
                                                //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var tmpThree = three.Skip(2).ToArray();
                                        var sum_tmpThree = tmpThree.Sum();
                                        if (sum_tmpThree == sum_one)
                                        {
                                            result = true;
                                            search_continue = false;
                                            //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                        }
                                        else
                                        {
                                            tmpThree = three.Where((item, index) => index != three.Length - 1 && index != three.Length - 2).ToArray();
                                            if (sum_tmpThree == sum_one)
                                            {
                                                result = true;
                                                search_continue = false;
                                                //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (sum_one == sum_three && sum_one != sum_two)
                                    {
                                        if (sum_one > sum_two)
                                        {
                                            var tmpOne = one.Skip(2).ToArray();
                                            var sum_tmpOne = tmpOne.Sum();
                                            if (sum_tmpOne == sum_two)
                                            {
                                                result = true;
                                                search_continue = false;
                                                //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                            }
                                            else
                                            {
                                                tmpOne = one.Where((item, index) => index != one.Length - 1 && index != one.Length - 2).ToArray();
                                                if (sum_tmpOne == sum_two)
                                                {
                                                    result = true;
                                                    search_continue = false;
                                                    //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            var tmpTwo = two.Skip(2).ToArray();
                                            var sum_tmpTwo = tmpTwo.Sum();
                                            if (sum_tmpTwo == sum_one)
                                            {
                                                result = true;
                                                search_continue = false;
                                                //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                            }
                                            else
                                            {
                                                tmpTwo = two.Where((item, index) => index != two.Length - 1 && index != two.Length - 2).ToArray();
                                                if (sum_tmpTwo == sum_one)
                                                {
                                                    result = true;
                                                    search_continue = false;
                                                    //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (sum_three == sum_two && sum_one != sum_three)
                                        {
                                            if (sum_one > sum_two)
                                            {
                                                var tmpOne = one.Skip(2).ToArray();
                                                var sum_tmpOne = tmpOne.Sum();
                                                if (sum_tmpOne == sum_two)
                                                {
                                                    result = true;
                                                    search_continue = false;
                                                    //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                }
                                                else
                                                {
                                                    tmpOne = one.Where((item, index) => index != one.Length - 1 && index != one.Length - 2).ToArray();
                                                    if (sum_tmpOne == sum_two)
                                                    {
                                                        result = true;
                                                        search_continue = false;
                                                        //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                var tmpTwo = two.Skip(2).ToArray();
                                                var sum_tmpTwo = tmpTwo.Sum();
                                                if (sum_tmpTwo == sum_one)
                                                {
                                                    result = true;
                                                    search_continue = false;
                                                    //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                }
                                                else
                                                {
                                                    tmpTwo = two.Where((item, index) => index != two.Length - 1 && index != two.Length - 2).ToArray();
                                                    if (sum_tmpTwo == sum_one)
                                                    {
                                                        result = true;
                                                        search_continue = false;
                                                        //Console.WriteLine($"Sum: {sum_one.ToString()}");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (search_continue)
                    {
                        variable_length++;
                        if (array_length - (variable_length * 2) >= 1)
                        {
                            one = new int[variable_length];
                            two = new int[variable_length];
                            three = new int[array_length - (variable_length * 2)];

                            Array.Copy(A, 0, one, 0, variable_length);
                            Array.Copy(A, variable_length, two, 0, variable_length);
                            Array.Copy(A, (variable_length * 2), three, 0, array_length - (variable_length * 2));

                            sum_one = one.Sum();
                            sum_two = two.Sum();
                            sum_three = three.Sum();

                            dif_one_two = Math.Abs(sum_one - sum_two);
                            dif_one_three = Math.Abs(sum_one - sum_three);
                            dif_two_three = Math.Abs(sum_two - sum_three);
                        }
                    }
                }
            }


            return result;

        }
    }
}
