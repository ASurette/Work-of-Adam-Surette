#include "View.h"
#include "Model.h"

View::View(){
 size = 11;
 
 scale = 2;

 origin.x = 0.0;

 origin.y =0.0;

}

bool View::get_subscripts(int &ix, int &iy, CartPoint location){
  
 CartVector temp = (location - origin) / scale;

 ix=temp.x;

 iy=temp.y;

 if (ix <= size && iy <= size && ix >= 0 && iy >=0)
   {

     return true;

   }
 else 
   {

   return false;

   cout <<"An object is outside the display"<<endl;
   
   }
  
}

void View::clear()
{
  for (int i = 0; i < view_maxsize; i++)
    {
      for(int j = 0; j < view_maxsize; j++)
	{

	  grid[j][i][0] = '.';

	  grid[i][j][1] =' ';
	}
    }
}

void View::plot(GameObject* ptr){
  int x;

  int y;

  if(get_subscripts(x, y, ptr->get_location()))
    {
      if (*(grid[x][y]) == '.')
      {
    
      ptr->drawself(grid[x][y]);
   
      }
    else{
      grid[x][y][0] = '*';

      grid[x][y][1] = ' ';

    }
  }
}

void View::draw()
{ 
  int a = view_maxsize;

  int b = 0;

  for (int i = size-1; i >= 0; i--)
    {
      if ((i%2)==0)//checking for even # lines saying the top line is 0
	{
	  if (a<10)//if the number that needs to be output has 1 digit or less
	    {

	      cout<<a<<" ";

	    }
	  else
	    {

	      cout<<a;
	      
	    }
	  a=a-4;
	}
      else
	{
	
	  cout<<"  ";
  
	}
    
      for(int j = 0; j < size; j++)
	{
	  cout<<grid[j][i][0];

	  cout<<grid[j][i][1];
	}
      cout<<endl;
    }
  cout<<"  ";
  for (int z = 0; z < (size+1)/2; z++)
    {
      if (b>9)
	{

	  cout<<b<<"  ";

	}
      else
	{

	  cout<<b<<"   ";

	}
      //double number of spaces
      b=b+4;

    }
  cout<<endl;
}


View :: ~View()
{

  cout<<"View destructed"<< endl;

}
