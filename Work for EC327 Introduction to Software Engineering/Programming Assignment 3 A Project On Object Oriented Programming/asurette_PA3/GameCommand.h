#ifndef GAMECOMMAND_H
#define GAMECOMMAND_H
#include "Model.h"
//I am using numbers so that I do not confuse myself with the actual port variable and anchor() etc.
void do_sail_command(Model&);//sail

void do_port_command(Model&);//port

void do_anchor_command(Model&);//anchor

void do_dock_command(Model&);//dock

void do_hide_command(Model&);//hide

void do_go_command(Model&);

void do_run_command(Model&);
#endif
