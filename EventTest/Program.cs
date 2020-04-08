using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Event 사용시 장점
            // 외부코드를 Event 구동시점에 특정 작업을 등록할 수 있습니다. (펑션 외부 호출 가능)

            // Basic
            Sample1();

            // Expansion Case 1
            Sample2();
        }

        private static void Sample1()
        {
            var btn = new EventTestButton();
            btn.Click += new EventHandler(NewMethod);

            // 해당 메서드 호출시 Click Event에 등록된 NewMethod 호출됨
            // 반환값과 파라미터만 맞다면 어떤메소드든 추가 가능 (C#에서 콜백 등록)
            btn.MouseButtonDown();
        }

        static void NewMethod(object sender, EventArgs e)
        {
            //외부 코드 추가
        }

        private static void Sample2()
        {
            var btn = new EventTestButton();
            var ext1 = new ExternalClass();
            
            btn.Click += new EventHandler(ext1.ExternalMethod);

            // 2개이상 추가도 가능
            //var ext2 = new ExternalClass();
            //btn.Click += new EventHandler(ext2.ExternalMethod);


            // 외부클래스에 등록된 ExternalMethod 들이 호출됨
            btn.MouseButtonDown();
        }
    }
}
