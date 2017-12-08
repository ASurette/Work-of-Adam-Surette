#ifndef CARTPOINT_H
#define CARTPOINT_H
#include <iostream>
#include "CartVector.h"
#include <math.h>
using namespace std;


class CartPoint
{
 public:

  double x;

  double y;

  CartPoint();

  CartPoint(double, double);

};

 double cart_distance(CartPoint, CartPoint);

 bool cart_compare(CartPoint, CartPoint);

 ostream& operator<<(ostream&, const CartPoint&);

 CartPoint operator+(const CartPoint&, const CartVector&);

 CartVector operator-(const CartPoint&, const CartPoint&);
#endif
