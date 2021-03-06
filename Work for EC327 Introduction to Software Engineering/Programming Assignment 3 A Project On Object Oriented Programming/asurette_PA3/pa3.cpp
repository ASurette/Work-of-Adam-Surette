#include <iostream>
#include "GameObject.h"
#include "Port.h"
#include "Dock.h"
#include "Sailor.h"
#include "View.h"
#include "GameCommand.h"
#include "Model.h"

using namespace std;

int main()
{
  cout<<"EC327: Introduction to Software Engineering"<<endl<<"Fall 2015"<<endl<<"Programming Assignment 3"<<endl;
  Model* model = new Model();
  View view;
  char com = 'z';//command, intialized to something not 'q' so it runs
  model->show_status(); 
  while (com !='q')
    {
      model->display(view);
      cout<<"Enter command: ";  
      cin>>com; 
      switch(com)
	{

	case 's':
	  {
	    do_sail_command(*model);	
	    
	    break;
	  }
      
	case 'p':
	  {
	    do_port_command(*model);	

	    break;

	  }

	case 'a':
	  {
	    do_anchor_command(*model);

	    break;
	  }

	case 'd':
	  {
	    do_dock_command(*model);

	    break;
	  }
	case 'h':
	  {
	    do_hide_command(*model);
	    break;
	  }
	case 'g':
	  {
	    do_go_command(*model);

	    break;
	  }
	case 'r':
	  {
	    do_run_command(*model);

	    break;
	  }
	case 'q':
	  {
	    cout<<"Terminating Program"<<endl;
	    break;
	  }
	default:
	  {
	    cout<<"Error, improper command input try again."<<endl;
	    break;
	  }
	}
    }
  model->display(view); 
  delete model;
  //need to fix deconstructors
}
