using System;

class Data {
  public int serialLeft;
  public int serialRight;
  public int serialFront;
  public int serialBack;
  public int serialTop;

  public Data( int SerialLeft, int SerialRight, int SerialFront, int SerialBack, int SerialTop){

    serialLeft = SerialLeft;
    serialRight = SerialRight;
    serialFront = SerialFront;
    serialBack = SerialBack;
    serialTop = SerialTop;
  }
}
class MainClass {

  public static Main() {
    Data serialTest = new Data(1,3,4,5,6);

    Console.WriteLine("Left: {0}, Right: {1}, Front: {2}, Back: {3}, Top: {4}", Data.serialLeft, Data.serialRight, Data.serialFront, Data.serialBack, Data.serialTop);


  }
}
