#ifndef PIRATE_H
#define PIRATE_H
#include "Sailor.h"
#include <cstdlib>

class Pirate : public Sailor
{
 private:

  int attack_strength;

  double range;

  Sailor* target;

 public:
  Pirate(Model*);

  Pirate(int, Model*);

  double get_speed();

  void start_plunder(Sailor*);

  bool update();

  bool start_recruiting(Sailor*);

  void show_status();

  void set_as(int);//set attack strength

};



#endif
