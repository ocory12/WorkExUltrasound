using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UGV_frontend_GUI
{
    public class UGV_GUI : Form
    {
        public UGV_GUI()
        {
            InitializeComponent();
        }
        void InitializeComponent()
        {
            Paint += new PaintEventHandler(UGV_Paint);
        }
        private void UGV_Paint(object sender, PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, 3.00F);
            Rectangle rectFront = new Rectangle(130,20, 250,50);
            Rectangle rectBack = new Rectangle(130,340, 250,50);
            Rectangle rectLeft = new Rectangle(130, 80, 50,250);
            Rectangle rectRight = new Rectangle(330,80, 50,250);
            e.Graphics.DrawRectangle(redPen, rectFront);
            e.Graphics.DrawRectangle(redPen, rectBack);
            e.Graphics.DrawRectangle(redPen, rectLeft);
            e.Graphics.DrawRectangle(redPen, rectRight);

           
        }
    }

    public class Program
    {
        public static void Main()
        {
            ThreadStart newThread = new ThreadStart(DataCollection);
            Thread thread = new Thread(newThread);
            thread.Start();

            Application.Run(new UGV_GUI());
                 
        }

        public static void DataCollection()
        {
            SerialPort serialArduino = new SerialPort();
            serialArduino.PortName = "COM3";
            serialArduino.BaudRate = 9600;
            serialArduino.Open();

            

            while (true)
            {


                string[] splitData = serialArduino.ReadLine().Split(':');

                int sf = Int32.Parse(splitData[0]);
                int sb = Int32.Parse(splitData[1]);
                int sl = Int32.Parse(splitData[2]);
                int sr = Int32.Parse(splitData[3]);
                int st = Int32.Parse(splitData[4]);

                
               
            }
            
        }
    }
}
