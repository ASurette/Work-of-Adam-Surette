#include "CartVector.h"
CartVector::CartVector()//default constructor for CartVector
  {

    x=0;

    y=0;

  }

CartVector::CartVector(double in_x, double in_y)//constructor for CartVector
  {

    x=in_x;

    y=in_y;

  }
  //nonmember overload operators
  CartVector operator*(const CartVector& v1, double d)
  {

	CartVector temp;

	temp.x=v1.x*d;

	temp.y=v1.y*d;

	if (temp.x==-0){
	  temp.x=0;}
	if(temp.y==-0){
	  temp.y=0;}
	return temp;
      
  }

  CartVector operator/(const CartVector& v1, double d)
  {
    if (d==0)
      {
	return v1;
      }
    else 
      {
	CartVector temp;

	temp.x=(v1.x/d);

	temp.y=(v1.y/d);

	return temp;
      }
  }
std::ostream& operator<<(std::ostream& p1, const CartVector& p2)
    {

      p1<<"<"<<p2.x<<", "<<p2.y<<">"<<endl;

    }
