using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwaitTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Run1();

            Run2();
        }

        async void Run1()
        {
            int sum = await LasyCalc(10);

            label1.Content = "Sum1 = " + sum;
            button1.IsEnabled = true;
        }

        async Task<int> LasyCalc(int times)
        {
            //UI Thread에서 실행
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result += i;
                await Task.Delay(100);
            }
            return result;
        }

        private void Run2()
        {
            var task1 = Task.Run(() => LasyCalc(10));

            // Run1과 동일한 기능을하는 코드
            //
            task1.ContinueWith(x => {
                this.label2.Content = "Sum2 = " + task1.Result;
                this.button1.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
