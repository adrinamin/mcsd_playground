#pragma once
#include "Tweeter.h"
#include <iostream>

Tweeter::Tweeter(std::string first, std::string last, int age, std::string handle)
:Person(first,last, age),twitterhandle(handle)
{
    std::cout << "constructing tweeter" << twitterhandle << std::endl;
}

Tweeter::~Tweeter()
{
    std::cout << "destructing tweeter" << twitterhandle << std::endl;
}