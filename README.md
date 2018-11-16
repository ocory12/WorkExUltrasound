# WorkExUltrasound
UGV Ultrasound project as a part of my work experience 

The following commands should allow serial data to be written to and read from an written to on linux devices:

sudoedit /etc/udev/rules.d/50-myusb.rules

Save this text in the file:

KERNEL=="ttyUSB[0-9]*",MODE="0666"

KERNEL=="ttyACM[0-9]*",MODE="0666"
