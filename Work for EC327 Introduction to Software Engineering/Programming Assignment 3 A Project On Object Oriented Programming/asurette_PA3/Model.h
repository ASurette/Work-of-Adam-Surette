#ifndef MODEL_H
#define MODEL_H
#include "GameObject.h"
#include "Port.h"
#include "Dock.h"
#include "Sailor.h"
#include "View.h"

class Model
{

 private:

  int time;

  GameObject** object_ptrs;

  int num_objects;

  Sailor** sailor_ptrs;

  int num_sailors;

  Dock** dock_ptrs;

  int num_docks;

  Port** port_ptrs;

  int num_ports;

 public:

  Model();

  ~Model();

  Sailor* get_Sailor_ptr(int);

  Port* get_Port_ptr(int);

  Dock* get_Dock_ptr(int);

  bool update();

  void display(View&);

  void show_status();

};

#endif
