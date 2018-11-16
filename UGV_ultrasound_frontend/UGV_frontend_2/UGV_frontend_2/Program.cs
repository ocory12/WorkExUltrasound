using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace UGV_frontend_2
{
   // class Data
   // {
   //     public int serialFront;
   //     public int serialBack;
   //     public int serialLeft;
   //     public int serialRight;
   //     public int serialTop;
   //     public Data( int SerialFront, int SerialBack, int SerialLeft, int SerialRight, int SerialTop)
   //     {
   //       serialFront = SerialFront;
   //       serialBack = SerialBacl;
   //       serialLeft = SerialLeft;
   //       serialRight = SerialRight;
   //       serialTop = SerialTop;
   //     }
   // }
    class Program
    {
        static void Main()
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

                Console.WriteLine("Front: {0}, Back: {1}, Left: {2}, Right: {3}, Top: {4}", sf, sb, sl, sr, st);
            }



            // Data serialTest = new Data(sf, sb, sl, sr, st);

            // Console.WriteLine("Front: {0}, Back: {1}, Left: {2}, Right: {3}, Top: {4}", serialTest.serialFront, serialTest.serialBack, serialTest.serialLeft, serialTest.serialRight, serialTest.serialTop);
        }
    }
}
