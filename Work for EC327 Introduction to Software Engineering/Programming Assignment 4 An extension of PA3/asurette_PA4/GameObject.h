#ifndef GAMEOBJECT_H
#define GAMEOBJECT_H

#include <iostream>
#include "CartPoint.h"
using namespace std;
class GameObject
{
 private:

  int id_num;

 protected:

  CartPoint location;

  public:

  char state;

  char display_code;
  
  GameObject(char, int);

  GameObject(char, int, CartPoint);

  CartPoint get_location();

  int get_id();

  virtual void show_status(); 

  virtual ~GameObject();

  virtual bool update() = 0;//pure virtual function to make GameObject abstract

  void drawself(char* grid);

  virtual bool is_alive();
};
#endif
