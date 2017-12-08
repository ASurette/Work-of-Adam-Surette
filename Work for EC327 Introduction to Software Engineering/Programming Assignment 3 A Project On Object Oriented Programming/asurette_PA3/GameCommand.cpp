#include "GameCommand.h"
/*
 int ID;
  int ID1;
  int ID2;
  int x;
  int y;
*/
void do_sail_command(Model& model)//sail
{
  int ID = 0;

  double x = 0;

  double y = 0;

  cin>>ID>>x>>y;

  Sailor* sailor = model.get_Sailor_ptr(ID);//note this is getting the wrong id since arrays start at 0, must fix

  CartPoint dest(x,y);

  sailor->start_sailing(dest);

  //cout<<"Sailing sailor "<<ID<<" to "<<dest<<endl;
}
void do_port_command(Model& model)
{

  int ID1;

  int ID2;

  cin>>ID1>>ID2;

  Sailor* sailor = model.get_Sailor_ptr(ID1);

  Port* port = model.get_Port_ptr(ID2);

  sailor->start_supplying(port);

  // cout<<"Sailor"<<ID1<<" is going to supply at port "<<ID2<<endl;

}

void do_anchor_command(Model& model)//anchor
{
  int ID;

  cin>>ID;

  Sailor* sailor = model.get_Sailor_ptr(ID);

  sailor->anchor();

  // cout<<"Sailor "<<ID<<"is anchoring"<<endl;
}

void do_dock_command(Model& model)//dock
{

  int ID1;

  int ID2;

  cin>>ID1>>ID2;

  Sailor* sailor = model.get_Sailor_ptr(ID1);

  Dock* dock = model.get_Dock_ptr(ID2);

  sailor->start_docking(dock);

  //  cout<<"Sailor "<<ID1<<" is docking at dock "<<ID2<<endl;

}
void do_hide_command(Model& model)//hide
{

  int ID;

  cin>>ID;

  Sailor* sailor = model.get_Sailor_ptr(ID);

  sailor->start_hiding();

  // cout<<"Sailor "<<ID<<"is going to hide"<<endl;
}
void do_go_command(Model& model)
{
  cout<<"Advancing time one tick"<<endl;

  model.update();//might have a problem with gonig places, sailors are getting there too fast check again later

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
