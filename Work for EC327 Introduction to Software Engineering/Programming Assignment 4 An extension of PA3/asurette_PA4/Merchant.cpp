#include "Merchant.h"
#include "Model.h"
#include <list>

Merchant::Merchant(Model* world):Sailor('M', world)
{
  set_health(60);

  set_size(10);//using the created setter

}
Merchant::Merchant(int id, Dock* home, Model* world):Sailor('M', id, home, world)
{
  set_health(60);

  set_size(10);

}
double Merchant::get_speed()
{

  return (1/get_size())*get_health()*4;

}

bool Merchant::start_recruiting(Merchant* partner)
{
 
  if (this->get_hideout() == partner->get_hideout())//if both merchants have the same hideout
    {
 
      if (this->get_hideout()->get_berths() > 10)//if there is space at the dock 
	{

	  if (this->get_health()>=40 && partner->get_health()>=40)//if they both have health over 40
	    {
	      CartPoint locCompare =this->get_hideout()->get_location();
	      
	      int count = 0;//count for how many sailors are at that dock

	      for (list<GameObject*>::iterator it = world->active_ptrs->begin(); it != world->active_ptrs->end(); it++)//iterating through the active pointers
		{

		  if(dynamic_cast<Sailor*>(*it)==NULL)//makes sure it is not a sailor
		    {
		      //IT WASNT A SAILOR DO NOTHIGN
		    }
		  else//if it is a sailor
		    {
		      if (cart_compare((*it)->get_location(),locCompare))//checking if there are only 2 sailors at the dock
			{
			  count++;//increment how many sailors are at the dock
			}	
		    }
		}
	      if (count != 2)//check if there are not two merchants at the dock
		{
	
		  return false;
		  //way to do this is looking if there are three or more people at the dock
		  //then need to look for the lowest avaliable sailor id (picture on phone of general idea)

		}
			
	      else
		{
	
		  this->tick=0;

		  partner->tick=0;

		  this->state='r';

		  partner->state='m';

		  return true;
		}
	    }
	}
    }
}

void Merchant::start_plunder(Sailor* target)
{

  Sailor::start_plunder(target);

}
bool Merchant::update()
{
  //state checking
  if (state =='r')//recruiting
    {
      tick++;     
      CartPoint locCompare =this->get_hideout()->get_location();
	      
      int count = 0;//count for how many sailors are at that dock

      for (list<GameObject*>::iterator it = world->active_ptrs->begin(); it != world->active_ptrs->end(); it++)//iterating through the active pointers
	{

	  if(dynamic_cast<Sailor*>(*it)==NULL)//makes sure it is not a sailor
	    {
	      //IT WASNT A SAILOR DO NOTHIGN
	    }
	  else//if it is a sailor
	    {
	      if (cart_compare((*it)->get_location(),locCompare))//checking if there are only 2 sailors at the dock
		{
		  count++;//increment how many sailors are at the dock
		}	
	    }
	}
      if (tick==2 && count==2)//if 2 ticks have passed and 2 people there
	{

	  world->Model::create_merchant(this);

	  this->state='a';

	  this->partner->state='a';

	  return true;
	}
      return false;
    }
  else if(state == 'x' || state=='m')
    {
      cout<<endl;
      return false;
      //nothing

    }
  else if (state=='a')
    {
      partner = world->check_partner(this);//check if there is someone else at the dock that has the dock as their hideout and is a merchant

      partner->partner=this;

      this->start_recruiting(partner);
      
      if(this->is_hidden())//if he is a merchant and if he is hidden lose 5 hp
	{

	  this->set_health(get_health()-5);
	
	  if (get_health()<5)//if health is less than 5 then he is dead
	    {

	      state = 'x';
	      return true;
	    }
	}
      
    }
  else
    {
      Sailor::update();
    }
}
void Merchant::show_status()
{
  cout<<"Merchant status: ";

  Sailor::show_status();

  if (state=='r' || state=='m')
    {

      cout<<" is recruiting with M"<<partner->get_id()<<endl;

    }
}

