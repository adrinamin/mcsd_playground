#pragma once
#include <string>

class Person
{
private:
    std::string firstname;
    std::string lastname;
    int age;
    int salary;

    // setting this operator as friend it can read the age
    friend bool operator<(int i, Person const& p);
public:
    // Person()=default; -> creates completely random person object
    Person();
    Person(std::string first, std::string last, int age);
    Person(std::string first, std::string last, int age, int salary);
    ~Person();
    std::string getName();
    int getSalary() const {return salary;}
    int GetAge() const {return age;}
    bool operator<(Person const& p) const;
    bool operator<(int i) const;
};

bool operator<(int i, Person const& p);
