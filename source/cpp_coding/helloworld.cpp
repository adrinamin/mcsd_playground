#include <iostream>
#include <vector>
#include <string>
#include "Person.h"
#include "Tweeter.h"
#include "status.h"

using namespace std;

int main()
{
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

    return 0;
}