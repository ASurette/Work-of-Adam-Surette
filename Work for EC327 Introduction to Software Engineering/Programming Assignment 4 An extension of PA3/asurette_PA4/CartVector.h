#ifndef CARTVECTOR_H
#define CARTVECTOR_H
#include <iostream>
using namespace std;
class CartVector
{
 public:

  double x;

  double y;

  CartVector();

  CartVector(double, double);

};
//overload nonmember functions

CartVector operator*(const CartVector&, double);

CartVector operator/(const CartVector&, double);

std::ostream& operator<<(std::ostream&, const CartVector&);

#endif
