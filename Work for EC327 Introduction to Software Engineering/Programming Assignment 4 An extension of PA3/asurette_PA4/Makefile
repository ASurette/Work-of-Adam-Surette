# in EC327, we use the ${GCC} compiler
# therefore, we define the GCC variable
GCC = g++ -g 


HighCs: PA4.o GameObject.o Sailor.o Dock.o Port.o CartPoint.o CartVector.o Model.o View.o GameCommand.o Merchant.o Pirate.o Kraken.o
	${GCC} PA4.o GameObject.o Sailor.o Dock.o Port.o CartPoint.o CartVector.o Model.o View.o GameCommand.o Merchant.o Pirate.o Kraken.o -o HighCs

PA4.o: PA4.cpp
	${GCC} -c PA4.cpp

GameObject.o: GameObject.cpp
	${GCC} -c GameObject.cpp

Sailor.o: Sailor.cpp
	${GCC} -c Sailor.cpp

Dock.o: Dock.cpp
	${GCC} -c Dock.cpp

Port.o: Port.cpp
	${GCC} -c Port.cpp

CartPoint.o: CartPoint.cpp
	${GCC} -c CartPoint.cpp

CartVector.o: CartVector.cpp
	${GCC} -c CartVector.cpp

Model.o: Model.cpp
	${GCC} -c Model.cpp

View.o: View.cpp
	${GCC} -c View.cpp

GameCommand.o: GameCommand.cpp
	${GCC} -c GameCommand.cpp

Merchant.o: Merchant.cpp
	${GCC} -c Merchant.cpp

Pirate.o: Pirate.cpp
	${GCC} -c Pirate.cpp

Kraken.o: Kraken.cpp
	${GCC} -c Kraken.cpp

clean:
	rm PA4.o GameObject.o Sailor.o Dock.o Port.o CartPoint.o CartVector.o Model.o View.o GameCommand.o  Merchant.o Pirate.o Kraken.o HighCs  
