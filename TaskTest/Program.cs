using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 생성과 동시에 시작
            TaskTest1();

            // 생성 후 Start를 통해서 시작 Int Type
            TaskTest2();

            // 생성 후 Start를 통해서 시작 String Type
            TaskTest3();
        }

        static void TaskTest1()
        {
            // Task 생성 및 동시시작
            var task = Task.Factory.StartNew(() =>
            {
                // 코드 작성 구간
                return TestIntMethod();
            });

            // 결과값 45	
            Console.WriteLine(task.Result);
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
        }

        static void TaskTest2()
        {
            // Task 생성 // return을 받는 방식 int Type
            Task<int> task = new Task<int>(() => 
            {
                return TestIntMethod();
            });

            // Task 시작
            task.Start();

            // Task 종료시까지 대기
            task.Wait();

            // Task 종료 후 수행작업
            task.ContinueWith((t) =>
            {
                // Task 종료 후 수행할 코드
            });
        }

        static void TaskTest3()
        {
            // Task 생성 // return을 받는 방식 string Type
            Task<string> task = new Task<string>(() =>
            {
                return TestStringMethod();
            });

            // Task 시작
            task.Start();

            // Task 종료시까지 대기
            task.Wait();

            // Task 종료 후 수행작업
            task.ContinueWith((t) =>
            {
                // Task 종료 후 수행할 코드
                Console.WriteLine(task.Result);
            });

            task.Wait();
        }

        static int TestIntMethod()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i;
                // 0.1초 단위로 1씩 증가
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
            return sum;
        }

        static string TestStringMethod()
        {
            string sum = "";
            for (int i = 0; i < 10; i++)
            {
                sum += i.ToString() + " ";
                // 0.1초 단위로 1씩 증가
                Thread.Sleep(100);
            }
            return sum;
        }
    }
}
