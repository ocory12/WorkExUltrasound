# WorkExUltrasound
UGV Ultrasound project as a part of my work experience 

The following commands should allow serial data to be written to and read from on linux devices:

sudoedit /etc/udev/rules.d/50-myusb.rules

Save the following text in the file (use "ctrl + x", "y" and then "enter" to save file if using nano):

KERNEL=="ttyUSB[0-9]*",MODE="0666"

KERNEL=="ttyACM[0-9]*",MODE="0666"


