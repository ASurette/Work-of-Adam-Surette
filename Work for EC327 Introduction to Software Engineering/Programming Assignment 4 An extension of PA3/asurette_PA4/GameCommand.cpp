#include "GameCommand.h"
#include "InputHandling.h"
#include <iostream>
#include "Model.h"

using namespace std;

void do_sail_command(Model& model)//sail
{
  int ID = 0;

  double x = 0;

  double y = 0;

  if(!(cin>>ID))
  throw InvalidInput("Was expecting an interger");

  if(!(cin>>x))
  throw InvalidInput("Was expecting a double");

  if(!(cin>>y))
  throw InvalidInput("Was expecting a double");

  Sailor* sailor = model.get_Sailor_ptr(ID);
  if(sailor == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");

  CartPoint dest(x,y);
  if (sailor->is_alive())
    {
      sailor->start_sailing(dest);
    }
  else
    {

      cout<<"The dead can't do much"<<endl;

    }
  //cout<<"Sailing sailor "<<ID<<" to "<<dest<<endl;
}
void do_port_command(Model& model)
{

  int ID1;

  int ID2;
  if(!(cin>>ID1)){
  throw InvalidInput("Was expecting an interger");}
  if(!(cin>>ID2)){
  throw InvalidInput("Was expecting an interger");}

  Sailor* sailor = model.get_Sailor_ptr(ID1);
  if(sailor == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");

Port* port = model.get_Port_ptr(ID2);
if(port == (Port*)NULL)
  throw InvalidInput("Invalid Port ID");


 if (sailor->is_alive())
    {

      sailor->start_supplying(port);

    }
  else
    {

      cout<<"The dead can't do much"<<endl;

    }
 

  // cout<<"Sailor"<<ID1<<" is going to supply at port "<<ID2<<endl;

}

void do_anchor_command(Model& model)//anchor
{
  int ID;

  if(!(cin>>ID))
    throw InvalidInput("Was expecting an interger");

  Sailor* sailor = model.get_Sailor_ptr(ID);
 
  if(sailor == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");

 if (sailor->is_alive())
    {

      sailor->anchor();

    }
  else
    {

      cout<<"The dead can't do much"<<endl;
      
    }
 

  // cout<<"Sailor "<<ID<<"is anchoring"<<endl;
}

void do_dock_command(Model& model)//dock
{

  int ID1;

  int ID2;
  if(!(cin>>ID1)){
  throw InvalidInput("Was expecting an interger");}
  if(!(cin>>ID2)){
  throw InvalidInput("Was expecting an interger");}

  Sailor* sailor = model.get_Sailor_ptr(ID1);
  if(sailor == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");

  Dock* dock = model.get_Dock_ptr(ID2);
  if(dock == (Dock*)NULL)
  throw InvalidInput("Invalid Dock ID");

 if (sailor->is_alive())
    {

    
      sailor->start_docking(dock);

    }
  else
    {

      cout<<"The dead can't do much"<<endl;
      
    }
 

  //  cout<<"Sailor "<<ID1<<" is docking at dock "<<ID2<<endl;

}
void do_hide_command(Model& model)//hide
{

  int ID;
if(!(cin>>ID))
    throw InvalidInput("Was expecting an interger");


  Sailor* sailor = model.get_Sailor_ptr(ID);
  if(sailor == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");


 if (sailor->is_alive())
    {

 
  sailor->start_hiding();


    }
  else
    {

      cout<<"The dead can't do much"<<endl;
      
    }

  // cout<<"Sailor "<<ID<<"is going to hide"<<endl;
}
void do_go_command(Model& model)
{
  cout<<"Advancing time one tick"<<endl;

  model.update();

  model.show_status();

}
void do_run_command(Model& model)
{
  int count = 0;
  bool initialUpd = false;//setting up a bool to save if the last update returned true or false
  //updates until something updated returns true or update has been called 5 times
  bool stop = true; //for checking whether or not to stop the while loop
  cout<<"Advancing to next event or 5 ticks"<<endl;  
while(stop)
    { 
      if ((count==5) || (initialUpd))
	{
	  model.show_status();
	  stop = false;
	}
      else
	{

	  initialUpd=model.update();

	  count++;

	}
    }
}

void do_plunder_command(Model& model)
{

  int ID1;

  int ID2;

  if(!(cin>>ID1)){
  throw InvalidInput("Was expecting an interger");}
  if(!(cin>>ID2)){
  throw InvalidInput("Was expecting an interger");}


  Sailor* sailor1 = model.get_Sailor_ptr(ID1);
  if(sailor1 == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID");

  Sailor* sailor2 = model.get_Sailor_ptr(ID2);
  if(sailor2 == (Sailor*)NULL)
    throw InvalidInput("Invalid Sailor ID"); 

 if (sailor1->is_alive())
    {
   
      sailor1->start_plunder(sailor2);

    }
  else
    {

      cout<<"The dead can't do much"<<endl;
      
    }

}

void handle_new_command(Model* model)
{

  char type;
  int ID;
  double x;
  double y;
  int ID_HOME;
  cin>>type;

  if(type !='P' && type != 'D' && type != 'M' && type != 'R'){
    throw InvalidInput("Not a valid character type");}

  if (type=='P')
    {	  
      if(!(cin>>ID)){
	throw InvalidInput("Was expecting an interger");}

      //check if the ID is already used for that type
      if(!(cin>>x)){
	throw InvalidInput("Was expecting a double");}
      if(!(cin>>y)){
	throw InvalidInput("Was expecting a double");}
      Port* object = new Port(ID, CartPoint(x,y));
      //must check whether or not the id is taken
      model->add_new_object(object);
    }
  else if(type=='D')
    {
      if(!(cin>>ID)){
	throw InvalidInput("Was expecting an interger");}
      if(!(cin>>x)){
	throw InvalidInput("Was expecting a double");}
      if(!(cin>>y)){
	throw InvalidInput("Was expecting a double");}
      //must check if the id was taken
      Dock* object = new Dock(ID, CartPoint(x,y));
      model->add_new_object(object);


    }
  else if (type=='M')
    {
      if(!(cin>>ID)){
	throw InvalidInput("Was expecting an interger");}
      if(!(cin>>ID_HOME)){
	throw InvalidInput("Was expecting an interger");}
      //must check if the id is taken
      //must check valid dock
      for(std::list<Dock*>::iterator it = model->dock_ptrs->begin(); it != model->dock_ptrs->end(); it++)
	{
	  if ((*it)->get_id()==ID_HOME)
	    {

	      Dock* dock = (*it);

	      Merchant* object = new Merchant(ID,dock,model);

	      model->add_new_object(object);
	    }
	}
  
    }

  else if (type=='R')
    {
      if(!(cin>>ID)){
	throw InvalidInput("Was expecting an interger");}
      //must check if the id is taken
      Pirate* object = new Pirate(ID, model);
      model->add_new_object(object);
    }
}

