using System.IO;
using System;
using  System.IO.Ports;

class Program
{
    public static Main()
    {
        
        SerialPort serialArduino = new SerialPort();
        serialArduino.PortName = "COM3";
        serialArduino.BaudRate = 9600;
        serialArduino.open();
        
        while (True) {
            string arduinoSerialData = serialArduino.ReadExisting();
            Console.WriteLine(arduinoSerialData);
        }
    }
}
