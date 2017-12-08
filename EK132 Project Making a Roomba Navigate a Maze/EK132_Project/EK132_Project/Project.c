//AVR Microcontroller libraries. Like stdio.h or conio.h but specific to the 
//type of microcontroller inside the iRobot
#include <avr/io.h>
#include <avr/interrupt.h>
/*********************
* Function Prototypes
/********************/
void setupSerial(void);
void setupTimer(void);
void byteTx(uint8_t);
void turn90(void);
void turn180(void);
void delayMs(uint16_t);
void clearReceiveBuffer(void);
uint8_t byteRx(void);
void drivebump(void);
void driveback(void);
int timer=0;
int event=0;
/**********************
* Variable Declarations
/*********************/
volatile uint16_t timerCount = 0;
volatile uint8_t timerRunning = 0;


int main(void){
	/**************************
	* Run intialization methods.
	/**************************/
	int state=0;
	int x=0;
	cli();
	//Properly set serial pins.
	setupSerial();
	//Create the 1 microsecond interrupt.
	setupTimer();
	sei();
	//Your code goes here!
	//Turn on and Full Mode
	byteTx(128);
	byteTx(132);
	x=0;
	delayMs(1000);
	drivebump();
	while(x==0){	
		event=byteRx();
		nomove();
		driveback();
		if(timer>4000){
			state=1;
			nomove();
			turn90();
			timer=0;
			drivebump();
		}
		else{
			if (state==1){
			state=2;
			turn180();//Turning 180 Degrees left
			timer=0;
			drivebump();
			}
			else{
			//STOP!!!
			nomove();
			x=1;
			}
		}
	
	}
}

//Any methods you want to write can go here!

/*****************************
*READ ABOUT THESE FUNCTIONS!!!
/****************************/

//This is a one millisecond interrupt function. That means that
//every 1ms, this method gets called by the program, regardless of what
//else is happening. This makes it ideal for timing functions.
//In fact, it is already configured to work properly as a delay timer.
//The DelayMS function utilizes this function to decrease timerRunning once
//every millisecond. Once timerRunning reaches 0, the delayMS function quits 
//and the program resumes.
SIGNAL(SIG_OUTPUT_COMPARE1A) {	\
	if(timerRunning) {
		if(timerCount != 0) {
			timerCount--;
		} else {
				timerRunning = 0;
			}
	}
timer++;
}
//This is the function for sending data, one byte at a time,
//to the iRobot. It waits until the transmission lines are clear
//and then transmits the byte, value, to the robot.
//So if you wanted to send the number 128 to the iRobot, you would use
//byteTx(128).
void byteTx(uint8_t value) {
	// Transmit one byte to the robot.
	// Wait for the buffer to be empty.
	while(!(UCSR0A & 0x20)) {
	// Do nothing.
	}
	// Send the byte.
	UDR0 = value;
}
//This clears old data out of the input registers.
//Without calling this method before attempting to read in input the
//iRobot will behave very differently than expected. USE THIS BEFORE REQUESTING
//EVERY BYTE OF DATA!!
void clearReceiveBuffer(){
	uint8_t empty; //Buffer drain.
	while(UCSR0A & 0x80) {/* waits for the buffer to empty */
		empty = UDR0;
	}
	
}
//This is the counterpart to byteTx(uint8_t). Where byteTx
//sends a byte, byteRx receives a byte.
//It is important to realize that byteRx will wait until there
//is a byte to receive before doing anything. As a result,
//if you use byteRx, your program will pause until it is sent
//a byte from the iRobot.
uint8_t byteRx(void){	
	while(!(UCSR0A & 0x80)) ;
	/* wait until a byte is received */
	return UDR0;
}
/*****************************************************
*	Initialization Code. (dont worry about this stuff)
/****************************************************/
void setupTimer(void) {
	// Set up the timer 1 interupt to be called every 1ms.
	TCCR1A = 0x00;
	TCCR1B = 0x0C;
	OCR1A = 71;
	TIMSK1 = 0x02;
}
void delayMs(uint16_t timeMs) {
	timerCount = timeMs;
	timerRunning = 1;
	//timerCount gets decremented every 1ms by the 
	//interrupt function above. Once the interrupt determines
	//that timerCount has been reduced to 0, it sets timerRunning
	//to 0, which will terminate the following while loop.
	while(timerRunning) {
	// do nothing
	}
}

void setupSerial(void) {
	// Set the transmission speed to 57600 baud, which is what the Create expects,
	// unless we tell it otherwise.
	UBRR0 = 19;
	// Enable both transmit and receive.
	UCSR0B = 0x18;
	// Set 8-bit data.
	UCSR0C = 0x06;
}
void turn180() {
	byteTx(137); //Turning
	byteTx(0);
	byteTx(128);
	byteTx(0);
	byteTx(0);
	delayMs(3070);
	byteTx(137); //Driving nowhere
	byteTx(0);
	byteTx(0);
	byteTx(0);
	byteTx(0);
}
void turn90(){
	byteTx(137); //Turning
	byteTx(0);
	byteTx(128);
	byteTx(0);
	byteTx(0);
	delayMs(1570);
	byteTx(137); //Driving nowhere
	byteTx(0);
	byteTx(0);
	byteTx(0);
	byteTx(0);
	}
void drivebump(){
	byteTx(152);
	byteTx(9);
	byteTx(137); //Driving forward
	byteTx(0);
	byteTx(128);
	byteTx(127);
	byteTx(255);
	byteTx(158); //Look for bump
	byteTx(5);
	byteTx(142);//Bump Sensor
	byteTx(7);
	byteTx(153);
	}
void driveback(){
	byteTx(137);//drive backwards
	byteTx(255);
	byteTx(206);
	byteTx(127);
	byteTx(255);
	delayMs(1000);
	}
void nomove(){
byteTx(137);
byteTx(0);
byteTx(0);
byteTx(0);
byteTx(0);
}