#include "Person.h"
#include <iostream>

Person::Person(): age(0)
{
    std::cout << "constructing" << firstname << " " << lastname << std::endl;
}

Person::Person(std::string first, std::string last, int age)
:firstname(first), lastname(last), age(age)
{
    std::cout << "constructing instance: " << firstname << " " << lastname << std::endl;
}

Person::Person(std::string first, std::string last, int age, int salary)
:firstname(first), lastname(last), age(age), salary(salary)
{
    std::cout << "constructing instance: " << firstname << " with salary" << std::endl;
}

Person::~Person()
{
    std::cout << "destructing instance: " << firstname << " " << lastname << std::endl;
}

// Person::Person(Person const & p)
// {
//     pResource = new Resource(p.pResource->GetName());
// }

// Person& Person::operator=(const Person& p)
// {
//     pResource = new Resource(p.pResource->GetName());
//     return *this;
// }

std::string Person::getName() const
{
    return firstname + " " + lastname;
}

// member function
bool Person::operator<(Person const& p) const
{
    return age < p.age;
}

// member function
bool Person::operator<(int i) const
{
    return age < i;
}

// free function
// Person is a const reference to avoid changing the person
bool operator<(int i, Person const& p)
{
    // thus getAge must be const!
    // return i < p.GetAge();
    // if you want to avoid the GetAge method you can declare this operator as 'friend'
    return i < p.age;
}

void Person::AddResource()
{
    pResource.reset();
    pResource = std::make_shared<Resource>("Resource for " + getName());
}