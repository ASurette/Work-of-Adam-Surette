#include "Port.h"


Port::Port():GameObject('P', 0)
{

  state='f';

  inventory=500;

  cout<<"Port default constructed"<<endl;

}
//no call to GameObject() because the default constructor told to us has inputs and this calls one that does not.

Port:: Port(int in_id, CartPoint in_loc):GameObject('P',in_id,in_loc)
  {
    state='f';

    inventory=500;

    cout<<"Port constructed"<<endl;
  }

bool Port::is_empty()
  {

    if (this-> inventory == 0)
      {

        return true;

      }
    else
      { 
      
	return false;

      }
  }

  double Port::provide_supplies(double amount_to_provide)
  {
    if (inventory >= amount_to_provide)
      {
    inventory=inventory-amount_to_provide;

    return amount_to_provide;
      }
    else 
      {
	double temp=inventory;//set up a temp varaible for inventory so that I can set inventory to 0 without losing it current value

	inventory=0;

	return temp;

      }
  }

  bool Port::update()
  {
 //a variable designed to check if update has been called after it has been depleted. It is set to true when it is depeleted and prevents the message from being dispalyed again

    if ((is_empty()==true) && (state!='e'))
      {

      state='e';
     
      display_code='p';

      cout<<"Port"<<get_id()<<" has been depleted of supplies"<<endl;

      return true;

    }
    else
      {

	return false; 

      }
  }
void Port::show_status()//this needs to be fixed when the sample output is released
  {

    cout<<"Port Status: "<<display_code<<" with ID "<<get_id()<<" at location "<<location<<" containing supplies "<< inventory<<endl;


  }

Port :: ~Port()
{

  cout<<"Port destructed"<<endl;

}
