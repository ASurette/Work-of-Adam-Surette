#include "Pirate.h"

Pirate::Pirate(Model* world):Sailor('R', world)
{

  set_size(20);

  set_as(5);

  start_sailing(get_location());//might need to fix this

}

Pirate::Pirate(int in_id, Model* world):Sailor('R', in_id, CartPoint(rand()%20,rand()%20), world)
{

  //they have a random starting location that is seeded via the time in model

  set_size(20);

  set_as(5);

  start_sailing(get_location());

}
double Pirate::get_speed()
{

  return 0;//Pirates don't move, they are really bad at their job apparently

}

void Pirate::show_status()
{

  cout<<"Pirate status: ";

  this->Sailor::show_status();

  if (state == 'p')
    {
  
      cout<<" Curently attacking "<<this->target->get_id()<<endl;

    }
}
bool Pirate::update()
{

  if (state == 'x')
    {

      //do nothing

      return false;

    }
  else if (state == 'a')
    {

      //do nothing

      return false;

    }
  else if (state == 'p')
    {

      if (cart_distance(this->get_location(),this->target->get_location()) < 1)
	{

	  if(this->target->is_alive())
	    {
	      cout<<"Arrghh matey!"<<endl;

	      target->get_plundered(this->attack_strength);//plunder the target

	      return false;

	    }
	  else
	    {

	      cout<<"I triumph!"<<endl;

	      state = 's';

	      add_health(5);

	      return true;

	    }

	}

    }

}
void Pirate::start_plunder(Sailor* target)
{

  double distance = cart_distance(this->get_location(),target->get_location());

  if(distance < 1)
    {

      cout<<"Arrrggghhhh!"<<endl;

      this->target=target;

      state = 'p';//for plunder

    }
    else
      {

	cout<<"I will be back for you!"<<endl;

      }

}
bool Pirate::start_recruiting(Sailor* partner)
{

  Sailor::start_recruiting(partner);

}

void Pirate::set_as(int)
{

  attack_strength=5;

}
