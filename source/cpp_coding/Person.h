#pragma once
#include <string>
#include "Resource.h"
#include <memory>

class Person
{
private:
    std::string firstname;
    std::string lastname;
    int age;
    int salary;
    // Resource* pResource; // if sth is optional (thus is can be null) use the pointer syntax
    // better
    std::shared_ptr<Resource> pResource;

    // setting this operator as friend it can read the age
    friend bool operator<(int i, Person const& p);
public:
    // Person()=default; -> creates completely random person object
    Person();
    Person(std::string first, std::string last, int age);
    Person(std::string first, std::string last, int age, int salary);
    // if you have one virtual function, make the destructor also virtual!
    virtual ~Person();
    // copy ctor and assignment is for memory safety to avoid deletion of something that is already deleted
    // we don't need those with smart pointers
    // Person(Person const & p); // copy constructor
    // Person& operator=(const Person& p); //copy assignment
    virtual std::string getName() const;
    int getSalary() const {return salary;}
    int GetAge() const {return age;}
    void AddResource();
    std::string GetResourceName() const { return pResource ? pResource->GetName() : "";}
    bool operator<(Person const& p) const;
    bool operator<(int i) const;
};

bool operator<(int i, Person const& p);

// the free store (aka the heap) gives objects a lifetime longer than local scope
// manual memory management is hard (don't use new and delete!!!)
// use smark pointes which make life a lot simpler
