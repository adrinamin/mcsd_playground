#include <iostream>
#include <vector>
#include <string>
#include "Person.h"
#include "Tweeter.h"
#include "status.h"
#include "Utility.h"
#include "Accum.h"

using namespace std;

template <class T>
T max2(T const& t1, T const& t2)
{
    return t1 < t2? t2: t1;
}

int DoubleIt(int const& x)
{
    return x*2;
}


int main()
{
    // references
    int a = 3;
    std::cout << "a is " << a << std::endl;
    // initialize reference when you declare it
    int& rA = a;
    rA = 5;
    std::cout << "a is " << a << std::endl;

    Person Sally("Sally", "Doe", 234);
    Person& rSally = Sally;
    std::cout << "rSally is " << rSally.GetAge() << std::endl;

    // pointers
    // always initialize pointer.
    // int* pA = nullptr -> null pointer are possible
    int* pA = &a;
    *pA = 4;
    std::cout << "a is " << a << std::endl;
    int b = 100;
    pA = &b;
    (*pA)++;
    std::cout << "a " << a << ", *pA " << *pA << endl;

    Person* pKate = &Sally;
    std::cout << "*pKate: " << (*pKate).getName() << std::endl;
    std::cout << "pKate->: " << pKate->getName() << std::endl;


    // const
    // commit to the compiler you won't change something
    int i = 3;
    int const ci = 3; // const after
    i = 4;
    // ci = 4 -> not possible

    int&ri = i;
    ri = 5;

    int const & cri = i;
    // cri = 6 -> not possible

    // int& ncri = ci -> not possible

    int j = 10;
    int DoubleJ = DoubleIt(j);
    int DoubleTen = DoubleIt(10);

    Person blabla("blabla", "blubblub", 234);
    Person const cbla = blabla;
    int blaAge = cbla.GetAge();

    // const with indirection
    // refernces cannot retarget. so const means you can't change the value.

    // pointers: you can declare the pointer to be const:
    //int * const cpI
    //Then you can't change it to point somewhere else
    // cpI = &something -> not possible
    // you can declare that the pointer poijnts at something const
    // int const * cpI
    // Then you can't use it to change the calue of the target
    // *cpI = 2;

    std::cout << "max of 99 and 100 is " << max2(99,100) << std::endl;
    std::string firstname;
    std::string lastname;
    int age;

    std::cout << "Type your first name" << std::endl;
    std::cin >> firstname;
    std::cout << "Type your last name" << std::endl;
    std::cin >> lastname;
    std::cout << "Type your age" << std::endl;
    std::cin >> age;

    // beware of following issue:
    // https://stackoverflow.com/questions/15712821/c-error-undefined-reference-to-classfunction
    Person person(firstname,lastname,age);
    {
        Tweeter tweeter("Someone","Else",20,"@whoever");
        std::string name2 = tweeter.getName();
    }

    std::cout << "Hello " << firstname << std::endl;

    // compiler handles the type of this variable
    auto value1 = 2.2;

    int i5 = 1;
    double dvalue = 2.5;

    string sign = value1 > 2.2? "bigger than 2.2" : "smaller than 2.2";
    std::cout << sign << std::endl;

    // safe casting 
    // -> telling compiler that loosing data is okay.
    i5 = static_cast<int>(dvalue);

    // using enums
    FileError fe = FileError::notfound;
    fe = FileError::ok;

    NetworkError ne = NetworkError::notfound;
    ne = NetworkError::ok;

    int x;
    std::cout << "Please enter a number for checking if it is a prime number" << std::endl;
    std::cin >> x;

    if (IsPrime(x))
    {
        std::cout << x << " is prime" << std::endl;
    }
    else
    {
        std::cout << x << " is not prime" << std::endl;
    }

    if (Is2MorePrime(x))
    {
        std::cout << x << " + 2 is prime" << std::endl;
    }
    else
    {
        std::cout << x << " +2 is not prime" << std::endl;
    }

    Person anotherPerson("John", "Doe", 99);
    Person anotherPerson2("Jason", "Doe", 100);
    std::cout << anotherPerson.getName();
    if (!(anotherPerson < anotherPerson2))
    {
        std::cout << "not";
    }
    std::cout << " is younger than " << anotherPerson2.getName() << endl; 

    Accum<int> integers(0);
    integers += 3;
    integers += 7;
    std::cout << integers.GetTotal() << std::endl;

    Accum<Person> salary(0);
    Person kate("Kate","ha", 123,100000);
    Person greg("greg","bla", 456,120000);
    salary += kate;
    salary += greg;
    std::cout << salary.GetTotal() << std::endl;

    return 0;
}