#include "Person.h"
#include <iostream>

Person::Person(): age(0)
{
    std::cout << "constructing" << firstname << " " << lastname << std::endl;
}

Person::Person(std::string first, std::string last, int age)
:firstname(first), lastname(last), age(age)
{
    std::cout << "constructing" << firstname << " " << lastname << std::endl;
}

Person::~Person()
{
    std::cout << "constructing" << firstname << " " << lastname << std::endl;
}

std::string Person::getName()
{
    return firstname + " " + lastname;
}