﻿using System;
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
        
        public static int SF;
        public static int SB;
        public static int SL;
        public static int SR;
        public static int ST;
        public static bool B;
        public static object LockObject = new object();
    }

    public class UGV_GUI : Form
    {
        public UGV_GUI()
        {
            
            InitializeComponent();
        }
        void InitializeComponent()
        {
            // Thread t = new Thread(UGV_Paint);
            // t.Start();
            // 
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

            
            while(true)
            { 
                lock (GlobalVars.LockObject)
                {
                    sensFront = GlobalVars.SF;
                    sensBack = GlobalVars.SB;
                    sensLeft = GlobalVars.SL;
                    sensRight = GlobalVars.SR;
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

                Thread.Sleep(200);
                
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
       
            /*ThreadStart DrawingThread = new ThreadStart(DrawingData);
            Thread thread2 = new Thread(DrawingThread);
            thread2.Start(); */
               
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


                lock (GlobalVars.LockObject)
                {
                    GlobalVars.SF = sf;
                    GlobalVars.SB = sb;
                    GlobalVars.SL = sl;
                    GlobalVars.SR = sr;
                    GlobalVars.ST = st;

                }

                /*
                if (sf <= 10 | sb <= 10 | sl <= 10 | sr <= 10 | st <= 10) 
                {
                    GlobalVars.B = true;
                }
                else
                {
                    GlobalVars.B = false;
                }
                */
                Thread.Sleep(100);

            }
            
            
        }
    }
}
