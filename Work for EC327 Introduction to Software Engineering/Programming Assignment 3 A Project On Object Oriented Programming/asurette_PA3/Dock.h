#ifndef DOCK_H
#define DOCK_H
#include "GameObject.h"
#include "Sailor.h"
class Sailor;
class Dock:public GameObject
{
 private:

  double berths;

 public:

  Dock();

  Dock(int, CartPoint);

  bool dock_boat(Sailor*);

  bool set_sail(Sailor*);

  bool update();

  void show_status();

  ~Dock();
};

#endif
