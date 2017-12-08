#ifndef SAILOR_H
#define SAILOR_H
#include "GameObject.h"
#include "Port.h"
#include "Dock.h"

class Model;
class Dock;
class Sailor : public GameObject
{
 protected:

   Model* world;

 private:

  double health;

  double size;

  double hold;

  double cargo;

  CartPoint destination;

  CartVector delta;

  Port* port;

  Dock* dock;

  bool update_location();

  void setup_destination(CartPoint);

 public:
  double docksize;

  Dock* hideout;

  Sailor(char, int, CartPoint, Model*);//for pirates

  Sailor(char, Model*);//default

  Sailor(char,int, Dock*, Model*);//normal

  virtual bool update();

  double get_size();

  double get_health();

  void set_size(double);

  void set_health(double);

  double get_cargo();

  void start_sailing(CartPoint);

  void start_supplying(Port*);

  void start_hiding();

  bool is_hidden();

  void start_docking(Dock*);

  void anchor();

  void show_status();

  //the new functions added in PA4

  virtual double get_speed() = 0;

  virtual void start_plunder(Sailor*);

  virtual bool start_recruiting(Sailor*);

  void get_plundered(int);

  ~Sailor();

  bool is_alive();

  Dock* get_hideout();

  void add_health(double);

  bool safe;

};

#endif
