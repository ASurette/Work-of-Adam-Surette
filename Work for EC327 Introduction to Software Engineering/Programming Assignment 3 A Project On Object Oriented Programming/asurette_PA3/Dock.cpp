#include "Dock.h"

Dock::Dock():GameObject('d', 0) 
{
  state = 'u';

  cout<<"Dock default constructed"<<endl;

}

Dock::Dock(int in_id, CartPoint in_loc):GameObject('d', in_id, in_loc)
{

  state = 'u';

  location=in_loc;

  berths=30;

  cout<<"Dock constructed"<<endl;

}

bool Dock::dock_boat(Sailor* sailor_to_dock)
{

  if ((berths)>=(sailor_to_dock->get_size()))
   { 

     berths=berths-sailor_to_dock->get_size();

     sailor_to_dock->docksize=sailor_to_dock->get_size();//saves the size of the sailor before he gains it and before he leaves the dock

     return true;

   }
 else
   {

     return false;

   }

}


bool Dock :: set_sail(Sailor* sailor_to_sail)//need to make it so that the dock gets back the amount of berths it lost when the sailor came in, not the size when he leaves
{
  if (sailor_to_sail->get_cargo() == 0)
    {

      berths+=sailor_to_sail->docksize;

      return true;

    }
  else
    {

      return false;

    }




}

bool Dock::update()
{

  if (berths==0 && state != 'p')
    {

      state = 'p';

      display_code='D';

      cout<<"Dock"<<GameObject::get_id()<<" is packed"<<endl;

      return true;

    }
  else if (berths!=0 && state=='p')
    {

      state = 'u';

      display_code='d';

      return true;

    }
  else
    {
      return false;
    }

}

void Dock::show_status()
{

  cout<<"Dock Status: "<<display_code<<" with ID "<<get_id()<<" at location "<<location<<" has "<<berths<<" berths"<<endl;

  if (state=='p')
    {

      cout<<"Dock is packed"<<endl;

    }
  else if (state == 'u')
    {

      //  cout<<"Dock is not packed"<<endl;

    }



}

 Dock :: ~Dock()
{

  cout<<"Dock deconstructed"<<endl;

}
