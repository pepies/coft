using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void start_Click(object sender, EventArgs e)
        {
            start_one_car();

        }
        private void startDva_Click(object sender, EventArgs e)
        {
            start_dva_car();
        }

        private async void start_one_car()
        {
            novy(0);
            await Task.Delay(1000);
            novy(1000);
            await Task.Delay(1000);
            novy(2000);
            await Task.Delay(1000);
            novy(3000);
            await Task.Delay(1000);
            novy(3500);
            await Task.Delay(1000);
            novy(3500);
            await Task.Delay(1000);
            novy(3300);
            await Task.Delay(1000);
            novy(3300);
            await Task.Delay(1000);
            novy(3300);
            await Task.Delay(1000);
            novy(3300);
            await Task.Delay(1000);
            novy(3000);
            await Task.Delay(1000);
            novy(2000);
            await Task.Delay(1000);
            novy(1000);
            await Task.Delay(1000);
            novy(550);
            await Task.Delay(1000);
            novy(30);
            await Task.Delay(1000);
            novy(11);
            await Task.Delay(1000);
            novy(10);
            await Task.Delay(1000);
            novy(9);
            await Task.Delay(1000);
            novy(8);
            await Task.Delay(1000);
            novy(-7);
            await Task.Delay(1000);
            novy(5);
            await Task.Delay(1000);
            novy(4);
            await Task.Delay(1000);
            novy(3);
            await Task.Delay(1000);
            novy(2);
            await Task.Delay(1000);
            novy(1);

        }
        private async void start_dva_car()
        {
            novy(0);
            await Task.Delay(1000);
            novy(1001);
            await Task.Delay(1000);
            novy(2001);
            await Task.Delay(1000);
            novy(3001);
            await Task.Delay(1000);
            novy(3501);
            await Task.Delay(1000);
            novy(3501);
            await Task.Delay(1000);
            novy(3301);
            await Task.Delay(1000);
            novy(3302);
            await Task.Delay(1000);
            novy(3303);
            await Task.Delay(1000);
            novy(3304);
            await Task.Delay(1000);
            novy(3001);
            await Task.Delay(1000);
            novy(2001);
            await Task.Delay(1000);
            novy(1001);
            await Task.Delay(1000);
            novy(1202);
            await Task.Delay(1000);
            novy(4001);
            await Task.Delay(1000);
            novy(7001);
            await Task.Delay(1000);
            novy(10001);
            await Task.Delay(1000);
            novy(11001);
            await Task.Delay(1000);
            novy(11001);
            await Task.Delay(1000);
            novy(10800);
            await Task.Delay(1000);
            novy(10801);
            await Task.Delay(1000);
            novy(10802);
            await Task.Delay(1000);
            novy(6000);
            await Task.Delay(1000);
            novy(3000);
            await Task.Delay(1000);
            novy(11);
            await Task.Delay(1000);
            novy(10);
            await Task.Delay(1000);
            novy(9);
            await Task.Delay(1000);
            novy(8);
            await Task.Delay(1000);
            novy(7);
            await Task.Delay(1000);
            novy(-5);
            await Task.Delay(1000);
            novy(4);
            await Task.Delay(1000);
            novy(3);
            await Task.Delay(1000);
            novy(2);
            await Task.Delay(1000);
            novy(1);

        }
         private async void kratky_test()
        {
            novy(0);
            await Task.Delay(1000);
            novy(200);
            await Task.Delay(1000);
            novy(666);
            await Task.Delay(1000);
            novy(7000);
            await Task.Delay(1000);
            novy(6000);
            await Task.Delay(1000);
            novy(10);
            await Task.Delay(1000);
            novy(9);
            await Task.Delay(1000);
            novy(8);
            await Task.Delay(1000);
            novy(7);
            await Task.Delay(1000);
            novy(5);
            await Task.Delay(1000);
            novy(4);
            await Task.Delay(1000);
            novy(3);
            await Task.Delay(1000);
            novy(2);
            await Task.Delay(1000);
            novy(1);
        }
        private void novy(int vaha)
        {
            String date = DateTime.Now.ToString("MM'/'dd'/'yy;hh:mm:ss");
            System.IO.File.AppendAllText(@"C:\vt_log\kontrol.txt", "001;" + date + ";"+ vaha +"\r\n");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kratky_test();
        }
    }
}
