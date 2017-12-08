#ifndef MODEL_H
#define MODEL_H

#include <list>
#include "GameObject.h"
#include "Port.h"
#include "Dock.h"
#include "Sailor.h"
#include "View.h"
#include "Merchant.h"
#include "Pirate.h"
#include "InputHandling.h"

class Kraken;
class Model
{

 private:

  int time;

 public:
  Kraken* kraken;

  Model();

  ~Model();

  Sailor* get_Sailor_ptr(int);

  Port* get_Port_ptr(int);

  Dock* get_Dock_ptr(int);

  bool update();

  void display(View&);

  void show_status();

  virtual void add_new_object(GameObject*);

  void create_merchant(Merchant*);

  Merchant* check_partner(Merchant*);

  std::list<Dock*>* dock_ptrs;

  std::list<Port*>* port_ptrs;

  std::list<Sailor*>* sailor_ptrs;

  std::list<GameObject*>* object_ptrs;

  std::list<GameObject*>* active_ptrs;
};

#endif
