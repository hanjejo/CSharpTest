using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest2
{

    delegate void MyDelegate(int luckynumber, int input);

    class Company
    {
        int luckynumber;

        public event MyDelegate MyEvent;

        public Company()
        {
            Random random = new Random();
            luckynumber = random.Next(1, 5);
        }

        public void Raffling()
        {
            Console.WriteLine("행운의 숫자를 입력하세요!");
            int input = int.Parse(Console.ReadLine());

            MyEvent(luckynumber, input);
        }
    }


    class Program
    {

        static public void Okay(int luckynumber, int input)
        {
            if (luckynumber == input)
                Console.WriteLine("경! 당첨 !축 : " + luckynumber);
        }

        static public void NotOkay(int luckynumber, int input)
        {
            if (luckynumber != input)
                Console.WriteLine("꽝 : " + input);
        }

        static void Main(string[] args)
        {
            Company company = new Company();
            company.MyEvent += new MyDelegate(Okay);
            company.MyEvent += new MyDelegate(NotOkay);

            company.Raffling();

            Console.ReadLine();
        }
    }
}
