#ifndef KRAKEN_H
#define KRAKEN_H
#include <list>
#include "Model.h"
#include <iostream>

class Kraken
{

 private:
  int time;

  int  warningTime;

 public:

  Kraken();

  bool update(Model*);

  std::list<Sailor*>* lives_claimed;

};
#endif
