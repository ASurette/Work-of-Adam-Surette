#ifndef MERCHANT_H
#define MERCHANT_H
#include "Sailor.h"

class Merchant : public Sailor
{
 public:
  Merchant(Model*);

  Merchant(int, Dock*, Model*);

  Merchant* partner;

  bool start_recruiting(Merchant*);

  void start_plunder(Sailor*);

  double get_speed();//redefined becuase it is a virtual function

  bool update();

  void show_status();

  int tick;
};

#endif





