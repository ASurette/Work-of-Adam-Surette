#include "GameObject.h"
#include "CartPoint.h"

GameObject ::  GameObject(char in_code, int in_id)
  {

    display_code = in_code;

    id_num=in_id;

    location.x=0;

    location.y=0;

    cout<<"GameObject default constructed"<<endl;

  }

GameObject :: GameObject(char in_code, int in_id, CartPoint in_loc)
  {

    display_code=in_code;

    id_num=in_id;

    location.x=in_loc.x;

    location.y=in_loc.y;

    cout<<"GameObject constructed"<<endl;


  }

CartPoint GameObject::get_location()
  {

    return location;

  }

int GameObject:: get_id()
{

  return id_num;

}

void GameObject::show_status()
{

  cout<<display_code<<"with ID "<<id_num<<"at location"<<location<<endl;

}

GameObject :: ~GameObject()
{

  cout<<"GameObject destructed"<<endl;

}

void GameObject :: drawself(char* grid)
{

  *grid = this->display_code;

  *(grid+1) = (this->get_id() + 48);//adding 48 so it matchs in ASCII

}

bool GameObject::is_alive()
{

  return true;

}
