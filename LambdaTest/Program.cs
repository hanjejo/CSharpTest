using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTest
{
    class Program
    {

        delegate int Mydelegate(int a, int b);
        delegate void Mydelegate2(int a, int b);


        static void Main(string[] args)
        {

            //delegate 
            //람다식 사용 안한 경우
            Mydelegate cal = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(cal(1, 2));


            //람다식 사용
            Mydelegate cal2 = (a, b) => a + b;
            Console.WriteLine(cal2(1, 2));


            //문 형식 람다식
            Mydelegate2 Compare = (a, b) =>
            {
                if (a > b)
                    Console.WriteLine("{0}보다 {1}가 크다", b, a);
                else if (a > b)
                    Console.WriteLine("{0}보다 {1}가 크다", a, b);
                else
                    Console.WriteLine("{0}, {1}는 같다", a, b);
            };
            Compare(3, 4);

            //Action
            Action<int> act = (int a) => Console.WriteLine(a);

            //Func
            Func<int, int> func = (int a) => a * 2;
            Console.WriteLine(func(4));

            Console.ReadLine();
        }
    }
}
