#include <iostream>
#include "Utility.h"

bool IsPrime(int x)
{
    bool prime = true;
    for (int i=2; i<=x/i; i=i+1)
    {
        int factor = x/i;
        if (factor*i == x)
        {
            std::cout << "factor found: " << factor << std::endl;
            prime = false;
            break;
        }
    }

    return prime;
}

// bool Is2MorePrime(int& x) -> take it by reference to save the copy, but that is pretty dangerous
// bool Is2MorePrime(int const& x) -> you can avoid it with const&. 
// So you can take it by reference without changing the value, plus you don't have the copy ()
bool Is2MorePrime(int x)
{
    x = x+2;
    return IsPrime(x);
}

// return int by reference -> also very dangerous -> dangling reference
// returning a reference is a very advanced thing.
// int& BadFunction()
// {
//     int a = 3;
//     return a;
// }

// savest thing is to return by value