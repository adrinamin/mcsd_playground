""" xorplus_checker.py module

Given two integers m and n, how many possible combinations of positive 
integers satisfy the following condition: a + b = m, a XOR b = n

Usage:

    python3 xorplus_checker.py <m> <n>

Example

    python3 xorplus_checker.py 3 3

"""
import sys


def check_for_xor_and_plus(m: int, n: int):
    """ Checks the parameters m and n for satisfying the following need:
        a + b = m, a XOR b = n
    
    Args:
        m: random integer value
        n: random integer value

    """
    result = 0
    for a in range(0,(m+n)):
        for b in range (0, (m+n)):
            if a+b == m and a^b == n:
                result += 1
    return result
            

def main(m: int, n: int):
    _amount = check_for_xor_and_plus(m, n)
    print("The given combination works" + _amount + "times")


if __name__ == "__main__":
    main(sys.argv[1], sys.argv[2])