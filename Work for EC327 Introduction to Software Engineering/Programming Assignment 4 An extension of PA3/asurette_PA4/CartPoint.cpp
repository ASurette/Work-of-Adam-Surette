#include "CartPoint.h"

 //note all of these functions/overload should be nonmember functions
CartPoint::CartPoint()//default constructor
  {

    x=0;

    y=0;

  }

CartPoint::CartPoint(double in_x, double in_y)//constructor
  {
    x=in_x;

    y=in_y;
  }

  double cart_distance(CartPoint p1, CartPoint p2)//checks the distance between two points
  {

    double c;

    c=sqrt(((p2.x-p1.x)*(p2.x-p1.x))+((p2.y-p1.y)*(p2.y-p1.y)));
    
    return c;

  }

  bool cart_compare(CartPoint p1, CartPoint p2)//checks if two points are the same
  {

    if((p1.x==p2.x)&&(p1.y==p2.y))
      {

	return true;

      }
    else 
      {
      
	return false;
      
      }
  }
ostream& operator<<(ostream& p1, const CartPoint& p2)//overloading << to output points
  {

    p1<<"("<<p2.x<<", "<<p2.y<<")";

    return p1;

  }

  CartPoint operator+(const CartPoint& p1, const CartVector& v1)//adding a point to a vector
  {
    
    CartPoint temp;

    temp.x=p1.x+v1.x;

    temp.y=p1.y+v1.y;

    return temp;

  }  

CartVector operator-(const CartPoint& p1, const CartPoint& p2)
{


  CartVector temp;

  temp.x=p1.x-p2.x;

  temp.y=p1.y-p2.y;

  return temp;

}









