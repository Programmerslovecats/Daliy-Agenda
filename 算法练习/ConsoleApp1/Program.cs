using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        #region    //算法练习：求出1~9，中间任意添加+，-， ，三种情况时能够得到的所有等于100的公式，例如：123-45-67+89
        /// <summary>
        /// 比较好的解决方式
        /// </summary>
        public class OneOneZero
        {
            public static void Main1(String[] args)
            {
                int[] result = new int[8];
                getResult(0, result);
            }
            //使用递归求出3^8种情况  
            public static void getResult(int index, int[] result)
            {
                if (index == 8)
                {
                    showResult(result);//根据数组的取值转换成表达式，且求值，这方法有待改进，写的很乱  
                    return;
                }
                //每个空有三种可能，0,1,2  
                for (int i = 0; i < 3; i++)
                {
                    result[index] = i;
                    getResult(index + 1, result);
                    result[index] = 0; //恢复原来的状态  
                }
            }
            public static void showResult(int[] result)
            {

                int sum = 0;
                //默认在第一个数字，即1之前是"+"号，方便编程而已  
                char operateChar = '+';
                String[] source = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                //最终的表达式，最好用StringBuilder，在非多线程的情况下，字符串拼接的性能，StringBuilder最好，  
                //当然用StringBuffer或者单纯的String也可以  
                StringBuilder expression = new StringBuilder();
                //用于记录临时的数字，因为参与运算的数字可能是几位的数字，所以也需要拼接  
                StringBuilder number = new StringBuilder();
                //先加入第一个字符，即1  
                number.Append(source[0]);

                expression.Append(source[0]);

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == 0)
                    {//如果为0，表示数字合并  
                        number.Append(source[i + 1]);
                        expression.Append(source[i + 1]);
                    }
                    else if (result[i] == 1)
                    {
                        sum = calc(operateChar, sum, number);
                        operateChar = '+';
                        number.Append(source[i + 1]);
                        expression.Append("+").Append(source[i + 1]);
                    }
                    else if (result[i] == 2)
                    {
                        sum = calc(operateChar, sum, number);
                        operateChar = '-';
                        number.Append(source[i + 1]);
                        expression.Append("-").Append(source[i + 1]);
                    }
                }
                sum = calc(operateChar, sum, number);
                if (sum == 100)
                {
                    Console.WriteLine(expression.ToString() + "=100");
                    Console.ReadLine();
                }
            }
            public static int calc(char operateChar, int sum, StringBuilder number)
            {
                if (operateChar == '+')
                {
                    sum += int.Parse(number.ToString());
                    number.Remove(0, number.Length);
                }
                else if (operateChar == '-')
                {
                    sum -= int.Parse(number.ToString());
                    number.Remove(0, number.Length);
                }
                return sum;
            }

        }
        public static void Main1()
        {
           // SecondMethod();
            int a = 5;
            Console.WriteLine(a * 3 / 2);
            Console.ReadLine();
        }
        /// <summary>
        /// 第二个实现方法，穷举，运行快，可读性差
        /// </summary>
        private static void SecondMethod()
        {
            List<int> number = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] Fuhao = { "+", "-", "" };

            for (int a = 0; a < Fuhao.Length; a++)
            {
                for (int b = 0; b < Fuhao.Length; b++)
                {
                    for (int c = 0; c < Fuhao.Length; c++)
                    {
                        for (int d = 0; d < Fuhao.Length; d++)
                        {
                            for (int e = 0; e < Fuhao.Length; e++)
                            {
                                for (int f = 0; f < Fuhao.Length; f++)
                                {
                                    for (int g = 0; g < Fuhao.Length; g++)
                                    {
                                        for (int h = 0; h < Fuhao.Length; h++)
                                        {
                                            StringBuilder builder = new StringBuilder();
                                            builder.Append(1 + Fuhao[a] + 2 + Fuhao[b] + 3 + Fuhao[c] + 4 + Fuhao[d] + 5 + Fuhao[e] + 6 + Fuhao[f] + 7 + Fuhao[g] + 8 + Fuhao[h] + 9);
                                            DataTable dt = new DataTable();
                                            var lll = dt.Compute(builder.ToString(), "");
                                            if (int.Parse(lll.ToString()) == 100)
                                                Console.WriteLine(builder);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("完成");
            Console.ReadLine();
        }

        #endregion

        #region  //算法练习：求以下表达式的值，写出您想到的一种或几种实现方法： 1-2+3-4+……+m
        public class Test01
    {
        public static void Main1(string[] s)
        {
            
            Console.WriteLine(Demo02(4));
            Console.ReadLine();
        }
        public static int Demo01(int A)
        {
            int sum = 0;
            for (int i = 1; i <= A; i++)
            {
                if (i % 2 == 1) //余2为1说明是偶数
                {
                    sum += i;
                }
                else
                    sum -= i;
            }
            return sum ;
        }

        public static int Demo02(int A)
        {
            bool flag = false;
            int sum = 0;
            //从1开始，i=0代表从0开始
            for (int i = 1; i < A; i++)
            {

                if (flag == false)
                    sum -= i;
                else
                    sum += i;
                flag = !flag;//每次变换符号的开关
            }
            return sum;
        }
 
    }
        #endregion

        #region//算法练习：求出1~100所有数相加的和
        public class Test02
    {
        public static void Main1(string[] A)
        {
            Console.WriteLine(Demo02());
            Console.ReadLine();
        }

        private static int Demo01()
        {
            int sum = 0;
            for (int i = 0; i <=100; i++)
            {
                sum+=i;
            }
            return sum;
        }

        private static int Demo02()
        {

            /*高斯求和
             * x=1+2+3+4+........+100
             x=100+99+98+97+........+1
             2x=101+101+101+.......+101
             2x=101*100
             x=(101*100)/2*/
            return (101 * 100)/2;
        }



    }
        #endregion

        #region //算法练习：冒泡排序
        public class Test03
    {
          

        private static void Main1(string[] A)
        {
            List<int> list = new List<int> {3,1,4,5,6,8,7,9,2 };
                int[] array = { 1, 5, 5, 9, 63, 4, 7, 8, 2 };
                // BubblingSort(list);
                Employee[] employees =
          {
       new Employee("Bugs Bunny", 20),
            new Employee("Elmer Fudd", 10),
           new Employee("Daffy Duck", 250),
             new Employee("Wile Coyote", 1000),
            new Employee("Foghorn Leghorn", 230),
          new Employee("RoadRunner", 50)
         };

                //注意，List的转换成array数组的时候，是复制一份，原来的List集合没有改变，所以需要找个值接一下然后进行遍历修改
               var ss= list.ToArray();
                OrderBy(ss, e =>e);
                foreach (var item in ss)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                
        }

            public static void BubblingSort(List<int> A)
        {
            for (int i = 0; i < A.Count-1; i++)
            {
                for (int j = i + 1; j <A.Count; j++)
                {
                    if(A[i]>A[j])
                    {
                        int index = A[i];
                        A[i] = A[j];
                        A[j] = index;
                    }
                }
            }
        }


            /// <summary>
            /// 泛型冒泡排序
            /// </summary>
            /// <typeparam name="T">方法参数</typeparam>
            /// <typeparam name="Tkey">返回值的类型</typeparam>
            /// <param name="array">泛型数组</param>
            /// <param name="condition">Func有返回值的委托</param>
            public static void OrderBy<T,key>(T[]array,Func<T,key>condition)where key:IComparable
        {
            for (int r = 0; r < array.Length; r++)
            {
                for (int c = r+1; c < array.Length; c++)
                {
                        //                                        >
                    if(condition(array[r]).CompareTo(condition(array[c]))>0)
                    {
                        T temp = array[r];
                        array[r] = array[c];
                        array[c] = temp;
                    }
                }
                
            }
        }


    }
        #endregion

        #region    //算法练习：快速排序
        public class Test04
    {
            public static void Main1(string[] A)
            {
                List<int> array = new List<int> { 1, 3, 2, 5, 7, 6, 4, 9, 8, 10 };
                QuickSore(array, 0, array.Count - 1);

                foreach (var item in array)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }

            private static void QuickSore(List<int> array, int begin, int end)
            {
                if (begin > end) return;
                int pivot = QuickSore_core(array, begin, end);
                QuickSore(array, begin, pivot - 1);
                QuickSore(array, pivot + 1, end);
            }

            private static int QuickSore_core(List<int> array, int begin, int end)
            {
                int i = begin;
                int j = end;
                int pivot = array[begin];
                while (i < j)
                {
                    while (i < j && array[j] >= pivot) j--;
                    array[i] = array[j];
                    while (i < j && array[i] <= pivot) i++;
                    array[j] = array[i];

                }
               array[i] = pivot ;
                return i;
            }
        }
        #endregion

        #region   //算法练习：取得两个数组的中位数， 中位数定义:把数组进行从小到大的排序，之后判断长度为偶数还是奇数，奇数的中位数就是中间的值，偶数的中位数就是中间两个值相加/2
        public class Test05
        {

            public static void Main1(string[] DSS)
            {
               List<int> A =new List<int> { 1, 4, 3 };
                List<int> B =new List<int> { 2, 5,6};
               float c= Medin(A, B);
                Console.WriteLine(c);
                Console.ReadLine();
            }

            private static float Medin(List<int> a, List<int> b)
            {
                float pivot = 0;

                a.AddRange(b);

                for (int i = 0; i < a.Count-1; i++)
                {
                    for (int j = i+1; j < a.Count; j++)
                    {
                        if(a[i]>a[j])
                        {
                            int item = a[i];
                            a[i] = a[j];
                            a[j] = item;
                        }
                    }
                }
                if (a.Count % 2 != 0)//奇数
                {
                    pivot = a[a.Count / 2];
                }
                else
                {
                    pivot = a[a.Count / 2]+a[a.Count/2-1];
                    pivot /= 2;
                }
                return pivot;
            }
        }
        #endregion

        #region //算法练习：给定两个整数，被除数dividend和除数divisor。将两数相除，要求不使用乘法、除法和mod运算符。返回被除数dividend除以除数divisor得到的商。
        /*
         Int8 //等于byte,
         Int16 //等于short, 占2个字节. -32768  ~ 32767
         Int32 //等于int, 占4个字节. -2147483648  ~  2147483647
         Int64  //等于long, 占8个字节. -9223372036854775808  ~  9223372036854775807
         */
        public class Test06
        {

            public static void Main1(string[] DSS)
            {
                int A = 5;
                int B = 2;
                int C= divide(A, B);
                Console.WriteLine(C);
                Console.ReadLine();
            }

            public static int divide(int A, int B)
            {
                //M是int32的最大数-2147483648，m是int32的最小数2147483647
                int M = (int)(Math.Pow(2, 31) - 1), m = -M - 1;
                // 溢出处理 
                if (B == 0 || (A == m && B == -1))
                {
                    return M;
                }
                // 确定符号 
                int sign = ((A > 0)|(B > 0)) ? -1 : 1;

                // 求绝对值，为防止溢出使用long，因为-2147483648 转正会超出范围
                long dvd = Math.Abs((long)A);
                long dvs = Math.Abs((long)B);
                // 记录结果
                int result = 0;

                // 被除数大于除数
                while (dvd >= dvs)
                {
                    // 记录除数
                    long tmp = dvs;
                    // 记录商的大小
                    long mul = 1;
                    while (dvd >= (tmp << 1))//被除数大于或等于除数左移一位时（*2），将tmp和mul同时左移（*2）
                    {
                        tmp <<= 1;
                        mul <<= 1;
                    }
                    // 减去最接近dvd的dvs的指数倍的值（值为tmp）
                    dvd -= tmp;
                    // 修正结果
                    result += (int)mul;
                }
                if (sign.ToString().IndexOf("-") == 0)
                    result = -result;
                return result;
               // return result * sign;
            }
        }
        #endregion

        #region    //算法练习：找出无序数组中的最长连续序列的长度：例如数组[1, 23, 2, 300, 3, 9, 4, 5, 90]，最长连续序列为：1，2，3，4，5，因此返回长度为 5。
        public class Test07
        {
            public static void Main1()
            {
                int[] A = {-1,-2,-3,-4,-5,1 };

                int B=ReturnLength(A);
                Console.WriteLine(B);
                Console.ReadLine();

            }

            private static int ReturnLength(int[] a)
            {
                int b = 1;
                int J = 0;
                Array.Sort(a);
                for (int i = 0; i < a.Length-1; i++)
                {
                    if (Math.Abs(a[i]) + 1 ==Math.Abs(a[i + 1])|| Math.Abs(a[i]) - 1 == Math.Abs(a[i + 1]))
                        b++;
                    else
                    {
                        if(b>J)
                        J = b;

                        b = 1;
                    }
                }
                return J>b?J:b;
            }
        }
        #endregion

        #region//算法练习：给定一个非负整数数组，您最初定位在数组的第一个索引处。 数组中的每个元素表示该位置的最大跳转长度。您的目标是以最小跳跃次数到达最后一个索引。
        /*例：
         * 输入： [2,3,1,1,4]输出： 2
         * 说明：到达最后一个索引的最小跳转次数为2。 
         * 从索引0跳转1步到1，然后从最后一个索引跳3步。
         * 注意：您可以假设您始终可以访问最后一个索引。
        */
        public static void Main()
        {
            int[] A = {1,2,1,0,3};
            int C=Skip(A);
            Console.WriteLine(C);
            Console.ReadLine();
        }

        private static int Skip(int[] nums)
        {
            //数组长度小于2返回0
            if (nums.Length < 2) return 0;
            int begin = 0, end = 0;
            int step = 0;
            while (true)
            {
                int max = 0;

                for (int i = begin; i <= end; i++) 
                    max = Math.Max(nums[i] + i, max);//取得最大长度

                if (max <= end) return 0;//这说明第一个索引元素是0，那么我们无法进行跳转，之间return 0；
                if (max >= nums.Length - 1) return step + 1;//当我们最大数大于数组长度-1时，说明到达最后一位，参数记录加1结束
                begin = end + 1;//跳转后到达的位置
                end = max;//将最大的长度给end
                step++;//记录参数
            }
            //数组[2,3,1,1,4]
            //当我们第一次循环 nums[i]的参数是2加上索引0，max是0，因此max得到值为2，对比一下max小于数组长度5-1
            //因此，我们继续进行移动，起始的位置改变位最终位置+1，这样就是下一个位置的元素也就是3
            //把最大数记录一下，并赋值给最终位置。
        }




        #endregion

    }
}
