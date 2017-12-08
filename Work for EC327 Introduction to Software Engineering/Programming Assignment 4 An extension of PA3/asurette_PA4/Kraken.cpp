#include "Kraken.h"

Kraken::Kraken()
{

  time = 0;

  warningTime = 0;

  lives_claimed = new std::list<Sailor*>;

}

bool Kraken::update(Model* model)
{

  time++;

  warningTime++;

  if (warningTime % 10==0 && time%15!=0)
    {

      cout<<"Early Kraken Warning!"<<endl;

    }
  else if (time%15==0)
    {
      //checking for dead sailors

      for (std::list<GameObject*>::iterator it = model->active_ptrs->begin(), r; it != model->active_ptrs->end(); it++) //iterate through active pointers
	{
	  if(dynamic_cast<Sailor*>(*it) != NULL)//check if it is a sailor
	    {
	      cout<<(*it)->get_id()<<endl;
	      if(dynamic_cast<Sailor*>(*it)->is_alive()==false)//if that sailor is not alive
		//check whoever isn't alive------------------------------------
		{

		  this->lives_claimed->push_back(dynamic_cast<Sailor*>(*it));//adding them to the dead sailors list
		 
		}
	    }
	}
      for (std::list<GameObject*>::iterator it = model->active_ptrs->begin(); it != model->active_ptrs->end(); it++) //iterate through active pointers
	{
	  if(dynamic_cast<Sailor*>(*it)!=NULL)//if the object is a sailor
	    {

	      for (std::list<Dock*>::iterator itd = model->dock_ptrs->begin(); itd != model->dock_ptrs->end(); itd++) //iterate through all of the docks
		{
		  if(cart_compare(dynamic_cast<Sailor*>(*it)->get_location(),(*itd)->get_location()))//if the sailor is at the same location as a dock he is safe
		    {

		      dynamic_cast<Sailor*>(*it)->safe = true;
		    }
		}
	    }
	}
      for (std::list<GameObject*>::iterator it = model->active_ptrs->begin(); it != model->active_ptrs->end(); it++) //iterate through active pointers
	{
	  if(dynamic_cast<Sailor*>(*it)!=NULL)//if the object is a sailor

	    {
	      if(dynamic_cast<Sailor*>(*it)->safe==false)//if the sailor is at the same location as a dock he is safe
		{
		  this->lives_claimed->push_back(dynamic_cast<Sailor*>(*it));//adding them to the dead sailors list
		}
	    }
	}
      cout<<"The Kraken has claimed..."<<endl;
      for (std::list<Sailor*>::iterator iter = lives_claimed->begin(); iter != lives_claimed->end(); iter++) //iterate through active pointers
	{

	  cout<<(*iter)->display_code<<(*iter)->get_id()<<endl;//displaying all the lives lost

	  model->active_ptrs->remove(*iter);
	}
    }
}
