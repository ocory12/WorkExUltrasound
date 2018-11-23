using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UGV_frontend_2
{

    class Program
    {



        static void Main()
        {

            ThreadStart newThread = new ThreadStart(DataCollection);
            Thread thread = new Thread(newThread);
            thread.Start();



            // Console.WriteLine("Front: {0}, Back: {1}, Left: {2}, Right: {3}, Top: {4}", dataToMain.sf, dataToMain.sb, dataToMain.sl, dataToMain.sr, dataToMain.st  );

        }

        static void DataCollection()
        { 
            SerialPort serialArduino = new SerialPort();
            serialArduino.PortName = "COM3";
            serialArduino.BaudRate = 9600;
            serialArduino.Open();

            public int sf;
            public int sb;
            public int sl;
            public int sr;
            public int st;
            
            while(true)
            {
                string[] splitData = serialArduino.ReadLine().Split(':');


                int SF = Int32.Parse(splitData[0]);
                int SB = Int32.Parse(splitData[1]);
                int SL = Int32.Parse(splitData[2]);
                int SR = Int32.Parse(splitData[3]);
                int ST = Int32.Parse(splitData[4]);

            

                //Console.WriteLine("Front: {0}, Back: {1}, Left: {2}, Right: {3}, Top: {4}", SF,SB,SL,SR,ST);
           }

    }

