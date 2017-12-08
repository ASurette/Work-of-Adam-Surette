#include "Model.h"

Model :: Model()
{

  time = 0;

  num_objects = 10;

  num_sailors = 3;

  num_ports = 4;

  num_docks = 3;

  this->dock_ptrs = new Dock*[num_docks];

  this->dock_ptrs[0] = new Dock(1, CartPoint(5, 1));
 
  this->dock_ptrs[1] = new Dock(2, CartPoint(6, 2));

  this->dock_ptrs[2] = new Dock(3, CartPoint(1, 8));
  
  this->port_ptrs = new Port*[num_ports];
  
  this->port_ptrs[0] = new Port(1, CartPoint(1, 20));
  
  this->port_ptrs[1] = new Port(2, CartPoint(20, 1));
  
  this->port_ptrs[2] = new Port(3, CartPoint(20, 20));
  
  this->port_ptrs[3] = new Port(4, CartPoint(7, 2));
  
  this->sailor_ptrs = new Sailor*[num_sailors];
  
  this->sailor_ptrs[0] = new Sailor(1, dock_ptrs[0]);
  
  this->sailor_ptrs[1] = new Sailor(2, dock_ptrs[1]);
  
  this->sailor_ptrs[2] = new Sailor(3, dock_ptrs[2]);

  this->object_ptrs = new GameObject*[num_objects];

  this->object_ptrs[0] = this->dock_ptrs[0];

  this->object_ptrs[1] = this->dock_ptrs[1];

  this->object_ptrs[2] = this->dock_ptrs[2];
 
  this->object_ptrs[3] = this->sailor_ptrs[0];

  this->object_ptrs[4] = this->sailor_ptrs[1];

  this->object_ptrs[5] = this->sailor_ptrs[2];

  this->object_ptrs[6] = this->port_ptrs[0];

  this->object_ptrs[7] = this->port_ptrs[1];

  this->object_ptrs[8] = this->port_ptrs[2];

  this->object_ptrs[9] = this->port_ptrs[3];



  cout<<"Model default constructed"<<endl;

}

Model :: ~Model()
{

  for (int i; i < num_objects; i++)
    {

      delete object_ptrs[i];

    }

 cout<<"Model destructed"<<endl;

}

Sailor* Model :: get_Sailor_ptr(int id_num)
{

  if (id_num > num_sailors)//needs the -1 because arrays start at 0
    {

      return NULL;

    }
  else
    {

      return sailor_ptrs[id_num-1];//-1 because sailor with ID 1 is saved at 0

    }

}

Port* Model :: get_Port_ptr(int id_num)
{

 if (id_num > num_ports)
    {

      return NULL;

    }
  else
    {

      return port_ptrs[id_num-1];

    }



}

Dock* Model :: get_Dock_ptr(int id_num)
{

  if (id_num > num_docks)
    {

      return NULL;

    }
  else
    {

      return dock_ptrs[id_num-1];

    }



}

bool Model :: update()
{

  bool isTrue = false;//used for checking if any function returned true 

  bool check;
  time++;
  for (int i = 0; i < num_objects; i++)
    {
      check = object_ptrs[i]->update();

      if (check)
	{

	  isTrue=true;

	}
    }

  return isTrue;
}

void Model :: display(View& view)
{

cout<<"Time: "<<time<<endl;

 view.clear();

 for (int i = 0; i < num_objects; i++)
   {

     view.plot(object_ptrs[i]);
  
   }

 view.draw();

}

void Model :: show_status()
{

 for (int i = 0; i < num_objects; i++)
    {

      object_ptrs[i]->show_status();

    }

}
