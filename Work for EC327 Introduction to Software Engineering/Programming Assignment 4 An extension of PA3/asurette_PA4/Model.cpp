#include <iostream>
#include "Model.h"
#include "Sailor.h"
#include "Merchant.h"
#include "GameObject.h"
#include "Port.h"
#include "Dock.h"
#include "Pirate.h"
#include "Kraken.h"
#include <cstdlib>//for random

Model :: Model()
{

  time = 0;

  srand(time);//also in update

  dock_ptrs = new std::list<Dock*>;
  port_ptrs = new std::list<Port*>;
  sailor_ptrs = new std::list<Sailor*>;
  object_ptrs = new std::list<GameObject*>;
  active_ptrs = new std::list<GameObject*>;
  //Docks-------------------------------------------------
  Dock* d1 = new Dock(1, CartPoint(5, 1));
  dock_ptrs->push_back(d1);

  Dock* d2 = new Dock(2, CartPoint(6, 2));
  dock_ptrs->push_back(d2);

  Dock* d3 = new Dock(3, CartPoint(1, 8));
  dock_ptrs->push_back(d3);

  //Ports-------------------------------------------------
  Port* p1 = new Port(1, CartPoint(1, 20));
  
  Port* p2 = new Port(2, CartPoint(20, 1));
  
  Port* p3 = new Port(3, CartPoint(20, 20));
  
  Port* p4 = new Port(4, CartPoint(7, 2));
  
  port_ptrs->push_back(p1);

  port_ptrs->push_back(p2);

  port_ptrs->push_back(p3);

  port_ptrs->push_back(p4);

  //Sailors---------------------------------------------

  Merchant* m1 = new Merchant(1, d1, this);
  
  Merchant* m2 = new Merchant(2, d2, this);
  
  Merchant* m3 = new Merchant(3, d2, this);

  Pirate* r4 = new Pirate(4, this);

  Pirate* r5 = new Pirate(5 ,this);

  Sailor* s1 = (Sailor*)m1;

  Sailor* s2 = (Sailor*)m2;

  Sailor* s3 = (Sailor*)m3;

  Sailor* s4 = (Sailor*)r4;

  Sailor* s5 = (Sailor*)r5;
 
  sailor_ptrs->push_back(s1);

  sailor_ptrs->push_back(s2);

  sailor_ptrs->push_back(s3);

  sailor_ptrs->push_back(s4);

  sailor_ptrs->push_back(s5);

  //GameObjects----------------------------------------

  GameObject* o1 = (GameObject*)d1;

  GameObject* o2 = (GameObject*)d2;

  GameObject* o3 = (GameObject*)d3;
 
  GameObject* o4 = (GameObject*)m1;//merchant

  GameObject* o5 = (GameObject*)m2;//merchant

  GameObject* o6 = (GameObject*)m3;//merchant

  GameObject* o7 = (GameObject*)r4;//pirate

  GameObject* o8 = (GameObject*)r5;//pirate

  GameObject* o9 = (GameObject*)p1;

  GameObject* o10 = (GameObject*)p2;

  GameObject* o11 = (GameObject*)p3;

  GameObject* o12 = (GameObject*)p4;
  
  object_ptrs->push_back(o1);

  object_ptrs->push_back(o2);

  object_ptrs->push_back(o3);

  object_ptrs->push_back(o4);

  object_ptrs->push_back(o5);

  object_ptrs->push_back(o6);

  object_ptrs->push_back(o7);

  object_ptrs->push_back(o8);

  object_ptrs->push_back(o9);

  object_ptrs->push_back(o10);

  object_ptrs->push_back(o11);

  object_ptrs->push_back(o12);
  
  //active_ptrs-----------------------------
  
  active_ptrs->push_back(o1);

  active_ptrs->push_back(o2);

  active_ptrs->push_back(o3);

  active_ptrs->push_back(o4);

  active_ptrs->push_back(o5);

  active_ptrs->push_back(o6);

  active_ptrs->push_back(o7);

  active_ptrs->push_back(o8);

  active_ptrs->push_back(o9);

  active_ptrs->push_back(o10);

  active_ptrs->push_back(o11);

  active_ptrs->push_back(o12);
  
  cout<<"Model default constructed"<<endl;

  kraken = new Kraken();

}

Model :: ~Model()
{
  
  for (std::list<GameObject*>::iterator it = this->object_ptrs->begin(); it != this->object_ptrs->end(); it++)
    {

      delete (*it);

    }

 cout<<"Model destructed"<<endl;
  
}

Sailor* Model :: get_Sailor_ptr(int id_num)
{
  
  for (std::list<Sailor*>::iterator it = sailor_ptrs->begin(); it != sailor_ptrs->end(); it++)
    {

      if ((*it)->get_id() == id_num)
	{

	  return *it;

	}

    }

}

Port* Model :: get_Port_ptr(int id_num)
{

for (std::list<Port*>::iterator it = port_ptrs->begin(); it != port_ptrs->end(); it++)
    {

      if ((*it)->get_id() == id_num)
	{

	  return *it;

	}

    }

}

Dock* Model :: get_Dock_ptr(int id_num)
{

for (std::list<Dock*>::iterator it = dock_ptrs->begin(); it != dock_ptrs->end(); it++)
    {

      if ((*it)->get_id() == id_num)
	{

	  return *it;

	}

    }
}

bool Model :: update()
{
  
  bool isTrue = false;//used for checking if any function returned true 

  bool check;

  time++;

  kraken->update(this);

  for (std::list<GameObject*>::iterator it = active_ptrs->begin(); it != active_ptrs->end(); it++)
    {
      check = (*it)->update();

      if (check)//if the object was updated output is true
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

 for (std::list<GameObject*>::iterator it = active_ptrs->begin(); it != active_ptrs->end(); it++)
   {

     view.plot(*it);
  
   }

 view.draw();
  
}

void Model :: show_status()
{
  
  for (std::list<GameObject*>::iterator it = active_ptrs->begin(); it != active_ptrs->end(); it++)
    {

      (*it)->show_status();

    }
  
}

void Model::create_merchant(Merchant* father)
{

  Merchant* newMerchant = new Merchant(0, father->hideout, this);

  cout<<"M"<<father->get_id()<<": I found a new recruit!"<<endl;

  //adding the new merchant to the lists
  sailor_ptrs->push_back(newMerchant);

  object_ptrs->push_back(newMerchant);
  
  active_ptrs->push_back(newMerchant);
}


void Model::add_new_object(GameObject* object)
{
  
  char dc = object->display_code;

  //to check if the id is already taken you must static cast the object to each object and test whether that is null
  //then iterate through active pointers and check if that object type has that id already
  //it is checking if it the object of that type, not if is the same as the object

  
  for (std::list<GameObject*>::iterator it = active_ptrs->begin(); it != active_ptrs->end(); it++)
    {
     

      if (dc=='P')//port
	{	  
   
	  this->object_ptrs->push_back(object);

	  this->active_ptrs->push_back(object);

	  this->port_ptrs->push_back(dynamic_cast<Port*>(object));

	}
      else if(dc=='D')//dock
	{

	  this->object_ptrs->push_back(object);

	  this->active_ptrs->push_back(object);

	  this->dock_ptrs->push_back(dynamic_cast<Dock*>(object));
 
	}
      else if (dc=='M')//merchant
	{
	  this->object_ptrs->push_back(object);

	  this->active_ptrs->push_back(object);

	  this->sailor_ptrs->push_back(dynamic_cast<Sailor*>(object));
	}
      else if (dc=='R')//sailor
	{
	  this->object_ptrs->push_back(object);

	  this->active_ptrs->push_back(object);

	  this->sailor_ptrs->push_back(dynamic_cast<Sailor*>(object));
	}
    }
}

Merchant* Model::check_partner(Merchant* recruiter)
{
  std::list<GameObject*>::iterator it;

  for (it = this->active_ptrs->begin(); it != this->active_ptrs->end(); it++) 
    {

      if (dynamic_cast<Sailor*>(*it) == NULL)
	{

	  //it is not a sailor therefore do nothing

	}
      else
	{//it is a sailor therefore...
	  if ((*it)->display_code=='M')//checking it is a merchant there
	    {

	      if (dynamic_cast<Merchant*>(*it)!=recruiter)//must check that the partner is not yourself
		{
		  if(dynamic_cast<Merchant*>(*it)->hideout->get_id() == recruiter->hideout->get_id())
		    {

		      return dynamic_cast<Merchant*>(*it);//cast the current sailor as a merchant and return it
		    }
		}
	    }
	}
    }
}
