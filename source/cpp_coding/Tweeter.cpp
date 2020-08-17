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

std::string Tweeter::GetName() const
{
    // if sth is private then it is not accessable from derived classed.
    return Person::getName() + " " + twitterhandle;
}
