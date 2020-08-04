#pragma once
#include "Person.h"
#include <string.h>

class Tweeter : public Person
{
private:
    std::string twitterhandle;
public:
    Tweeter(std::string first, std::string last, int age, std::string handle);
    ~Tweeter();
};
