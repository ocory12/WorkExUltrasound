#include <NewPing.h>

#define MAX_DIST 200

#define TRIGGER_FRONT 2
#define ECHO_FRONT 3
#define TRIGGER_REAR 4
#define ECHO_REAR 5
#define TRIGGER_LEFT 6
#define ECHO_LEFT 7
#define TRIGGER_RIGHT 8
#define ECHO_RIGHT 9
#define TRIGGER_TOP 10
#define ECHO_TOP 11

NewPing sensFront(TRIGGER_FRONT,ECHO_FRONT,MAX_DIST);
NewPing sensRear(TRIGGER_REAR,ECHO_REAR,MAX_DIST);
NewPing sensLeft(TRIGGER_LEFT,ECHO_LEFT,MAX_DIST);
NewPing sensRight(TRIGGER_RIGHT,ECHO_RIGHT,MAX_DIST);
NewPing sensTop(TRIGGER_TOP,ECHO_TOP,MAX_DIST); 

void setup() {
  Serial.begin(9600);
  
}

void loop() {
  delay(50);
  Serial.println("sf ");  //where sf is sensor front
  Serial.print(sensFront.ping_cm());
  Serial.println("sr ");  //where sr is sensor rear
  Serial.print(sensRear.ping_cm());
  Serial.println("sl ");  //where sl is sensor left
  Serial.print(sensLeft.ping_cm());
  Serial.println("sr ");  //where sr is sensor right
  Serial.print(sensRight.ping_cm());
  Serial.println("st ");  //where st is sensor top
  Serial.print(sensTop.ping_cm());
}
