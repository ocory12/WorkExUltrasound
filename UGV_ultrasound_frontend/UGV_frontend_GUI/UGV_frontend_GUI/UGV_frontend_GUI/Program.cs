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
    public class GlobalVars
    {
        object GlobalObject = new object();
        public int SF;
        public int SB;
        public int SL;
        public int SR;
        public int ST;

    }

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
        public void UGV_Paint(object sender, PaintEventArgs e)
        {
            Pen redPen = new Pen(Color.Red, 3.00F);
            Rectangle rectFront = new Rectangle(130, 20, 250, 50);
            Rectangle rectBack = new Rectangle(130, 340, 250, 50);
            Rectangle rectLeft = new Rectangle(130, 80, 50, 250);
            Rectangle rectRight = new Rectangle(330, 80, 50, 250);
            e.Graphics.DrawRectangle(redPen, rectFront);
            e.Graphics.DrawRectangle(redPen, rectBack);
            e.Graphics.DrawRectangle(redPen, rectLeft);
            e.Graphics.DrawRectangle(redPen, rectRight);

            System.Drawing.SolidBrush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.SolidBrush clearBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Empty);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();

            Random randomNum = new Random();

            int sensFront = 0; 
            int sensBack =0;
            int sensLeft = 0;
            int sensRight = 0;
            int sensTop = 0;

            while (true)
            {
                lock (GlobalVars.SF)
                {
                    sensFront = GlobalVars.SF;
                }
                lock (GlobalVars.SB)
                {
                    sensBack = GlobalVars.SB;
                }
                lock (GlobalVars.SL)
                {
                    sensLeft = GlobalVars.SL;
                }
                lock (GlobalVars.SR)
                {
                    sensRight = GlobalVars.SR;
                }

                lock (GlobalVars.ST)
                {
                    sensTop = GlobalVars.ST;
                }


                if (sensFront <= 10)
                {
                    formGraphics.FillRectangle(redBrush, rectFront);
                }
                else
                {
                    formGraphics.FillRectangle(clearBrush, rectFront);
                }

                if (sensBack <= 10)
                {
                    formGraphics.FillRectangle(redBrush, rectBack);
                }
                else
                {
                    formGraphics.FillRectangle(clearBrush, rectBack);
                }

                if (sensLeft <= 10)
                {
                    formGraphics.FillRectangle(redBrush, rectLeft);
                }
                else
                {
                    formGraphics.FillRectangle(clearBrush, rectLeft);
                }

                if (sensRight <= 10)
                {
                    formGraphics.FillRectangle(redBrush, rectRight);
                }
                else
                {
                    formGraphics.FillRectangle(clearBrush, rectRight);
                }

                Thread.Sleep(100);
            }

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

                lock (GlobalVars.SF)
                {
                    GlobalVars.SF = sf;
                }
                lock (GlobalVars.SB)
                {
                    GlobalVars.SB = sb;
                }
                lock (GlobalVars.SL)
                {
                    GlobalVars.SL = sl;
                }
                lock (GlobalVars.SR)
                {
                    GlobalVars.SR = sr;
                }
                lock (GlobalVars.ST)
                {
                    GlobalVars.ST = st;
                }
               
                Thread.Sleep(100);

            }


            
            
        }
    }
}
