#include "GameObject.h"
#include "Sailor.h"
bool Sailor::update_location()
{
  //if the distance to the destination is smaller than how far he can travel he will make it this step
  cout<<display_code<<get_id()<<": ";

  if(get_speed() > (cart_distance(location, destination)))
    {
      location = destination;

      cout<<"I'm there!"<<endl;

      return true;

    }
  else
    {
      this-> location=location+delta;

      cout<<"Just keep sailing..."<<endl;

      return false;

    }

}


void Sailor :: setup_destination(CartPoint dest)
{
  
  destination=dest;

  delta=(this->destination-this->get_location())*(get_speed()/cart_distance(destination,this->location));

}

Sailor :: Sailor():GameObject('S' , 0)//default constructor
{

  state = 'a';

  health = 25;

  size = 15;

  hold = 100;

  cargo = 0;

  destination.x = 0;

  destination.y = 0; 

  port = NULL;

  dock = NULL;

  hideout = NULL;

  cout<<"Sailor default constructed"<<endl;

}

Sailor::Sailor(int in_id, Dock* hideout) : GameObject('S', in_id, hideout->get_location())//constructor
{
 
  state = 'h';

  health = 25;

  size = 15;

  hold = 100;

  cargo = 0;

  destination = hideout->get_location();
 
  port = NULL;

  dock = NULL;

  this->hideout = hideout;

  cout<<"Sailor constructed"<<endl;
}
   
bool Sailor::update()
{

  char startState=state;
  switch (state)
  {

  case 'a':
    {
      break;
    }

  case 's':
    {    
      bool check = update_location();
      if (check)
	{
	state='a';
	return true;
      }
  break;
    }

  case 'o':
    {    
bool check = update_location();
if (check){
  cout<<display_code<<get_id()<<": Starting to supply at a port"<<endl;
      state='l';
      return true;
  }
 break;
    }

  case 'i':
    {
bool check = update_location();
if (check==true)
  {
    cout<<display_code<<get_id()<<": Starting to unload at a dock"<<endl; 
      state='u';
      return true;
  }
 break;

    }

  case 'l':
    {   
      if (cargo==hold)
	{
	  
	  state='a';

	  cout<<display_code<<get_id()<<": My boat is filled up. Send me to a Dock to unload. Dropping anchor"<<endl;

	}
      else
	{
	  
	  if (hold<cargo)
	    {
	      cargo=hold;
	      /* double temp=cargo-hold;//checks how much more cargo we have than fits stores that number

	      cargo=cargo-temp;//reduces cargo to that number
	      */
	    }
	  else if(port->is_empty())//checks if the port has supplies left
	    {

	      state='a';

	      cout<<display_code<<get_id()<<": This Port has no more supplies for me. Dropping anchor"<<endl;

	      break;

	    }
	  
	  else //give the boat supplies
	    {

	    cargo+=port->provide_supplies();

	    }

	}

      if (port->is_empty() && cargo==hold)//solves an edge case where the boat is filled at the same time the dock is emptied, without this the message isn't displayed
	{

	  state='a';

	  cout<<display_code<<get_id()<<": This Port has no more supplies for me. Dropping anchor"<<endl;

	}

      if (cargo>hold)
	{

	  cargo = hold;

	}
      cout<<display_code<<get_id()<<": My new cargo is "<<cargo<<endl;
  
      break;
    }

  case 'u':
    {

      if (dock->dock_boat(this)==true)
	{

	  state='d';

	  cout<<display_code<<get_id()<<": I am unloading at the dock"<<endl;
	  
	  if(cargo>0)
	    {

	      hold+=20;

	      size+=5;

	      cargo=0;
	    }
	}
      else if (dock->dock_boat(this)==false)
	{

	  state='t';
	
	  cout<<display_code<<get_id()<<":Help! My dock is full"<<endl;

	}
	
	  break;
    }

  case 'd'://update does nothing in this case
    {
      break;
    }

  case 'h':
    {
      if (update_location())
	{

	  state='a';

	}
      //  cout<<display_code<<get_id()<<": Is going to hide at Dock "<<hideout->get_location()<<endl;
      break;
    }

  case 't'://update does nothing in this case

    {
      break;
    }

  default://nothing
    {
      cout<<"No no no now what? (the default should never be called"<<endl;
      break;
    }
  }  
  if (startState==state)
    {

      return false;

    }
  else 
    {
      return true;
    }


}
double Sailor::get_size()
{

  return size;

}

double Sailor::get_cargo()
{

  return cargo;

}

void Sailor::start_sailing(CartPoint dest)
{
  setup_destination(dest);

  if (state=='d')
    {

      dock->set_sail(this);

    }

  state = 's'; //for sailing

  cout<<"Sailing "<<get_id()<<" to "<<destination<<endl;

  cout<<display_code<<get_id()<<": On my way"<<endl;


}

void Sailor::start_supplying(Port* destPort)
{

  this->port=destPort;

  setup_destination(destPort->get_location());


  if (state=='d')
    {

      dock->set_sail(this);

    }

  state='o';

  cout<<"Sailor "<<get_id()<<" supplying at Port "<<port->get_id()<<" and going to Port "<<port->get_id()<<endl;

  cout<<display_code<<get_id()<<": Supplies here I come!"<<endl;

}


void Sailor::start_hiding()
{

  //tells sailor to hide at the hideout port

  CartPoint dest=this->hideout->get_location();

  if (state=='d')
    {

      dock->set_sail(this);

    }

  setup_destination(dest);

  state='h';//for hiding

  cout<<"Sailor"<<GameObject::get_id()<<" hiding "<<hideout->get_id()<<endl;//prob need to fix this not sure if you just do get id twice

  cout<<display_code<<GameObject::get_id()<<": Off to hide"<<endl;
}
  
bool Sailor::is_hidden()
 {
   
   if((cart_compare(this->get_location(), hideout->get_location())==1)) //need these to be cartpoints
     {

       return true;

     }
   else
     {

       return false;

     }
   
 }


void Sailor::start_docking(Dock* destDock)
{
  if (state=='d')
    {

      dock->set_sail(this);

    }

  this->dock=destDock;//sets the sailor's dock to the dock input

  setup_destination(dock->get_location());//sets the sailor's destination to that dock

  state='i';//his state is now i because he is inbound

  cout<<"Sailor "<<get_id()<<" sailing to Dock "<<destDock->get_id()<<endl;

  cout<<display_code<<get_id()<<": Off to Dock"<<endl;

}



void Sailor::anchor()//tells him to stop moving docking or supplying
{
  setup_destination(get_location());

  state='a';

  cout<<"Stopping "<<get_id()<<endl;
 
  cout<<display_code<<get_id()<<": Dropping anchor"<<endl;

}


void Sailor::show_status()
{

  cout<<"Sailor status: "<<display_code<<" with ID "<<get_id()<<" at location "<<this->location<<" ";

  switch (state)
    {
    case 'a':
      {
	if (is_hidden()==true)
	  {

	    cout<<"is anchored (and hiding). Has a size of: "<<size<<", cargo of: "<<cargo<<", hold of: "<< hold<<", and health of: "<<health<<endl;

	  }     
	else 
	  {

	    cout<<"is anchored. Has a size of: "<<size<<", cargo of: "<<cargo<<" hold of: "<< hold<<", and health of: "<<health<<endl;

	  }
	break;
      }
      case 's':
	{

	  cout<<"Has a speed of: "<<get_speed()<<" and is heading to: ";

	  cout<<destination<<endl;;

	break;

	}

      case 'o':
	{

	  cout<<"is outbound to Port: "<<this->port->get_id()<<" with a speed of "<<get_speed()<<endl;

	break;

	}
	
      case 'i':
	{

	  cout<<"is inbound to Dock: "<<dock->get_id()<<" with a speed of "<<get_speed()<<endl;

	break;

	}


      case 'l':
	{

	  cout<<" is supplying at Port "<<port->get_id()<<endl;

	break;

	}

      case 'u':
	{

	  cout<<" is unloading at Dock "<<this->dock->get_id()<<endl;

	break;

	}

      case 'd':
	{

	  cout<<" is docked at Dock "<<dock->get_id()<<endl;

	break;

	}

      case 'h':
	{

	  cout<<display_code<<get_id()<<": is going to hide at Dock "<<hideout->get_id()<<endl;

	break;

	}

      case 't':
	{

	  cout<<"is in trouble "<<get_id()<<endl;

	break;

	}
      default://they should never not have one of these state
	{
	  cout<<"Something is wrong the sailor has a state they should not"<<endl;

	  break;
	}
      }
    }

double Sailor::get_speed()
{

  return (size-(cargo*.1));

}

Sailor :: ~Sailor()
{

  cout<<"Sailor destructed"<<endl;

}
