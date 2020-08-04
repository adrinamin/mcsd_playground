#pragma once
#include <string>

class Person
{
private:
    std::string firstname;
    std::string lastname;
    int age;
public:
    // Person()=default; -> creates completely random person object
    Person();
    Person(std::string first, std::string last, int age);
    ~Person();
    std::string getName();
};
