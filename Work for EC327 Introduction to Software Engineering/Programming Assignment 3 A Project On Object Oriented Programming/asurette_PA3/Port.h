#ifndef PORT_H
#define PORT_H

#include "GameObject.h"
class Port:public GameObject
{
 private:

  double inventory;

 public:

  Port();

  Port(int, CartPoint);

  bool is_empty();

  double provide_supplies(double = 50.0);

  bool update();

  void show_status();

  ~Port();

};

#endif
