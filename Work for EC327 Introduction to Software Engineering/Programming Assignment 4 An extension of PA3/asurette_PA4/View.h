#ifndef VIEW_H
#define VIEW_H
#include "GameObject.h"

const int view_maxsize = 20;

class View 
{
 private: 

  int size;

  double scale;

  CartPoint origin;

  char grid[view_maxsize][view_maxsize][2];

  bool get_subscripts(int&, int&, CartPoint);

 public:

  View();

  void clear();

  void plot(GameObject* ptr);

  void draw();

  ~View();

};
#endif
